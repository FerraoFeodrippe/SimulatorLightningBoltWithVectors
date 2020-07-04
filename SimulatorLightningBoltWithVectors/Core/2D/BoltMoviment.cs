using SimulatorLightningBoltWithVectors.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimulatorLightningBoltWithVectors.Core._2D
{

    public class BoltMoviment : IDisposable
    {
        private readonly double _chanceRamification;

        private readonly float _wLimit;
        private readonly float _hLimit;
        private Vector2 _boltPosition;
        private Vector2 _boltVector;
        private Vector2 _sizeVector;

        private readonly float _maxAng;
        private float _actuaAng;
        private readonly int _frameRate;
        private readonly int _removePointRate;

        public bool QueeFilled { get; private set; }
        private bool _hasFinished;

        private readonly Queue<Vector2> _points;
        private readonly Dictionary<Vector2, Queue<Vector2>> _ramificationPoints;

        public Tuple<Queue<Vector2>, Dictionary<Vector2, Queue<Vector2>>> GetPoints
        {
            get
            {
                lock (__lock)
                {
                    return new Tuple<Queue<Vector2>, Dictionary<Vector2, Queue<Vector2>>>(
                    //_points, _ramificationPoints);
                    new Queue<Vector2>(_points),
                        new Dictionary<Vector2, Queue<Vector2>>(_ramificationPoints));
                }
            }
        }

        readonly IStateCheck _state;

        private readonly object __lock;

        private Task _tQuee;
        private Task _tDequee;

        public BoltMoviment(float wLimit, float hLimit, float sizeVector, 
            float maxAng, int frameRate, int removePointRateFactor,
            IStateCheck state)
        {
            QueeFilled = false;
            _hasFinished = false;

            _chanceRamification = 0.35;
            _actuaAng = 0;
            _maxAng = maxAng;
            _frameRate = frameRate;
            _removePointRate = frameRate * removePointRateFactor;
            _wLimit = wLimit;
            _hLimit = hLimit;
            _sizeVector = Vector2.UnitX * sizeVector;
            _points = new Queue<Vector2>();
            _ramificationPoints = new Dictionary<Vector2, Queue<Vector2>>();

            _state = state;

            __lock = new object();
        }

        public async void Start()
        {
            await Task.Run(Quee).ContinueWith(t => _tQuee = t);

            await Task.Delay(_frameRate * 2);

            await Task.Run(Dequee).ContinueWith(t => _tDequee = t); 
        }

        private async void Quee()
        {
            Random rand = new Random();

            _boltPosition = new Vector2((float)rand.NextDouble() * _wLimit, (float)rand.NextDouble() * _hLimit);
            _actuaAng = (float)rand.NextDouble() * 360;

            _boltVector = _boltPosition + _sizeVector;

            var points = ChangePosition();

            foreach(var point in points)
            {
                await Task.Run(() => _state.WaitPause());

                lock (__lock)
                {
                    _points.Enqueue(point);

                    if (rand.NextDouble() < _chanceRamification)
                    {
                        var rams = Ramification(point);
                        _ramificationPoints[point] = rams;
                    }
                }

                await Task.Delay(_frameRate);
            }

            QueeFilled = true;
        }

        private async void Dequee()
        {
            bool any;

            lock (__lock)
            {
                any = _points.Any();
            }

            while (any)
            {
                await Task.Run(() => _state.WaitPause());

                lock (__lock)
                {
                    var removed = _points.Dequeue();

                    if (_ramificationPoints.ContainsKey(removed))
                    {
                        _ramificationPoints[removed].Clear();
                        _ramificationPoints.Remove(removed);
                    }

                    any = _points.Any();
                }

                await Task.Delay(_removePointRate);
            }
            lock (__lock)
            {
                _hasFinished = true;
            }
        }

        public bool HasFinished()
        {
            lock (__lock)
            {
                return _hasFinished;
            }
        }

        private Queue<Vector2> Ramification(Vector2 point)
        {
            Random rand = new Random();
            Queue<Vector2> ret = new Queue<Vector2>();

            Vector2 rPoint = point;

            var fatorL = 10;
            fatorL = Math.Max(2, (int) _sizeVector.X / fatorL);

            var ramificationRange = fatorL + rand.Next(3+fatorL);
            var direction = 2 * (rand.NextDouble() - 0.5);

            while (ramificationRange > 0)
            {
                float localRange = (float) (rand.NextDouble() * (_maxAng + 22.5) * direction + (direction * 22.5));
                var actuaAng = _actuaAng + localRange;

                float newX = _sizeVector.X * (float)Math.Cos(actuaAng * Math.PI / 180);
                float newY = _sizeVector.X * (float)Math.Sin(actuaAng * Math.PI / 180);

                rPoint.X += newX;
                rPoint.Y += newY;

                ramificationRange--;

                ret.Enqueue(rPoint);
            }

            return ret;
        }

        private IEnumerable<Vector2> ChangePosition()
        {
            Random rand = new Random();

            while ( _boltVector.X > 0 && _boltVector.X < _wLimit &&
                    _boltVector.Y > 0 && _boltVector.Y < _hLimit)
            {
                float localRange = (float)rand.NextDouble() * _maxAng - _maxAng / 2;

                var actuaAng = _actuaAng + localRange;

                float newX = _sizeVector.X * (float) Math.Cos(actuaAng * Math.PI/180);
                float newY = _sizeVector.X * (float) Math.Sin(actuaAng * Math.PI/180);

                _boltPosition = _boltVector;

                _boltVector.X = _boltPosition.X + newX;
                _boltVector.Y = _boltPosition.Y + newY;

                yield return _boltVector;
            }
        }

        public void Dispose()
        {
            if (_tQuee != null)
                _tQuee.Dispose();

            if (_tDequee != null)
                _tDequee.Dispose();
        }
    }
}
