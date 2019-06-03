using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMIWindowsForm
{
    public enum PereezdMode
    {
        Manual = 0,
        Automatic = 1
    }

    class Pereezd
    {
        public bool Opened { get; set; }
        public PereezdMode Mode { get; set; }
        public bool SoundSignal { get; set; }
        public bool LightSignal { get; set; }
        public int OpenDist { get; set; }
        public int CloseDist { get; set; }
        private Panel Barier;
        private Panel PanelLight;
        public Timer LightTimer;
        public System.Drawing.Graphics graphics;
        private bool Yellow;
        private const int TickTimes = 10;
        private int CurrentTicks = 0;
        public Pereezd(Panel barier, Panel panelLight)
        {
            Opened = false;
            Mode = PereezdMode.Manual;
            Barier = barier;
            PanelLight = panelLight;
            LightTimer = new Timer();
            LightTimer.Tick += LightTimer_Tick;
            LightTimer.Interval = 500;
            Yellow = false;
        }

        public void MakeSoundSignal()
        {
            using (var sound = new System.Media.SoundPlayer("PereezdBeep.wav"))
            {
                sound.Play();
            }
        }

        public void MakeLightSingal()
        {
            graphics = PanelLight.CreateGraphics();
            LightTimer.Start();
        }

        private void LightTimer_Tick(object sender, EventArgs e)
        {
            if (CurrentTicks >= TickTimes && Mode==PereezdMode.Manual)
            {
                LightTimer.Stop();
                CurrentTicks = 0;
                return;
            }

            if (!Yellow)
            {
                graphics.FillEllipse(System.Drawing.Brushes.Yellow, new System.Drawing.RectangleF(0, 0, PanelLight.Width, PanelLight.Height));
                Yellow = true;
                CurrentTicks++;
            }
            else
            {
                graphics.FillEllipse(System.Drawing.Brushes.Gray, new System.Drawing.RectangleF(0, 0, PanelLight.Width, PanelLight.Height));
                Yellow = false;
                CurrentTicks++;
            }
        }

        public void OpenBarier()
        {
            Barier.Location = new System.Drawing.Point(132, 40);
            Barier.Size = new System.Drawing.Size(26, 270);
        }

        public void CloseBarier()
        {
            Barier.Location = new System.Drawing.Point(132, 302);
            Barier.Size = new System.Drawing.Size(270, 26);
        }

        public void OpenPereezd()
        {
            Opened = true;
        }

        public void ClosePereezd()
        {
            Opened = false;
        }
    }
}
