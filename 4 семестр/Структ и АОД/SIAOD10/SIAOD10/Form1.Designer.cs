namespace SIAOD10
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericOP = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericKol = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkAbsor = new System.Windows.Forms.CheckBox();
            this.checkInternal = new System.Windows.Forms.CheckBox();
            this.checkTwoPhaseNatural = new System.Windows.Forms.CheckBox();
            this.checkOnePhaseNatural = new System.Windows.Forms.CheckBox();
            this.checkTwoPhaseSimple = new System.Windows.Forms.CheckBox();
            this.checkOnePhaseSimple = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.numericT = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericKol)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericT)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.numericT);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.numericOP);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numericKol);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 151);
            this.panel1.TabIndex = 0;
            // 
            // numericOP
            // 
            this.numericOP.Location = new System.Drawing.Point(6, 70);
            this.numericOP.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericOP.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericOP.Name = "numericOP";
            this.numericOP.Size = new System.Drawing.Size(205, 20);
            this.numericOP.TabIndex = 3;
            this.numericOP.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Размер ОП, %";
            // 
            // numericKol
            // 
            this.numericKol.Location = new System.Drawing.Point(6, 28);
            this.numericKol.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericKol.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericKol.Name = "numericKol";
            this.numericKol.Size = new System.Drawing.Size(205, 20);
            this.numericKol.TabIndex = 1;
            this.numericKol.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Кол-во элементов в файле";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.checkAbsor);
            this.panel2.Controls.Add(this.checkInternal);
            this.panel2.Controls.Add(this.checkTwoPhaseNatural);
            this.panel2.Controls.Add(this.checkOnePhaseNatural);
            this.panel2.Controls.Add(this.checkTwoPhaseSimple);
            this.panel2.Controls.Add(this.checkOnePhaseSimple);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(12, 169);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 266);
            this.panel2.TabIndex = 1;
            // 
            // checkAbsor
            // 
            this.checkAbsor.AutoSize = true;
            this.checkAbsor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkAbsor.ForeColor = System.Drawing.Color.Magenta;
            this.checkAbsor.Location = new System.Drawing.Point(6, 229);
            this.checkAbsor.Name = "checkAbsor";
            this.checkAbsor.Size = new System.Drawing.Size(166, 36);
            this.checkAbsor.TabIndex = 6;
            this.checkAbsor.Text = "Сортировка методом\r\nпоглощения";
            this.checkAbsor.UseVisualStyleBackColor = true;
            // 
            // checkInternal
            // 
            this.checkInternal.AutoSize = true;
            this.checkInternal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkInternal.ForeColor = System.Drawing.Color.Blue;
            this.checkInternal.Location = new System.Drawing.Point(6, 187);
            this.checkInternal.Name = "checkInternal";
            this.checkInternal.Size = new System.Drawing.Size(195, 36);
            this.checkInternal.TabIndex = 5;
            this.checkInternal.Text = "Внутренняя сортировка с\r\nвнешним слиянием";
            this.checkInternal.UseVisualStyleBackColor = true;
            // 
            // checkTwoPhaseNatural
            // 
            this.checkTwoPhaseNatural.AutoSize = true;
            this.checkTwoPhaseNatural.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkTwoPhaseNatural.ForeColor = System.Drawing.Color.Turquoise;
            this.checkTwoPhaseNatural.Location = new System.Drawing.Point(6, 145);
            this.checkTwoPhaseNatural.Name = "checkTwoPhaseNatural";
            this.checkTwoPhaseNatural.Size = new System.Drawing.Size(188, 36);
            this.checkTwoPhaseNatural.TabIndex = 4;
            this.checkTwoPhaseNatural.Text = "Двухфазная сортировка\r\nестесвенным слиянием";
            this.checkTwoPhaseNatural.UseVisualStyleBackColor = true;
            // 
            // checkOnePhaseNatural
            // 
            this.checkOnePhaseNatural.AutoSize = true;
            this.checkOnePhaseNatural.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkOnePhaseNatural.ForeColor = System.Drawing.Color.Lime;
            this.checkOnePhaseNatural.Location = new System.Drawing.Point(6, 103);
            this.checkOnePhaseNatural.Name = "checkOnePhaseNatural";
            this.checkOnePhaseNatural.Size = new System.Drawing.Size(191, 36);
            this.checkOnePhaseNatural.TabIndex = 3;
            this.checkOnePhaseNatural.Text = "Однофазная сортировка\r\nестесвенным слиянием";
            this.checkOnePhaseNatural.UseVisualStyleBackColor = true;
            // 
            // checkTwoPhaseSimple
            // 
            this.checkTwoPhaseSimple.AutoSize = true;
            this.checkTwoPhaseSimple.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkTwoPhaseSimple.ForeColor = System.Drawing.Color.YellowGreen;
            this.checkTwoPhaseSimple.Location = new System.Drawing.Point(6, 61);
            this.checkTwoPhaseSimple.Name = "checkTwoPhaseSimple";
            this.checkTwoPhaseSimple.Size = new System.Drawing.Size(188, 36);
            this.checkTwoPhaseSimple.TabIndex = 2;
            this.checkTwoPhaseSimple.Text = "Двухфазная сортировка\r\nпростым слиянием";
            this.checkTwoPhaseSimple.UseVisualStyleBackColor = true;
            // 
            // checkOnePhaseSimple
            // 
            this.checkOnePhaseSimple.AutoSize = true;
            this.checkOnePhaseSimple.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkOnePhaseSimple.ForeColor = System.Drawing.Color.Red;
            this.checkOnePhaseSimple.Location = new System.Drawing.Point(6, 19);
            this.checkOnePhaseSimple.Name = "checkOnePhaseSimple";
            this.checkOnePhaseSimple.Size = new System.Drawing.Size(191, 36);
            this.checkOnePhaseSimple.TabIndex = 1;
            this.checkOnePhaseSimple.Text = "Однофазная сортировка\r\nпростым слиянием";
            this.checkOnePhaseSimple.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(22, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Выберите сортировки";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 441);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "Вывести таблицу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(131, 441);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 48);
            this.button2.TabIndex = 3;
            this.button2.Text = "Нарисовать график";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(255, 292);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(683, 190);
            this.dataGridView1.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Вид сортировки";
            this.Column1.Name = "Column1";
            this.Column1.Width = 260;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Время";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Кол-во чтений";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Кол-во записей";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Кол-во сравнений";
            this.Column5.Name = "Column5";
            this.Column5.Width = 80;
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(255, 12);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Name = "двухфазная сортировка простым слиянием";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Name = "однофазная сортировка простым слиянием";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Name = "двухфазная сортировка естественным слиянием";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Name = "однофазная сортировка естественным слиянием";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Name = "внутренняя сортировка с внешним слиянием";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Name = "сортировка методом поглощения";
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Series.Add(series9);
            this.chart1.Series.Add(series10);
            this.chart1.Series.Add(series11);
            this.chart1.Series.Add(series12);
            this.chart1.Size = new System.Drawing.Size(683, 255);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Множитель";
            // 
            // numericT
            // 
            this.numericT.Location = new System.Drawing.Point(3, 112);
            this.numericT.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericT.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericT.Name = "numericT";
            this.numericT.Size = new System.Drawing.Size(205, 20);
            this.numericT.TabIndex = 5;
            this.numericT.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(951, 494);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Лабораторная работа 10";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericKol)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericOP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericKol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkAbsor;
        private System.Windows.Forms.CheckBox checkInternal;
        private System.Windows.Forms.CheckBox checkTwoPhaseNatural;
        private System.Windows.Forms.CheckBox checkOnePhaseNatural;
        private System.Windows.Forms.CheckBox checkTwoPhaseSimple;
        private System.Windows.Forms.CheckBox checkOnePhaseSimple;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.NumericUpDown numericT;
        private System.Windows.Forms.Label label4;
    }
}

