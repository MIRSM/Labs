namespace HMIWindowsForm
{
    partial class ControlForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonClose = new System.Windows.Forms.Button();
            this.groupBoxManual = new System.Windows.Forms.GroupBox();
            this.labelCloseBarier = new System.Windows.Forms.Label();
            this.buttonCloseBarier = new System.Windows.Forms.Button();
            this.labelOpenBarier = new System.Windows.Forms.Label();
            this.buttonOpenBarier = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonMakeLigthSignal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonMakeSoundSignal = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonStartTrain = new System.Windows.Forms.Button();
            this.groupBoxAuto = new System.Windows.Forms.GroupBox();
            this.buttonChangeProperties = new System.Windows.Forms.Button();
            this.buttonStartAutomatic = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownBeforeOpen = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownBeforeClose = new System.Windows.Forms.NumericUpDown();
            this.checkBoxMakeSoundSignal = new System.Windows.Forms.CheckBox();
            this.checkBoxMakeLightSignal = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonChangeMode = new System.Windows.Forms.Button();
            this.labelOpenPereezd = new System.Windows.Forms.Label();
            this.buttonOpenPereezd = new System.Windows.Forms.Button();
            this.labelClosePereezd = new System.Windows.Forms.Label();
            this.buttonClosePereezd = new System.Windows.Forms.Button();
            this.groupBoxManual.SuspendLayout();
            this.groupBoxAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeforeOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeforeClose)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonClose
            // 
            this.ButtonClose.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonClose.Location = new System.Drawing.Point(311, 314);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(85, 28);
            this.ButtonClose.TabIndex = 0;
            this.ButtonClose.Text = "Закрыть";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // groupBoxManual
            // 
            this.groupBoxManual.Controls.Add(this.labelCloseBarier);
            this.groupBoxManual.Controls.Add(this.buttonCloseBarier);
            this.groupBoxManual.Controls.Add(this.labelOpenBarier);
            this.groupBoxManual.Controls.Add(this.buttonOpenBarier);
            this.groupBoxManual.Controls.Add(this.label2);
            this.groupBoxManual.Controls.Add(this.buttonMakeLigthSignal);
            this.groupBoxManual.Controls.Add(this.label1);
            this.groupBoxManual.Controls.Add(this.buttonMakeSoundSignal);
            this.groupBoxManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxManual.Location = new System.Drawing.Point(16, 12);
            this.groupBoxManual.Name = "groupBoxManual";
            this.groupBoxManual.Size = new System.Drawing.Size(233, 330);
            this.groupBoxManual.TabIndex = 3;
            this.groupBoxManual.TabStop = false;
            this.groupBoxManual.Text = "Ручное управление";
            // 
            // labelCloseBarier
            // 
            this.labelCloseBarier.AutoSize = true;
            this.labelCloseBarier.Enabled = false;
            this.labelCloseBarier.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCloseBarier.Location = new System.Drawing.Point(7, 134);
            this.labelCloseBarier.Name = "labelCloseBarier";
            this.labelCloseBarier.Size = new System.Drawing.Size(163, 20);
            this.labelCloseBarier.TabIndex = 7;
            this.labelCloseBarier.Text = "Закрыть шлагбаум";
            this.labelCloseBarier.Visible = false;
            // 
            // buttonCloseBarier
            // 
            this.buttonCloseBarier.Enabled = false;
            this.buttonCloseBarier.Location = new System.Drawing.Point(11, 157);
            this.buttonCloseBarier.Name = "buttonCloseBarier";
            this.buttonCloseBarier.Size = new System.Drawing.Size(91, 30);
            this.buttonCloseBarier.TabIndex = 6;
            this.buttonCloseBarier.Text = "Закрыть";
            this.buttonCloseBarier.UseVisualStyleBackColor = true;
            this.buttonCloseBarier.Visible = false;
            this.buttonCloseBarier.Click += new System.EventHandler(this.buttonCloseBarier_Click);
            // 
            // labelOpenBarier
            // 
            this.labelOpenBarier.AutoSize = true;
            this.labelOpenBarier.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOpenBarier.Location = new System.Drawing.Point(7, 134);
            this.labelOpenBarier.Name = "labelOpenBarier";
            this.labelOpenBarier.Size = new System.Drawing.Size(163, 20);
            this.labelOpenBarier.TabIndex = 5;
            this.labelOpenBarier.Text = "Открыть шлагбаум";
            // 
            // buttonOpenBarier
            // 
            this.buttonOpenBarier.Location = new System.Drawing.Point(11, 157);
            this.buttonOpenBarier.Name = "buttonOpenBarier";
            this.buttonOpenBarier.Size = new System.Drawing.Size(91, 30);
            this.buttonOpenBarier.TabIndex = 4;
            this.buttonOpenBarier.Text = "Открыть";
            this.buttonOpenBarier.UseVisualStyleBackColor = true;
            this.buttonOpenBarier.Click += new System.EventHandler(this.buttonOpenBarier_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Подать световой сигнал";
            // 
            // buttonMakeLigthSignal
            // 
            this.buttonMakeLigthSignal.Location = new System.Drawing.Point(10, 101);
            this.buttonMakeLigthSignal.Name = "buttonMakeLigthSignal";
            this.buttonMakeLigthSignal.Size = new System.Drawing.Size(92, 30);
            this.buttonMakeLigthSignal.TabIndex = 2;
            this.buttonMakeLigthSignal.Text = "Пип";
            this.buttonMakeLigthSignal.UseVisualStyleBackColor = true;
            this.buttonMakeLigthSignal.Click += new System.EventHandler(this.buttonMakeLigthSignal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Подать звуковой сигнал";
            // 
            // buttonMakeSoundSignal
            // 
            this.buttonMakeSoundSignal.Location = new System.Drawing.Point(10, 45);
            this.buttonMakeSoundSignal.Name = "buttonMakeSoundSignal";
            this.buttonMakeSoundSignal.Size = new System.Drawing.Size(92, 30);
            this.buttonMakeSoundSignal.TabIndex = 0;
            this.buttonMakeSoundSignal.Text = "Бип";
            this.buttonMakeSoundSignal.UseVisualStyleBackColor = true;
            this.buttonMakeSoundSignal.Click += new System.EventHandler(this.buttonMakeSoundSignal_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(251, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Запустить поезд";
            // 
            // buttonStartTrain
            // 
            this.buttonStartTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStartTrain.Location = new System.Drawing.Point(255, 57);
            this.buttonStartTrain.Name = "buttonStartTrain";
            this.buttonStartTrain.Size = new System.Drawing.Size(92, 30);
            this.buttonStartTrain.TabIndex = 8;
            this.buttonStartTrain.Text = "Пуск";
            this.buttonStartTrain.UseVisualStyleBackColor = true;
            this.buttonStartTrain.Click += new System.EventHandler(this.buttonStartTrain_Click);
            // 
            // groupBoxAuto
            // 
            this.groupBoxAuto.Controls.Add(this.buttonChangeProperties);
            this.groupBoxAuto.Controls.Add(this.buttonStartAutomatic);
            this.groupBoxAuto.Controls.Add(this.label6);
            this.groupBoxAuto.Controls.Add(this.numericUpDownBeforeOpen);
            this.groupBoxAuto.Controls.Add(this.label5);
            this.groupBoxAuto.Controls.Add(this.numericUpDownBeforeClose);
            this.groupBoxAuto.Controls.Add(this.checkBoxMakeSoundSignal);
            this.groupBoxAuto.Controls.Add(this.checkBoxMakeLightSignal);
            this.groupBoxAuto.Enabled = false;
            this.groupBoxAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxAuto.Location = new System.Drawing.Point(16, 12);
            this.groupBoxAuto.Name = "groupBoxAuto";
            this.groupBoxAuto.Size = new System.Drawing.Size(233, 330);
            this.groupBoxAuto.TabIndex = 8;
            this.groupBoxAuto.TabStop = false;
            this.groupBoxAuto.Text = "Автоматическое управление";
            this.groupBoxAuto.Visible = false;
            // 
            // buttonChangeProperties
            // 
            this.buttonChangeProperties.Enabled = false;
            this.buttonChangeProperties.Location = new System.Drawing.Point(122, 265);
            this.buttonChangeProperties.Name = "buttonChangeProperties";
            this.buttonChangeProperties.Size = new System.Drawing.Size(96, 59);
            this.buttonChangeProperties.TabIndex = 7;
            this.buttonChangeProperties.Text = "Изменить  пар-ры";
            this.buttonChangeProperties.UseVisualStyleBackColor = true;
            this.buttonChangeProperties.Click += new System.EventHandler(this.buttonChangeProperties_Click);
            // 
            // buttonStartAutomatic
            // 
            this.buttonStartAutomatic.Location = new System.Drawing.Point(6, 282);
            this.buttonStartAutomatic.Name = "buttonStartAutomatic";
            this.buttonStartAutomatic.Size = new System.Drawing.Size(80, 42);
            this.buttonStartAutomatic.TabIndex = 6;
            this.buttonStartAutomatic.Text = "Старт";
            this.buttonStartAutomatic.UseVisualStyleBackColor = true;
            this.buttonStartAutomatic.Click += new System.EventHandler(this.buttonStartAutomatic_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Расстояние до открытия";
            // 
            // numericUpDownBeforeOpen
            // 
            this.numericUpDownBeforeOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownBeforeOpen.Location = new System.Drawing.Point(6, 194);
            this.numericUpDownBeforeOpen.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownBeforeOpen.Name = "numericUpDownBeforeOpen";
            this.numericUpDownBeforeOpen.Size = new System.Drawing.Size(120, 24);
            this.numericUpDownBeforeOpen.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Расстояние до закрытия";
            // 
            // numericUpDownBeforeClose
            // 
            this.numericUpDownBeforeClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownBeforeClose.Location = new System.Drawing.Point(6, 141);
            this.numericUpDownBeforeClose.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numericUpDownBeforeClose.Name = "numericUpDownBeforeClose";
            this.numericUpDownBeforeClose.Size = new System.Drawing.Size(120, 24);
            this.numericUpDownBeforeClose.TabIndex = 2;
            // 
            // checkBoxMakeSoundSignal
            // 
            this.checkBoxMakeSoundSignal.AutoSize = true;
            this.checkBoxMakeSoundSignal.Location = new System.Drawing.Point(6, 87);
            this.checkBoxMakeSoundSignal.Name = "checkBoxMakeSoundSignal";
            this.checkBoxMakeSoundSignal.Size = new System.Drawing.Size(215, 24);
            this.checkBoxMakeSoundSignal.TabIndex = 1;
            this.checkBoxMakeSoundSignal.Text = "Подать звуковой сигнал";
            this.checkBoxMakeSoundSignal.UseVisualStyleBackColor = true;
            // 
            // checkBoxMakeLightSignal
            // 
            this.checkBoxMakeLightSignal.AutoSize = true;
            this.checkBoxMakeLightSignal.Location = new System.Drawing.Point(6, 57);
            this.checkBoxMakeLightSignal.Name = "checkBoxMakeLightSignal";
            this.checkBoxMakeLightSignal.Size = new System.Drawing.Size(218, 24);
            this.checkBoxMakeLightSignal.TabIndex = 0;
            this.checkBoxMakeLightSignal.Text = "Подать световой сигнал";
            this.checkBoxMakeLightSignal.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(251, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "Сменить режим";
            // 
            // buttonChangeMode
            // 
            this.buttonChangeMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChangeMode.Location = new System.Drawing.Point(255, 122);
            this.buttonChangeMode.Name = "buttonChangeMode";
            this.buttonChangeMode.Size = new System.Drawing.Size(91, 30);
            this.buttonChangeMode.TabIndex = 9;
            this.buttonChangeMode.Text = "Сменить";
            this.buttonChangeMode.UseVisualStyleBackColor = true;
            this.buttonChangeMode.Click += new System.EventHandler(this.buttonChangeMode_Click);
            // 
            // labelOpenPereezd
            // 
            this.labelOpenPereezd.AutoSize = true;
            this.labelOpenPereezd.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOpenPereezd.Location = new System.Drawing.Point(255, 155);
            this.labelOpenPereezd.Name = "labelOpenPereezd";
            this.labelOpenPereezd.Size = new System.Drawing.Size(151, 20);
            this.labelOpenPereezd.TabIndex = 12;
            this.labelOpenPereezd.Text = "Открыть переезд";
            // 
            // buttonOpenPereezd
            // 
            this.buttonOpenPereezd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpenPereezd.Location = new System.Drawing.Point(255, 178);
            this.buttonOpenPereezd.Name = "buttonOpenPereezd";
            this.buttonOpenPereezd.Size = new System.Drawing.Size(91, 30);
            this.buttonOpenPereezd.TabIndex = 11;
            this.buttonOpenPereezd.Text = "Открыть";
            this.buttonOpenPereezd.UseVisualStyleBackColor = true;
            this.buttonOpenPereezd.Click += new System.EventHandler(this.buttonOpenPereezd_Click);
            // 
            // labelClosePereezd
            // 
            this.labelClosePereezd.AutoSize = true;
            this.labelClosePereezd.Enabled = false;
            this.labelClosePereezd.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClosePereezd.Location = new System.Drawing.Point(255, 155);
            this.labelClosePereezd.Name = "labelClosePereezd";
            this.labelClosePereezd.Size = new System.Drawing.Size(151, 20);
            this.labelClosePereezd.TabIndex = 14;
            this.labelClosePereezd.Text = "Закрыть переезд";
            this.labelClosePereezd.Visible = false;
            // 
            // buttonClosePereezd
            // 
            this.buttonClosePereezd.Enabled = false;
            this.buttonClosePereezd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClosePereezd.Location = new System.Drawing.Point(256, 178);
            this.buttonClosePereezd.Name = "buttonClosePereezd";
            this.buttonClosePereezd.Size = new System.Drawing.Size(91, 30);
            this.buttonClosePereezd.TabIndex = 13;
            this.buttonClosePereezd.Text = "Закрыть";
            this.buttonClosePereezd.UseVisualStyleBackColor = true;
            this.buttonClosePereezd.Visible = false;
            this.buttonClosePereezd.Click += new System.EventHandler(this.buttonClosePereezd_Click);
            // 
            // ControlForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(402, 350);
            this.ControlBox = false;
            this.Controls.Add(this.labelClosePereezd);
            this.Controls.Add(this.buttonClosePereezd);
            this.Controls.Add(this.labelOpenPereezd);
            this.Controls.Add(this.buttonOpenPereezd);
            this.Controls.Add(this.groupBoxAuto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.buttonChangeMode);
            this.Controls.Add(this.buttonStartTrain);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBoxManual);
            this.Controls.Add(this.ButtonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControlForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.groupBoxManual.ResumeLayout(false);
            this.groupBoxManual.PerformLayout();
            this.groupBoxAuto.ResumeLayout(false);
            this.groupBoxAuto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeforeOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeforeClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.GroupBox groupBoxManual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonMakeSoundSignal;
        private System.Windows.Forms.Label labelOpenBarier;
        private System.Windows.Forms.Button buttonOpenBarier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonMakeLigthSignal;
        private System.Windows.Forms.Label labelCloseBarier;
        private System.Windows.Forms.Button buttonCloseBarier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonStartTrain;
        private System.Windows.Forms.GroupBox groupBoxAuto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonChangeMode;
        private System.Windows.Forms.Label labelOpenPereezd;
        private System.Windows.Forms.Button buttonOpenPereezd;
        private System.Windows.Forms.Label labelClosePereezd;
        private System.Windows.Forms.Button buttonClosePereezd;
        private System.Windows.Forms.Button buttonStartAutomatic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownBeforeOpen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownBeforeClose;
        private System.Windows.Forms.CheckBox checkBoxMakeSoundSignal;
        private System.Windows.Forms.CheckBox checkBoxMakeLightSignal;
        private System.Windows.Forms.Button buttonChangeProperties;
    }
}