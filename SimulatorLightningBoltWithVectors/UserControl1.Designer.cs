using SimulatorLightningBoltWithVectors.Core._2D;
using System.Threading.Tasks;

namespace SimulatorLightningBoltWithVectors
{
    partial class UserControl1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

   

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SizeVectorOptionsMenu = new System.Windows.Forms.ToolStripComboBox();
            this.pixelWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PixelWidthOptionsMenu = new System.Windows.Forms.ToolStripComboBox();
            this.BoltContainer = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoltContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItem1.Text = "Actions";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dToolStripMenuItem,
            this.configPropertiesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.Enabled = false;
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dToolStripMenuItem.Text = "2D";
            // 
            // configPropertiesToolStripMenuItem
            // 
            this.configPropertiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.pixelWidthToolStripMenuItem});
            this.configPropertiesToolStripMenuItem.Name = "configPropertiesToolStripMenuItem";
            this.configPropertiesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.configPropertiesToolStripMenuItem.Text = "Config Properties";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SizeVectorOptionsMenu});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(180, 22);
            this.toolStripComboBox1.Text = "SizeVector";
            // 
            // SizeVectorOptionsMenu
            // 
            this.SizeVectorOptionsMenu.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.SizeVectorOptionsMenu.Name = "SizeVectorOptionsMenu";
            this.SizeVectorOptionsMenu.Size = new System.Drawing.Size(121, 23);
            this.SizeVectorOptionsMenu.SelectedIndexChanged += new System.EventHandler(this.SizeVectorOptionsMenu_SelectedIndexChanged);
            // 
            // pixelWidthToolStripMenuItem
            // 
            this.pixelWidthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PixelWidthOptionsMenu});
            this.pixelWidthToolStripMenuItem.Name = "pixelWidthToolStripMenuItem";
            this.pixelWidthToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pixelWidthToolStripMenuItem.Text = "PixelWidth";
            // 
            // PixelWidthOptionsMenu
            // 
            this.PixelWidthOptionsMenu.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.PixelWidthOptionsMenu.Name = "PixelWidthOptionsMenu";
            this.PixelWidthOptionsMenu.Size = new System.Drawing.Size(121, 23);
            this.PixelWidthOptionsMenu.SelectedIndexChanged += new System.EventHandler(this.PixelWidthOptionsMenu_SelectedIndexChanged);
            // 
            // BoltContainer
            // 
            this.BoltContainer.Image = ((System.Drawing.Image)(resources.GetObject("BoltContainer.Image")));
            this.BoltContainer.Location = new System.Drawing.Point(3, 27);
            this.BoltContainer.Name = "BoltContainer";
            this.BoltContainer.Size = new System.Drawing.Size(794, 420);
            this.BoltContainer.TabIndex = 1;
            this.BoltContainer.TabStop = false;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BoltContainer);
            this.Controls.Add(this.menuStrip1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(800, 450);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoltContainer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox BoltContainer;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripComboBox1;
        private System.Windows.Forms.ToolStripComboBox SizeVectorOptionsMenu;
        private System.Windows.Forms.ToolStripMenuItem pixelWidthToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox PixelWidthOptionsMenu;
    }
}
