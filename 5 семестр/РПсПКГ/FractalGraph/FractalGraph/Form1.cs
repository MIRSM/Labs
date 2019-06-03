using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractalGraph
{
    public partial class Form1 : Form
    {

        public Graphics graphics;
        public Form1()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    Size size = new Size(Width, Height);
                    pictureBox1.Size = size;
                    graphics.FillRectangle(Brushes.Black, 0, 0, Width, Height);
                    Tr(500, 0, 780, 460, 220, 460);
                    DrawL(500, 0, 780, 460, 220, 460, 7);

                    break;
                default:
                    MessageBox.Show("Hi");
                    break;
            }
        }

        public void Tr(float x1, float y1, float x2, float y2, float x3, float y3)
        {

            graphics.DrawLine(Pens.Magenta, (float)Math.Round(x1), (float)Math.Round(y1),
                (float)Math.Round(x2), (float)Math.Round(y2));
            graphics.DrawLine(Pens.Magenta, (float)Math.Round(x2), (float)Math.Round(y2),
                (float)Math.Round(x3), (float)Math.Round(y3));
            graphics.DrawLine(Pens.Magenta, (float)Math.Round(x3), (float)Math.Round(y3),
                (float)Math.Round(x1), (float)Math.Round(y1));
        }

        public void DrawL(float x1, float y1, float x2, float y2, float x3, float y3, int n)
        {
            if (n > 0)
            {
                float x1n = (x1 + x2) / 2;
                float y1n = (y1 + y2) / 2;
                float x2n = (x2 + x3) / 2;
                float y2n = (y2 + y3) / 2;
                float x3n = (x3 + x1) / 2;
                float y3n = (y3 + y1) / 2;

                Tr(x1n, y1n, x2n, y2n, x3n, y3n);

                DrawL(x1, y1, x1n, y1n, x3n, y3n, n - 1);
                DrawL(x2, y2, x1n, y1n, x2n, y2n, n - 1);
                DrawL(x3, y3, x2n, y2n, x3n, y3n, n - 1);
            }
        }
    }
}
