namespace SIAODKurs
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabWind = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sortBut = new System.Windows.Forms.Button();
            this.tabAlg = new System.Windows.Forms.TabControl();
            this.tabOneAlg = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpor = new System.Windows.Forms.NumericUpDown();
            this.upChastCheck = new System.Windows.Forms.CheckBox();
            this.upPoUbCheck = new System.Windows.Forms.CheckBox();
            this.upPoVozrCheck = new System.Windows.Forms.CheckBox();
            this.notUpCheck = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.fibRad = new System.Windows.Forms.RadioButton();
            this.marzRad = new System.Windows.Forms.RadioButton();
            this.KnutRad = new System.Windows.Forms.RadioButton();
            this.VirtRad = new System.Windows.Forms.RadioButton();
            this.tabAllAlg = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.upChastRad = new System.Windows.Forms.RadioButton();
            this.upPoUbRad = new System.Windows.Forms.RadioButton();
            this.upPoVozrRad = new System.Windows.Forms.RadioButton();
            this.notUpRad = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panel5 = new System.Windows.Forms.Panel();
            this.fibCheck = new System.Windows.Forms.CheckBox();
            this.marzCheck = new System.Windows.Forms.CheckBox();
            this.knutCheck = new System.Windows.Forms.CheckBox();
            this.virtCheck = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.numericMn = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericT = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericN = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabWind.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabAlg.SuspendLayout();
            this.tabOneAlg.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpor)).BeginInit();
            this.panel4.SuspendLayout();
            this.tabAllAlg.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericN)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabWind
            // 
            this.tabWind.Controls.Add(this.tabPage1);
            this.tabWind.Controls.Add(this.tabPage2);
            this.tabWind.Location = new System.Drawing.Point(-1, 0);
            this.tabWind.Name = "tabWind";
            this.tabWind.SelectedIndex = 0;
            this.tabWind.Size = new System.Drawing.Size(844, 527);
            this.tabWind.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Controls.Add(this.sortBut);
            this.tabPage1.Controls.Add(this.tabAlg);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(836, 501);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Данные";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.AxisX.Title = "Кол-во элементов";
            chartArea1.AxisY.Title = "Время, мс";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(220, 10);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(596, 447);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            this.chart1.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // sortBut
            // 
            this.sortBut.Location = new System.Drawing.Point(136, 473);
            this.sortBut.Name = "sortBut";
            this.sortBut.Size = new System.Drawing.Size(81, 25);
            this.sortBut.TabIndex = 5;
            this.sortBut.Text = "Сортировать";
            this.sortBut.UseVisualStyleBackColor = true;
            this.sortBut.Click += new System.EventHandler(this.sortBut_Click);
            // 
            // tabAlg
            // 
            this.tabAlg.Controls.Add(this.tabOneAlg);
            this.tabAlg.Controls.Add(this.tabAllAlg);
            this.tabAlg.Location = new System.Drawing.Point(6, 180);
            this.tabAlg.Name = "tabAlg";
            this.tabAlg.SelectedIndex = 0;
            this.tabAlg.Size = new System.Drawing.Size(215, 293);
            this.tabAlg.TabIndex = 4;
            // 
            // tabOneAlg
            // 
            this.tabOneAlg.Controls.Add(this.panel3);
            this.tabOneAlg.Controls.Add(this.panel4);
            this.tabOneAlg.Location = new System.Drawing.Point(4, 22);
            this.tabOneAlg.Name = "tabOneAlg";
            this.tabOneAlg.Padding = new System.Windows.Forms.Padding(3);
            this.tabOneAlg.Size = new System.Drawing.Size(207, 267);
            this.tabOneAlg.TabIndex = 0;
            this.tabOneAlg.Text = "Один алгоритм";
            this.tabOneAlg.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.numericUpor);
            this.panel3.Controls.Add(this.upChastCheck);
            this.panel3.Controls.Add(this.upPoUbCheck);
            this.panel3.Controls.Add(this.upPoVozrCheck);
            this.panel3.Controls.Add(this.notUpCheck);
            this.panel3.Location = new System.Drawing.Point(6, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(198, 128);
            this.panel3.TabIndex = 2;
            this.panel3.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Упорядоченность массива";
            // 
            // numericUpor
            // 
            this.numericUpor.Location = new System.Drawing.Point(131, 84);
            this.numericUpor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpor.Name = "numericUpor";
            this.numericUpor.Size = new System.Drawing.Size(61, 20);
            this.numericUpor.TabIndex = 4;
            this.numericUpor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // upChastCheck
            // 
            this.upChastCheck.AutoSize = true;
            this.upChastCheck.ForeColor = System.Drawing.Color.DarkViolet;
            this.upChastCheck.Location = new System.Drawing.Point(3, 87);
            this.upChastCheck.Name = "upChastCheck";
            this.upChastCheck.Size = new System.Drawing.Size(122, 17);
            this.upChastCheck.TabIndex = 3;
            this.upChastCheck.Text = "Упорядочен на (%):";
            this.upChastCheck.UseVisualStyleBackColor = true;
            // 
            // upPoUbCheck
            // 
            this.upPoUbCheck.AutoSize = true;
            this.upPoUbCheck.ForeColor = System.Drawing.Color.OrangeRed;
            this.upPoUbCheck.Location = new System.Drawing.Point(3, 64);
            this.upPoUbCheck.Name = "upPoUbCheck";
            this.upPoUbCheck.Size = new System.Drawing.Size(156, 17);
            this.upPoUbCheck.TabIndex = 2;
            this.upPoUbCheck.Text = "Упорядочен по убыванию";
            this.upPoUbCheck.UseVisualStyleBackColor = true;
            // 
            // upPoVozrCheck
            // 
            this.upPoVozrCheck.AutoSize = true;
            this.upPoVozrCheck.ForeColor = System.Drawing.Color.Red;
            this.upPoVozrCheck.Location = new System.Drawing.Point(3, 41);
            this.upPoVozrCheck.Name = "upPoVozrCheck";
            this.upPoVozrCheck.Size = new System.Drawing.Size(172, 17);
            this.upPoVozrCheck.TabIndex = 1;
            this.upPoVozrCheck.Text = "Упорядочен по возрастанию";
            this.upPoVozrCheck.UseVisualStyleBackColor = true;
            // 
            // notUpCheck
            // 
            this.notUpCheck.AutoSize = true;
            this.notUpCheck.ForeColor = System.Drawing.Color.Navy;
            this.notUpCheck.Location = new System.Drawing.Point(3, 18);
            this.notUpCheck.Name = "notUpCheck";
            this.notUpCheck.Size = new System.Drawing.Size(101, 17);
            this.notUpCheck.TabIndex = 0;
            this.notUpCheck.Text = "Не упорядочен";
            this.notUpCheck.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.fibRad);
            this.panel4.Controls.Add(this.marzRad);
            this.panel4.Controls.Add(this.KnutRad);
            this.panel4.Controls.Add(this.VirtRad);
            this.panel4.Location = new System.Drawing.Point(6, 132);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(198, 128);
            this.panel4.TabIndex = 3;
            // 
            // fibRad
            // 
            this.fibRad.AutoSize = true;
            this.fibRad.Location = new System.Drawing.Point(3, 73);
            this.fibRad.Name = "fibRad";
            this.fibRad.Size = new System.Drawing.Size(183, 43);
            this.fibRad.TabIndex = 3;
            this.fibRad.TabStop = true;
            this.fibRad.Text = "Эмпирическая \r\nпоследовательность на числах\r\nФибоначчи";
            this.fibRad.UseVisualStyleBackColor = true;
            // 
            // marzRad
            // 
            this.marzRad.AutoSize = true;
            this.marzRad.Location = new System.Drawing.Point(3, 50);
            this.marzRad.Name = "marzRad";
            this.marzRad.Size = new System.Drawing.Size(156, 17);
            this.marzRad.TabIndex = 2;
            this.marzRad.TabStop = true;
            this.marzRad.Text = "Алгоритм Марцина Циура";
            this.marzRad.UseVisualStyleBackColor = true;
            // 
            // KnutRad
            // 
            this.KnutRad.AutoSize = true;
            this.KnutRad.Location = new System.Drawing.Point(3, 27);
            this.KnutRad.Name = "KnutRad";
            this.KnutRad.Size = new System.Drawing.Size(106, 17);
            this.KnutRad.TabIndex = 1;
            this.KnutRad.TabStop = true;
            this.KnutRad.Text = "Алгоритм Кнута";
            this.KnutRad.UseVisualStyleBackColor = true;
            // 
            // VirtRad
            // 
            this.VirtRad.AutoSize = true;
            this.VirtRad.Location = new System.Drawing.Point(3, 4);
            this.VirtRad.Name = "VirtRad";
            this.VirtRad.Size = new System.Drawing.Size(107, 17);
            this.VirtRad.TabIndex = 0;
            this.VirtRad.TabStop = true;
            this.VirtRad.Text = "Алгоритм Вирта";
            this.VirtRad.UseVisualStyleBackColor = true;
            // 
            // tabAllAlg
            // 
            this.tabAllAlg.Controls.Add(this.panel2);
            this.tabAllAlg.Controls.Add(this.panel5);
            this.tabAllAlg.Location = new System.Drawing.Point(4, 22);
            this.tabAllAlg.Name = "tabAllAlg";
            this.tabAllAlg.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllAlg.Size = new System.Drawing.Size(207, 267);
            this.tabAllAlg.TabIndex = 1;
            this.tabAllAlg.Text = "Все алгоритмы";
            this.tabAllAlg.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.upChastRad);
            this.panel2.Controls.Add(this.upPoUbRad);
            this.panel2.Controls.Add(this.upPoVozrRad);
            this.panel2.Controls.Add(this.notUpRad);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Location = new System.Drawing.Point(6, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 128);
            this.panel2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Упорядоченность массива";
            // 
            // upChastRad
            // 
            this.upChastRad.AutoSize = true;
            this.upChastRad.Location = new System.Drawing.Point(4, 87);
            this.upChastRad.Name = "upChastRad";
            this.upChastRad.Size = new System.Drawing.Size(121, 17);
            this.upChastRad.TabIndex = 8;
            this.upChastRad.TabStop = true;
            this.upChastRad.Text = "Упорядочен на (%):";
            this.upChastRad.UseVisualStyleBackColor = true;
            // 
            // upPoUbRad
            // 
            this.upPoUbRad.AutoSize = true;
            this.upPoUbRad.Location = new System.Drawing.Point(4, 64);
            this.upPoUbRad.Name = "upPoUbRad";
            this.upPoUbRad.Size = new System.Drawing.Size(155, 17);
            this.upPoUbRad.TabIndex = 7;
            this.upPoUbRad.TabStop = true;
            this.upPoUbRad.Text = "Упорядочен по убыванию";
            this.upPoUbRad.UseVisualStyleBackColor = true;
            // 
            // upPoVozrRad
            // 
            this.upPoVozrRad.AutoSize = true;
            this.upPoVozrRad.Location = new System.Drawing.Point(4, 41);
            this.upPoVozrRad.Name = "upPoVozrRad";
            this.upPoVozrRad.Size = new System.Drawing.Size(171, 17);
            this.upPoVozrRad.TabIndex = 6;
            this.upPoVozrRad.TabStop = true;
            this.upPoVozrRad.Text = "Упорядочен по возрастанию";
            this.upPoVozrRad.UseVisualStyleBackColor = true;
            // 
            // notUpRad
            // 
            this.notUpRad.AutoSize = true;
            this.notUpRad.Location = new System.Drawing.Point(4, 18);
            this.notUpRad.Name = "notUpRad";
            this.notUpRad.Size = new System.Drawing.Size(100, 17);
            this.notUpRad.TabIndex = 5;
            this.notUpRad.TabStop = true;
            this.notUpRad.Text = "Не упорядочен";
            this.notUpRad.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(131, 84);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.fibCheck);
            this.panel5.Controls.Add(this.marzCheck);
            this.panel5.Controls.Add(this.knutCheck);
            this.panel5.Controls.Add(this.virtCheck);
            this.panel5.Location = new System.Drawing.Point(6, 132);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(198, 128);
            this.panel5.TabIndex = 5;
            // 
            // fibCheck
            // 
            this.fibCheck.AutoSize = true;
            this.fibCheck.ForeColor = System.Drawing.Color.DarkViolet;
            this.fibCheck.Location = new System.Drawing.Point(3, 73);
            this.fibCheck.Name = "fibCheck";
            this.fibCheck.Size = new System.Drawing.Size(184, 56);
            this.fibCheck.TabIndex = 3;
            this.fibCheck.Text = "Эмпирическая \r\nпоследовательность на числах\r\nФибоначчи\r\n\r\n";
            this.fibCheck.UseVisualStyleBackColor = true;
            // 
            // marzCheck
            // 
            this.marzCheck.AutoSize = true;
            this.marzCheck.ForeColor = System.Drawing.Color.OrangeRed;
            this.marzCheck.Location = new System.Drawing.Point(2, 50);
            this.marzCheck.Name = "marzCheck";
            this.marzCheck.Size = new System.Drawing.Size(157, 17);
            this.marzCheck.TabIndex = 2;
            this.marzCheck.Text = "Алгоритм Марцина Циура";
            this.marzCheck.UseVisualStyleBackColor = true;
            // 
            // knutCheck
            // 
            this.knutCheck.AutoSize = true;
            this.knutCheck.ForeColor = System.Drawing.Color.Red;
            this.knutCheck.Location = new System.Drawing.Point(3, 27);
            this.knutCheck.Name = "knutCheck";
            this.knutCheck.Size = new System.Drawing.Size(107, 17);
            this.knutCheck.TabIndex = 1;
            this.knutCheck.Text = "Алгоритм Кнута";
            this.knutCheck.UseVisualStyleBackColor = true;
            // 
            // virtCheck
            // 
            this.virtCheck.AutoSize = true;
            this.virtCheck.ForeColor = System.Drawing.Color.Navy;
            this.virtCheck.Location = new System.Drawing.Point(3, 4);
            this.virtCheck.Name = "virtCheck";
            this.virtCheck.Size = new System.Drawing.Size(102, 17);
            this.virtCheck.TabIndex = 0;
            this.virtCheck.Text = "Алгоитм Вирта";
            this.virtCheck.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.numericMn);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.numericT);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericN);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 171);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(18, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "х";
            // 
            // numericMn
            // 
            this.numericMn.Location = new System.Drawing.Point(34, 146);
            this.numericMn.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericMn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMn.Name = "numericMn";
            this.numericMn.Size = new System.Drawing.Size(167, 20);
            this.numericMn.TabIndex = 5;
            this.numericMn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(-1, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Множитель:";
            // 
            // numericT
            // 
            this.numericT.Location = new System.Drawing.Point(3, 90);
            this.numericT.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericT.Name = "numericT";
            this.numericT.Size = new System.Drawing.Size(198, 20);
            this.numericT.TabIndex = 3;
            this.numericT.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(-1, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Количество точек:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(-1, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Количество элементов:";
            // 
            // numericN
            // 
            this.numericN.Location = new System.Drawing.Point(3, 36);
            this.numericN.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericN.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericN.Name = "numericN";
            this.numericN.Size = new System.Drawing.Size(198, 20);
            this.numericN.TabIndex = 0;
            this.numericN.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(836, 501);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Результат";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(327, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 24);
            this.label5.TabIndex = 1;
            this.label5.Text = "Сортировка";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(88, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(683, 465);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(843, 529);
            this.Controls.Add(this.tabWind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Метод Шелла";
            this.tabWind.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabAlg.ResumeLayout(false);
            this.tabOneAlg.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpor)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabAllAlg.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericN)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabWind;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button sortBut;
        private System.Windows.Forms.TabControl tabAlg;
        private System.Windows.Forms.TabPage tabOneAlg;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpor;
        private System.Windows.Forms.CheckBox upChastCheck;
        private System.Windows.Forms.CheckBox upPoUbCheck;
        private System.Windows.Forms.CheckBox upPoVozrCheck;
        private System.Windows.Forms.CheckBox notUpCheck;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton fibRad;
        private System.Windows.Forms.RadioButton marzRad;
        private System.Windows.Forms.RadioButton KnutRad;
        private System.Windows.Forms.RadioButton VirtRad;
        private System.Windows.Forms.TabPage tabAllAlg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton upChastRad;
        private System.Windows.Forms.RadioButton upPoUbRad;
        private System.Windows.Forms.RadioButton upPoVozrRad;
        private System.Windows.Forms.RadioButton notUpRad;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox fibCheck;
        private System.Windows.Forms.CheckBox marzCheck;
        private System.Windows.Forms.CheckBox knutCheck;
        private System.Windows.Forms.CheckBox virtCheck;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericMn;
        private System.Windows.Forms.Label label6;
    }
}

