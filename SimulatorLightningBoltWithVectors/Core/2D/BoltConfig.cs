using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLightningBoltWithVectors.Core._2D
{

    public class BoltConfig
    {
        public Pen PenConfig { get; set; }

        public BoltConfig(Color boltMainColor, float boltWidth)
        {
            PenConfig = new Pen(boltMainColor, boltWidth);
        }

        public BoltConfig(Color boltMainColor): this(boltMainColor, 1)
        {

        }

    }
}
