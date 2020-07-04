using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SimulatorLightningBoltWithVectors.Interfaces;

namespace SimulatorLightningBoltWithVectors.Core._2D
{
    public class BoltCore : IStateCheck
    {
        private readonly IList<BoltMoviment> _bolts ;
        private BoltMoviment _actualBolt;
        private readonly BoltConfig _config;

        private float _sizeVector;
        private readonly Bitmap _bitmapDefault;
        private Bitmap _bitmap;

        private readonly System.Windows.Forms.PictureBox _boltContainer;

        private volatile bool _paused;
        private volatile bool _executing;

        public float MaxAng { get; set; }

        public int FrameRate { get; set; }
        public int RemovePointRateFactor { get; set; }

        public object __lock;

        public BoltCore( System.Windows.Forms.PictureBox boltContainer,
            float boltWidth, float sizeVector, float maxAng, int frameRate = 1, int removePointRateFactor = 5)
        {
            _bolts = new List<BoltMoviment>();
            _sizeVector = sizeVector;
            _boltContainer = boltContainer;
            _config = new BoltConfig(Color.DeepSkyBlue, boltWidth);
            _bitmapDefault = new Bitmap(boltContainer.Image);
            _executing = false;

            MaxAng = maxAng;
            FrameRate = frameRate;
            RemovePointRateFactor = removePointRateFactor;

            __lock = new object();
        }

        public async void Start()
        {
            _paused = false;

            if (_executing) return;
            
            _executing = true;
            NextBolt();

            while (_executing)
            {
                await Task.Run(() => WaitPause());
                await Task.Delay(FrameRate);

                lock (__lock)
                {
                    var finishedBolts = _bolts.Where(e => e.HasFinished()).ToList();

                    foreach (var bolt in finishedBolts)
                    {
                        _bolts.Remove(bolt);
                    }

                }

                if (_actualBolt.QueeFilled)
                {
                    NextBolt();
                }

                await Task.Run(() => DrawPoints());
            }
        }

        public void Pause()
        {
            _paused = !_paused;
        }

        public void Restart()
        {
            Pause();
            _executing = false;

            foreach(var bolt in _bolts)
            {
                bolt.Dispose();
            }

            _bolts.Clear();

            Start();
        }

        private void NextBolt()
        {
            lock (__lock)
            {
                _actualBolt = new BoltMoviment(_boltContainer.Width, _boltContainer.Height, _sizeVector
                , MaxAng, FrameRate, RemovePointRateFactor, this);

                _actualBolt.Start();
                _bolts.Add(_actualBolt);
            }
        }

        private void DrawPoints()
        {
            lock (__lock)
            {
                _bitmap = new Bitmap(_bitmapDefault);
                Graphics g = Graphics.FromImage(_bitmap);
                Pen brush = _config.PenConfig;
                var last = new List<BoltMoviment>(_bolts);

                foreach (var bolt in _bolts)
                {
                    var tuple = bolt.GetPoints;

                    var points = tuple.Item1;

                    if (points.Count > 1)
                    {
                        var rams = tuple.Item2;

                        var p1 = points.Dequeue();

                        while (points.Any())
                        {
                            var rPoints = rams.ContainsKey(p1) ? new Queue<Vector2>(rams[p1]) : new Queue<Vector2>();

                            if (rPoints.Any() && rPoints.Count > 1)
                            {
                                var rP1 = p1;

                                while (rPoints.Any())
                                {
                                    var rP2 = rPoints.Dequeue();

                                    g.DrawLine(brush, rP1.X, rP1.Y, rP2.X, rP2.Y);

                                    rP1 = rP2;
                                }
                            }

                            var p2 = points.Dequeue();
                            g.DrawLine(brush, p1.X, p1.Y, p2.X, p2.Y);

                            p1 = p2;
                        }

                        foreach (var point in points)
                        {
                            g.DrawLines(brush, points.Select(p => new PointF(p.X, p.Y)).ToArray());
                        }

                    }
                }

                g.Save();
                _boltContainer.Image = _bitmap;
            }
        }

        public void SetBoltWidth(float width)
        {
            lock(__lock)
            {
                _config.PenConfig.Width = width;
            }
        }

        public void SetBoltSizeVector(float sizeVector)
        {
            lock (__lock)
            {
                 _sizeVector = sizeVector;
            }
        }

        public bool IsExecuting()
        {
            return _executing;
        }

        public bool IsPausing()
        {
            return _paused;
        }

        public void WaitPause()
        {
            while (IsPausing());
        }
    }
}
