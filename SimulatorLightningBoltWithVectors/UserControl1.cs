using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimulatorLightningBoltWithVectors.Core._2D;

namespace SimulatorLightningBoltWithVectors
{
    public partial class UserControl1: UserControl
    {
        public BoltCore core;

        public UserControl1()
        {
            InitializeComponent();
            core = new BoltCore(BoltContainer, 10, 30);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            core.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            core.Stop();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
