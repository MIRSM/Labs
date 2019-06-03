namespace HMIWindowsForm
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpenControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxTrain = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelBarier = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelLight = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDist = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTrain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenControlToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OpenControlToolStripMenuItem
            // 
            this.OpenControlToolStripMenuItem.Name = "OpenControlToolStripMenuItem";
            this.OpenControlToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.OpenControlToolStripMenuItem.Text = "Управление";
            this.OpenControlToolStripMenuItem.Click += new System.EventHandler(this.OpenControlToolStripMenuItem_Click);
            // 
            // pictureBoxTrain
            // 
            this.pictureBoxTrain.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTrain.Image")));
            this.pictureBoxTrain.Location = new System.Drawing.Point(600, 144);
            this.pictureBoxTrain.Name = "pictureBoxTrain";
            this.pictureBoxTrain.Size = new System.Drawing.Size(200, 138);
            this.pictureBoxTrain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxTrain.TabIndex = 1;
            this.pictureBoxTrain.TabStop = false;
            this.pictureBoxTrain.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Location = new System.Drawing.Point(132, 302);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(26, 100);
            this.panel1.TabIndex = 2;
            // 
            // panelBarier
            // 
            this.panelBarier.BackColor = System.Drawing.Color.Red;
            this.panelBarier.Location = new System.Drawing.Point(132, 302);
            this.panelBarier.Name = "panelBarier";
            this.panelBarier.Size = new System.Drawing.Size(270, 26);
            this.panelBarier.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Location = new System.Drawing.Point(517, 343);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 59);
            this.panel2.TabIndex = 3;
            // 
            // panelLight
            // 
            this.panelLight.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelLight.Location = new System.Drawing.Point(499, 302);
            this.panelLight.Name = "panelLight";
            this.panelLight.Size = new System.Drawing.Size(50, 50);
            this.panelLight.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Расстояние от поезда до переезда:";
            // 
            // labelDist
            // 
            this.labelDist.AutoSize = true;
            this.labelDist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDist.Location = new System.Drawing.Point(302, 24);
            this.labelDist.Name = "labelDist";
            this.labelDist.Size = new System.Drawing.Size(191, 20);
            this.labelDist.TabIndex = 6;
            this.labelDist.Text = "поезд не приближается";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelDist);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelLight);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelBarier);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxTrain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Управление ж\\д переездом";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTrain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenControlToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panelBarier;
        public System.Windows.Forms.PictureBox pictureBoxTrain;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panelLight;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelDist;
    }
}

