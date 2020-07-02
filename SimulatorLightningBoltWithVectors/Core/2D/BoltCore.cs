using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLightningBoltWithVectors.Core._2D
{
    public class BoltCore
    {
        private readonly BoltMoviment _bolt;
        private readonly BoltConfig _config;

        private System.Windows.Forms.PictureBox _boltContainer;
        
        public float MaxAng { get; set; }

        public bool _stop { get; set; }

        public BoltCore( System.Windows.Forms.PictureBox BoltContainer, float sizeVector, float maxAng)
        {
            _bolt = new BoltMoviment(BoltContainer.Width, BoltContainer.Height, sizeVector);
            _boltContainer = BoltContainer;

            MaxAng = maxAng;

            _config = new BoltConfig();

            _stop = false;
        }

        public async void Start()
        {
            _stop = false;

            while (!_stop)
            {
                Bolt();

                await Task.Delay(100);
            }
        }

        public void Stop()
        {
            _stop = true;
        }

        public void Bolt()
        {
            var line = _bolt.ChangePosition(MaxAng);

            var image = _boltContainer.Image;
            Graphics g = Graphics.FromImage(image);

            Pen brush = new Pen(Color.Red);

            g.DrawLine(brush, line.Item1.X, line.Item1.Y, line.Item2.X, line.Item2.Y);
            g.Save();

            _boltContainer.Image = image;

        }

    }
}
