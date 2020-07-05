using LightingBoltSimulator.Core._2D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightingBoltSimulator
{
    public partial class UPrincipal : Form
    {
        private readonly BoltCore _core;

        public UPrincipal()
        {
            InitializeComponent();

            var size = float.Parse(SizeVectorOptionsMenu.Items[0].ToString());
            var width = float.Parse(PixelWidthOptionsMenu.Items[0].ToString());

            _core = new BoltCore(BoltContainer, width, size, 45, 15, 2);

            PixelWidthOptionsMenu.SelectedItem = PixelWidthOptionsMenu.Items[0];
            SizeVectorOptionsMenu.SelectedItem = SizeVectorOptionsMenu.Items[0];
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _core.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _core.Pause();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _core.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SizeVectorOptionsMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SizeVectorOptionsMenu.SelectedItem != null)
            {
                _core.SetBoltSizeVector(float.Parse(SizeVectorOptionsMenu.SelectedItem.ToString()));
            }
        }

        private void PixelWidthOptionsMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PixelWidthOptionsMenu.SelectedItem != null)
            {
                _core.SetBoltWidth(float.Parse(PixelWidthOptionsMenu.SelectedItem.ToString()));
            }
        }
    }
}
