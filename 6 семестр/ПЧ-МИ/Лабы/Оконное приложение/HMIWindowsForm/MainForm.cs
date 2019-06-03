using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMIWindowsForm
{
    public partial class MainForm : Form
    {
        ControlForm ControlForm { get; set; }

        public MainForm()
        {
            InitializeComponent();
            ControlForm = new ControlForm(this);
        }

        private void OpenControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ControlForm.Visible)
            {
                ControlForm.Show();
                if (this.Location.X + this.Width + ControlForm.Width - 8 > Screen.PrimaryScreen.WorkingArea.Width)
                {
                    ControlForm.Location = new Point(this.Location.X - ControlForm.Width + 8, this.Location.Y);
                }
                else if (this.Location.X - ControlForm.Width + 8 < Screen.PrimaryScreen.WorkingArea.Width)
                {
                    ControlForm.Location = new Point(this.Location.X + this.Width - 8, this.Location.Y);
                }
            }
            else
            {
                ControlForm.TopMost = true;
                ControlForm.TopMost = false;
            }
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            if (ControlForm != null)
            {
                if (this.Location.X + this.Width + ControlForm.Width-8 > Screen.PrimaryScreen.WorkingArea.Width)
                {
                    ControlForm.Location = new Point(this.Location.X - ControlForm.Width+8, this.Location.Y);
                }
                else //if(this.Location.X-ControlForm.Width+8<0)
                {
                    ControlForm.Location = new Point(this.Location.X + this.Width-8, this.Location.Y);
                }
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            var g = panelLight.CreateGraphics();
            g.FillEllipse(Brushes.Gray, new RectangleF(0, 0, panelLight.Width, panelLight.Height));
        }
    }
}
