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



    public partial class ControlForm : Form
    {
        Pereezd pereezd;
        Timer timerTrainInScreen;
        Timer timerTrainOutOfScreen;
        Timer timerTrainGoOut;
        MainForm MainForm { get; set; }
        PictureBox Train;
        System.Media.SoundPlayer TrainBeep;

        private int DistToPereezd;

        public ControlForm(MainForm mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
            pereezd = new Pereezd(mainForm.panelBarier, mainForm.panelLight);
            Train = mainForm.pictureBoxTrain;
            TrainBeep = new System.Media.SoundPlayer("TrainBeep.wav");

            buttonClosePereezd_Click(this, new EventArgs());
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonMakeSoundSignal_Click(object sender, EventArgs e)
        {
            pereezd.MakeSoundSignal();
        }

        private void buttonStartTrain_Click(object sender, EventArgs e)
        {
            buttonStartTrain.Enabled = false;
            
            Train.Location = new Point(MainForm.Width, 144);
            Train.Visible = true;
            Random rnd = new Random();
            DistToPereezd = rnd.Next(100, 400);
            MainForm.labelDist.Text = DistToPereezd.ToString();

            timerTrainOutOfScreen = new Timer();
            timerTrainOutOfScreen.Enabled = true;
            timerTrainOutOfScreen.Tick += TimerTrainOutOfScreen_Tick;
            timerTrainOutOfScreen.Interval = 10;
            timerTrainOutOfScreen.Start();

            if (pereezd.Mode == PereezdMode.Automatic)
            {
                if (pereezd.LightSignal)
                    pereezd.MakeLightSingal();
                if (pereezd.SoundSignal)
                    pereezd.MakeSoundSignal();
            }                      
        }

        private void TimerTrainGoOut_Tick(object sender, EventArgs e)
        {
            DistToPereezd = DistToPereezd < pereezd.OpenDist ? DistToPereezd + 20 : pereezd.OpenDist;

            MainForm.labelDist.Text = DistToPereezd.ToString();
            if (pereezd.Mode == PereezdMode.Automatic)
            {
                if (DistToPereezd >= pereezd.OpenDist)
                {
                    pereezd.OpenBarier();
                    pereezd.LightTimer.Stop();
                    MainForm.panelLight.CreateGraphics().FillEllipse(System.Drawing.Brushes.Gray, new System.Drawing.RectangleF(0, 0, MainForm.panelLight.Width, MainForm.panelLight.Height));

                }
            }
            if (DistToPereezd >= pereezd.OpenDist)
            {
                buttonStartTrain.Enabled = true;
                MainForm.labelDist.Text = "поезд не приближается";
                timerTrainGoOut.Stop();
                timerTrainGoOut.Enabled = false;
            }
        }

        private void TimerTrainOutOfScreen_Tick(object sender, EventArgs e)
        {
            DistToPereezd = DistToPereezd-20 < 0 ? 0: DistToPereezd - 20;

            MainForm.labelDist.Text = DistToPereezd.ToString();
            if (pereezd.Mode == PereezdMode.Automatic)
            {
                if (DistToPereezd <= pereezd.CloseDist)
                {
                    pereezd.CloseBarier();
                }
            }
            if (DistToPereezd <= pereezd.CloseDist)
            {
                timerTrainInScreen = new Timer();
                timerTrainInScreen.Enabled = true;
                timerTrainInScreen.Tick += timerTrainInScreen_Tick;

                timerTrainInScreen.Interval = 10;
                timerTrainInScreen.Start();
                TrainBeep.PlayLooping();

                timerTrainOutOfScreen.Stop();
                timerTrainOutOfScreen.Enabled = false;
            }
        }

        private void timerTrainInScreen_Tick(object sender, EventArgs e)
        {
            DistToPereezd = DistToPereezd-20 < 0 ? 0 : DistToPereezd - 20;
            MainForm.labelDist.Text = DistToPereezd.ToString();

            Train.Location = new Point(Train.Location.X - 1, Train.Location.Y);
            if (Train.Location.X + Train.Width < 0)
            {

                timerTrainGoOut = new Timer();
                timerTrainGoOut.Interval = 10;
                timerTrainGoOut.Tick += TimerTrainGoOut_Tick;
                timerTrainGoOut.Start();

                timerTrainInScreen.Stop();
                TrainBeep.Stop();
                timerTrainInScreen.Enabled = false;
            }
        }

        private void buttonOpenPereezd_Click(object sender, EventArgs e)
        {
            pereezd.OpenPereezd();

            buttonChangeMode.Enabled = true;
            buttonStartTrain.Enabled = true;

            labelOpenPereezd.Visible = labelOpenPereezd.Enabled = false;
            buttonOpenPereezd.Visible = buttonOpenPereezd.Enabled = false;
            labelClosePereezd.Visible = labelClosePereezd.Enabled = true;
            buttonClosePereezd.Visible = buttonClosePereezd.Enabled = true;
            if (groupBoxAuto.Visible)
            {
                groupBoxAuto.Enabled = true;
            }
            else
            {
                groupBoxManual.Enabled = true;
            }
            buttonOpenBarier_Click(this, new EventArgs());
        }

        private void buttonClosePereezd_Click(object sender, EventArgs e)
        {
            pereezd.ClosePereezd();

            buttonChangeMode.Enabled = false;
            //buttonStartTrain.Enabled = false;

            labelOpenPereezd.Visible = labelOpenPereezd.Enabled = true;
            buttonOpenPereezd.Visible = buttonOpenPereezd.Enabled = true;
            labelClosePereezd.Visible = labelClosePereezd.Enabled = false;
            buttonClosePereezd.Visible = buttonClosePereezd.Enabled = false;
            if (groupBoxAuto.Visible)
            {
                groupBoxAuto.Enabled = false;
            }
            else
            {
                groupBoxManual.Enabled = false;
            }
            buttonCloseBarier_Click(this, new EventArgs());
        }

        private void buttonChangeMode_Click(object sender, EventArgs e)
        {
            if (pereezd.Mode == PereezdMode.Manual)
            {
                pereezd.Mode = PereezdMode.Automatic;
                buttonStartTrain.Enabled = false;
                groupBoxManual.Enabled = false;
                groupBoxManual.Visible = false;
                groupBoxAuto.Visible = true;
                groupBoxAuto.Enabled = true;
            }
            else
            {
                pereezd.Mode = PereezdMode.Manual;
                groupBoxManual.Enabled = true;
                groupBoxManual.Visible = true;
                groupBoxAuto.Visible = false;
                groupBoxAuto.Enabled = false;
            }
        }

        private void buttonStartAutomatic_Click(object sender, EventArgs e)
        {
            pereezd.CloseDist = (int)numericUpDownBeforeClose.Value;
            pereezd.OpenDist = (int)numericUpDownBeforeOpen.Value;
            pereezd.SoundSignal = checkBoxMakeSoundSignal.Checked;
            pereezd.LightSignal = checkBoxMakeLightSignal.Checked;

            buttonStartTrain.Enabled = true;
            buttonStartAutomatic.Enabled = false;
            buttonChangeProperties.Enabled = true;
            checkBoxMakeLightSignal.Enabled = checkBoxMakeSoundSignal.Enabled = false;
            numericUpDownBeforeClose.Enabled = numericUpDownBeforeOpen.Enabled = false;
        }

        private void buttonChangeProperties_Click(object sender, EventArgs e)
        {
            buttonStartAutomatic.Enabled = true;
            buttonChangeProperties.Enabled = false;
            checkBoxMakeLightSignal.Enabled = checkBoxMakeSoundSignal.Enabled = true;
            numericUpDownBeforeClose.Enabled = numericUpDownBeforeOpen.Enabled = true;
        }

        private void buttonMakeLigthSignal_Click(object sender, EventArgs e)
        {
            pereezd.MakeLightSingal();
        }

        private void buttonOpenBarier_Click(object sender, EventArgs e)
        {
            pereezd.OpenBarier();
            labelOpenBarier.Visible = false;
            buttonOpenBarier.Visible = buttonOpenBarier.Enabled = false;
            labelCloseBarier.Visible = labelCloseBarier.Enabled = true;
            buttonCloseBarier.Visible = buttonCloseBarier.Enabled = true;
        }

        private void buttonCloseBarier_Click(object sender, EventArgs e)
        {
            pereezd.CloseBarier();
            labelOpenBarier.Visible = true;
            buttonOpenBarier.Visible = buttonOpenBarier.Enabled = true;
            labelCloseBarier.Visible = false;
            buttonCloseBarier.Visible = buttonCloseBarier.Enabled = false;
        }
    }
}
