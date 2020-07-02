using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLightningBoltWithVectors.Core._2D
{

    public class BoltMoviment
    {
        private float _wLimit;
        private float _hLimit;
        private Vector2 _boltPosition;
        private Vector2 _boltVector;
        private Vector2 _sizeVector;

        private bool _nextBolt;
        private float _actuaAng;

        public BoltMoviment(float wLimit, float hLimit, float sizeVector)
        {
            _nextBolt = true;
            _actuaAng = 0;

            _wLimit = wLimit;
            _hLimit = hLimit;
            _sizeVector = Vector2.UnitX * sizeVector;
        }

        public Tuple<Vector2, Vector2> ChangePosition(float maxAng)
        {
            NextBolt();

            Random rand = new Random();

            float ang = (float) rand.NextDouble() * maxAng + _actuaAng;
            float newX = _sizeVector.X * (float) Math.Cos(ang * Math.PI/180);
            float newY = _sizeVector.X * (float) Math.Sin(ang * Math.PI/180);

            _boltPosition = _boltVector;

            _boltVector.X = _boltPosition.X + newX;
            _boltVector.Y = _boltPosition.Y + newY;

            if (_boltVector.X < 0 || _boltVector.X > _wLimit ||
                _boltVector.Y < 0 || _boltVector.Y > _hLimit)
                _nextBolt = true;

            return new Tuple<Vector2, Vector2>(_boltPosition, _boltVector);
        }

        private void NextBolt()
        {
            Random rand = new Random();

            if (_nextBolt)
            {
                _actuaAng = (float) rand.NextDouble() * 360;
                _boltPosition = new Vector2((float)rand.NextDouble() * _wLimit, (float)rand.NextDouble() * _hLimit);
                _boltVector = _boltPosition + _sizeVector;

                _nextBolt = false;
            }
        }





    }
}
