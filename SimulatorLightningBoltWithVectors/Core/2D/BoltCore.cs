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
        private Bitmap _bitmapDefault;
        private Bitmap _bitmap;

        private System.Windows.Forms.PictureBox _boltContainer;

        private volatile bool _paused;
        private volatile bool _executing;

        public float MaxAng { get; set; }

        public int FrameRate { get; set; }
        public int RemovePointRateFactor { get; set; }

        public BoltCore( System.Windows.Forms.PictureBox boltContainer,
            float boltWidth, float sizeVector, float maxAng, int frameRate = 1, int removePointRateFactor = 5)
        {
            _bolts = new List<BoltMoviment>();
            _sizeVector = sizeVector;
            _boltContainer = boltContainer;
            _config = new BoltConfig(Color.BlueViolet, boltWidth);
            _bitmapDefault = new Bitmap(boltContainer.Image);
            _executing = false;

            MaxAng = maxAng;
            FrameRate = frameRate;
            RemovePointRateFactor = removePointRateFactor;
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

                var finishedBolts = new List<BoltMoviment>(_bolts.Where(e => e.HasFinished));

                foreach (var bolt in finishedBolts)
                {
                    _bolts.Remove(bolt);
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
            _bolts.Clear();

            _executing = false;

            Start();
        }

        private void NextBolt()
        {
            _actualBolt = new BoltMoviment(_boltContainer.Width, _boltContainer.Height, _sizeVector
                , MaxAng, FrameRate, RemovePointRateFactor, this);

            _actualBolt.Start();
            _bolts.Add(_actualBolt);
        }

        private void DrawPoints()
        {
            try
            {
                _bitmap = new Bitmap(_bitmapDefault);
                Graphics g = Graphics.FromImage(_bitmap);
                Pen brush = _config.PenConfig;
                var last = new List<BoltMoviment>(_bolts);

                foreach (var bolt in _bolts)
                {
                    var points = bolt.Points;

                    if (points.Count > 1)
                    {
                        var rams = bolt.RamificationPoints;

                        g.DrawLines(brush, points.Select(p => new PointF(p.X, p.Y)).ToArray());

                        foreach(var ram in rams)
                        {
                            g.DrawLines(brush, ram.Value.Select(p => new PointF(p.X, p.Y)).ToArray());
                        }

                    }
                }

                g.Save();
                _boltContainer.Image = _bitmap;
            }
            catch
            {

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
