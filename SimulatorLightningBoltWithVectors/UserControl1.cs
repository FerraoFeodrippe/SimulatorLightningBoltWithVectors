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

            var size = float.Parse(SizeVectorOptionsMenu.Items[0].ToString());
            var width = float.Parse(PixelWidthOptionsMenu.Items[0].ToString());

            core = new BoltCore(BoltContainer, width, size, 45, 15, 2);

            PixelWidthOptionsMenu.SelectedItem = PixelWidthOptionsMenu.Items[0];
            SizeVectorOptionsMenu.SelectedItem = SizeVectorOptionsMenu.Items[0];
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            core.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
           core.Pause();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            core.Restart();
        }

        private void SizeVectorOptionsMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SizeVectorOptionsMenu.SelectedItem != null)
            {
                core.SetBoltSizeVector(float.Parse(SizeVectorOptionsMenu.SelectedItem.ToString()));
            }
        }

        private void PixelWidthOptionsMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PixelWidthOptionsMenu.SelectedItem != null)
            {
                core.SetBoltWidth(float.Parse(PixelWidthOptionsMenu.SelectedItem.ToString()));
            }
        }
    }
}
