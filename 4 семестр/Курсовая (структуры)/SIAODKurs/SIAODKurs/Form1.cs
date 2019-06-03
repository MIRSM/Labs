using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SIAODKurs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            notUpCheck.Checked = true;
            notUpRad.Checked = true;
            virtCheck.Checked = true;
            VirtRad.Checked = true;
        }

        /// <summary>
        /// Создание неупорядоченного массива
        /// </summary>
        /// <param name="notUpMass">Массив</param>
        /// <param name="N">Размер массив</param>
        public void CreateNotUpMass(ref int[] notUpMass, int N)
        {
            Random r = new Random();
            for (int i = 1; i < N; i++) notUpMass[i] = r.Next(0, N);
        }

        /// <summary>
        /// Создание массива, упорядоченного по возрастанию 
        /// </summary>
        /// <param name="upPoVozrMass">Массив</param>
        /// <param name="N">Размер массива</param>
        public void CreateUpPoVozrMass(ref int[] upPoVozrMass, int N)
        {
            Random r = new Random();
            upPoVozrMass[1] = r.Next(1, 100);
            for (int i = 2; i < N; i++) upPoVozrMass[i] = upPoVozrMass[i - 1] + r.Next(1, 100);
        }

        /// <summary>
        /// Создание массива, упорядоченного по убыванию
        /// </summary>
        /// <param name="upPoUbMass">Массив</param>
        /// <param name="N">Размер</param>
        public void CreateUpPoUbMass(ref int[] upPoUbMass, int N)
        {
            Random r = new Random();
            upPoUbMass[1] = N;
            for (int i = 2; i < N; i++) upPoUbMass[i] = upPoUbMass[i - 1] - r.Next(1, 100);
        }

        /// <summary>
        /// Создание частично упорядоченного массива
        /// </summary>
        /// <param name="chastUpMass">Массив</param>
        /// <param name="N">Размер</param>
        /// <param name="T">Процент упорядоченности</param>
        public void CreateChastUpMass(ref int[] chastUpMass, int N, float T)
        {
            int kolUp = (int)(N * T);
            int curKolUp = 0;
            Random r = new Random();
            chastUpMass[1] = r.Next(1, 100);

            for (int i = 2; i < N; i++)
            {
                if (curKolUp < kolUp)
                {
                    chastUpMass[i] = chastUpMass[i - 1] + r.Next(1, 100);
                    curKolUp++;
                }
                else chastUpMass[i] = r.Next(1, N);
            }

        }

        /// <summary>
        /// Формирование таблицы для разных массивов
        /// </summary>
        public void OneAlgSetUpGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 3;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].HeaderText = "Упорядоченность массива";
            dataGridView1.Columns[1].HeaderText = "Время";
            dataGridView1.Columns[2].HeaderText = "Кол-во элементов";
        }

        /// <summary>
        /// Формирование таблицы для разных алгоритмов
        /// </summary>
        public void AllAlgSetUpGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 3;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].HeaderText = "Алгоритм";
            dataGridView1.Columns[1].HeaderText = "Время";
            dataGridView1.Columns[2].HeaderText = "Кол-во элементов";

        }

        private void sortBut_Click(object sender, EventArgs e)
        {
            int N = Convert.ToInt32(numericN.Value);
            int P = Convert.ToInt32(numericT.Value);
            int M = Convert.ToInt32(numericMn.Value);
            int del = N / P;
            float max = 0;

            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Minimum = del;
            chart1.ChartAreas[0].AxisX.Maximum = N;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = N * 2;

            Series sFirst = new Series("NotUp")
            {
                ChartType = SeriesChartType.Line,
                ChartArea = "ChartArea1",
                Color = System.Drawing.Color.Navy
            };

            Series sSecond = new Series("UpPoVozr")
            {
                ChartType = SeriesChartType.Line,
                ChartArea = "ChartArea1",
                Color = System.Drawing.Color.Red
            };

            Series sThird = new Series("UpPoUb")
            {
                ChartType = SeriesChartType.Line,
                ChartArea = "ChartArea1",
                Color = System.Drawing.Color.OrangeRed
            };

            Series sFourth = new Series("UpChast")
            {
                ChartType = SeriesChartType.Line,
                ChartArea = "ChartArea1",
                Color = System.Drawing.Color.DarkViolet
            };

            if (tabAlg.SelectedTab == tabOneAlg)
            {
                int[] notUpMass = new int[N];
                int[] upPoVozrMass = new int[N];
                int[] upPoUbMass = new int[N];
                int[] chastUpMass = new int[N];
                int rownumb = -1;

                OneAlgSetUpGrid();

                if (VirtRad.Checked)
                {
                    VirtAlgSort virtAlg = new VirtAlgSort();

                    label5.Text = "Алгоритм Вирта";

                    if (notUpCheck.Checked)
                    {
                        CreateNotUpMass(ref notUpMass, N);
                        int element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = notUpMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += virtAlg.Sort(mas, element, P);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }
                            dataGridView1.Rows.Add("Не упорядочен", time, element);
                            rownumb++;

                            sFirst.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sFirst);
                    }

                    if (upPoVozrCheck.Checked)
                    {
                        CreateUpPoVozrMass(ref upPoVozrMass, N);

                        int element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = upPoVozrMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += virtAlg.Sort(mas, element, P);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Упорядочен по возрастанию", time, element);
                            rownumb++;

                            sSecond.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sSecond);
                    }

                    if (upPoUbCheck.Checked)
                    {
                        CreateUpPoUbMass(ref upPoUbMass, N);

                        int element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = upPoUbMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += virtAlg.Sort(mas, element, P);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Упорядочен по убыванию", time, element);
                            rownumb++;

                            sThird.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sThird);
                    }

                    if (upChastCheck.Checked)
                    {
                        float T = (float)(Convert.ToInt32(numericUpor.Value) / 100);
                        CreateChastUpMass(ref chastUpMass, N, T);

                        int element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = chastUpMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += virtAlg.Sort(mas, element, P);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Частично упорядочен", time, element);
                            rownumb++;

                            sFourth.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sFourth);
                    }
                }

                if (KnutRad.Checked)
                {
                    KnutAlgSort knutAlg = new KnutAlgSort();

                    label5.Text = "Алгоритм Кнута";

                    if (notUpCheck.Checked)
                    {
                        CreateNotUpMass(ref notUpMass, N);

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = notUpMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += knutAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Не упорядочен", time, element);
                            rownumb++;

                            sFirst.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sFirst);
                    }

                    if (upPoVozrCheck.Checked)
                    {
                        CreateUpPoVozrMass(ref upPoVozrMass, N);

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = upPoVozrMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += knutAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Упорядочен по возрастанию", time, element);
                            rownumb++;

                            sSecond.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sSecond);
                    }

                    if (upPoUbCheck.Checked)
                    {
                        CreateUpPoUbMass(ref upPoUbMass, N);

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = upPoUbMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += knutAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Упорядочен по убыванию", time, element);
                            rownumb++;

                            sThird.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sThird);
                    }

                    if (upChastCheck.Checked)
                    {
                        float T = (float)(Convert.ToInt32(numericUpor.Value) / 100);
                        CreateChastUpMass(ref chastUpMass, N, T);

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = chastUpMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += knutAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Частично упорядочен", time, element);
                            rownumb++;

                            sFourth.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sFourth);
                    }
                }

                if (marzRad.Checked)
                {
                    MarzAlgSort marzAlg = new MarzAlgSort();

                    label5.Text = "Алгоритм Марцина";

                    if (notUpCheck.Checked)
                    {
                        CreateNotUpMass(ref notUpMass, N);

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = notUpMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += marzAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Не упорядочен", time, element);
                            rownumb++;

                            sFirst.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sFirst);
                    }

                    if (upPoVozrCheck.Checked)
                    {
                        CreateUpPoVozrMass(ref upPoVozrMass, N);
                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = upPoVozrMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += marzAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Упорядочен по возрастанию", time, element);
                            rownumb++;

                            sSecond.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sSecond);
                    }

                    if (upPoUbCheck.Checked)
                    {
                        CreateUpPoUbMass(ref upPoUbMass, N);

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = upPoUbMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += marzAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Упорядочен по убыванию", time, element);
                            rownumb++;

                            sThird.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sThird);
                    }

                    if (upChastCheck.Checked)
                    {
                        float T = (float)(Convert.ToInt32(numericUpor.Value) / 100);
                        CreateChastUpMass(ref chastUpMass, N, T);

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = chastUpMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += marzAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Частично упорядочен", time, element);
                            rownumb++;

                            sFourth.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sFourth);
                    }
                }

                if (fibRad.Checked)
                {
                    FibAlgSort fibAlg = new FibAlgSort();

                    label5.Text = "Алгоритм на числах Фибоначчи";

                    if (notUpCheck.Checked)
                    {
                        CreateNotUpMass(ref notUpMass, N);

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = notUpMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += fibAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Не упорядочен", time, element);
                            rownumb++;

                            sFirst.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                            rownumb++;
                        }
                        chart1.Series.Add(sFirst);
                    }

                    if (upPoVozrCheck.Checked)
                    {
                        CreateUpPoVozrMass(ref upPoVozrMass, N);

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = upPoVozrMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += fibAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Упорядочен по возрастанию", time, element);
                            rownumb++;

                            sSecond.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sSecond);
                    }

                    if (upPoUbCheck.Checked)
                    {
                        CreateUpPoUbMass(ref upPoUbMass, N);

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = upPoUbMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += fibAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Упорядочен по убыванию", time, element);
                            rownumb++;

                            sThird.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sThird);
                    }

                    if (upChastCheck.Checked)
                    {
                        float T = (float)(Convert.ToInt32(numericUpor.Value) / 100);
                        CreateChastUpMass(ref chastUpMass, N, T);

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = chastUpMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += fibAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Частично упорядочен", time, element);
                            rownumb++;

                            sFourth.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sFourth);
                    }
                }
            }
            else
            {
                AllAlgSetUpGrid();
                int rownumb = -1;

                if (notUpRad.Checked)
                {
                    int[] notUpMass = new int[N];
                    CreateNotUpMass(ref notUpMass, N);

                    label5.Text = "Не упорядоченный массив";

                    if (virtCheck.Checked)
                    {
                        VirtAlgSort virtAlg = new VirtAlgSort();

                        int element = del;

                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = notUpMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += virtAlg.Sort(mas, element, P);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Алгоритм Вирта", time, element);
                            rownumb++;

                            sFirst.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }

                        chart1.Series.Add(sFirst);
                    }

                    if (knutCheck.Checked)
                    {
                        KnutAlgSort knutAlg = new KnutAlgSort();

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = notUpMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += knutAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Алгоритм Кнута", time, element);
                            rownumb++;

                            sSecond.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sSecond);
                    }

                    if (marzCheck.Checked)
                    {
                        MarzAlgSort marzAlg = new MarzAlgSort();

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = notUpMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += marzAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Алгоритм Марцина", time, element);
                            rownumb++;

                            sThird.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sThird);
                    }

                    if (fibCheck.Checked)
                    {
                        FibAlgSort fibAlg = new FibAlgSort();


                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = notUpMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += fibAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Эмпирическая последовательность на числах Фибоначчи", time, element);
                            rownumb++;

                            sFourth.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                            rownumb++;
                        }
                        chart1.Series.Add(sFourth);
                    }
                }

                if (upPoVozrRad.Checked)
                {
                    int[] upPoVozrMass = new int[N];
                    CreateUpPoVozrMass(ref upPoVozrMass, N);

                    label5.Text = "Упорядоченный по возрастанию массив";
                    if (virtCheck.Checked)
                    {
                        VirtAlgSort virtAlg = new VirtAlgSort();

                        int element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = upPoVozrMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += virtAlg.Sort(mas, element, P);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Алгоритм Вирта", time, element);
                            rownumb++;

                            sFirst.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sFirst);
                    }

                    if (knutCheck.Checked)
                    {
                        KnutAlgSort knutAlg = new KnutAlgSort();

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = upPoVozrMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += knutAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Упорядочен по возрастанию", time, element);
                            rownumb++;

                            sSecond.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sSecond);
                    }

                    if (marzCheck.Checked)
                    {
                        MarzAlgSort marzAlg = new MarzAlgSort();

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = upPoVozrMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += marzAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Алгоритм Марцина", time, element);
                            rownumb++;

                            sThird.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sThird);
                    }

                    if (fibCheck.Checked)
                    {
                        FibAlgSort fibAlg = new FibAlgSort();

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = upPoVozrMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += fibAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Эмпирическая последовательность на числах Фибоначчи", time, element);
                            rownumb++;

                            sFourth.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sFourth);
                    }
                }

                if (upPoUbRad.Checked)
                {
                    int[] upPoUbMass = new int[N];
                    CreateUpPoUbMass(ref upPoUbMass, N);
                    label5.Text = "Упорядоченный по убыванию массив";

                    if (virtCheck.Checked)
                    {
                        VirtAlgSort virtAlg = new VirtAlgSort();
                        int element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = upPoUbMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += virtAlg.Sort(mas, element, P);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Алгоритм Вирта", time, element);
                            rownumb++;

                            sFirst.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sFirst);
                    }

                    if (knutCheck.Checked)
                    {
                        KnutAlgSort knutAlg = new KnutAlgSort();
                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = upPoUbMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += knutAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Алгоритм Кнута", time, element);
                            rownumb++;

                            sSecond.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sSecond);
                    }

                    if (marzCheck.Checked)
                    {
                        MarzAlgSort marzAlg = new MarzAlgSort();
                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = upPoUbMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += marzAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Алгоритм Марцина", time, element);
                            rownumb++;

                            sThird.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sThird);
                    }

                    if (fibCheck.Checked)
                    {
                        FibAlgSort fibAlg = new FibAlgSort();
                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = upPoUbMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += fibAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Эмпирическая последовательность на числах Фибоначчи", time, element);
                            rownumb++;

                            sFourth.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sFourth);
                    }
                }

                if (upChastRad.Checked)
                {
                    int[] chastUpMass = new int[N];
                    float T = (float)(Convert.ToInt32(numericUpor.Value) / 100);
                    CreateChastUpMass(ref chastUpMass, N, T);
                    label5.Text = "Частично упорядоченный массив";

                    if (virtCheck.Checked)
                    {
                        VirtAlgSort virtAlg = new VirtAlgSort();

                        int element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = chastUpMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += virtAlg.Sort(mas, element, P);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Алгоритм Вирта", time, element);
                            rownumb++;

                            sFirst.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sFirst);
                    }

                    if (knutCheck.Checked)
                    {
                        KnutAlgSort knutAlg = new KnutAlgSort();
                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = chastUpMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += knutAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Алгоритм Кнута", time, element);
                            rownumb++;

                            sSecond.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sSecond);
                    }

                    if (marzCheck.Checked)
                    {
                        MarzAlgSort marzAlg = new MarzAlgSort();

                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = chastUpMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += marzAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Алгоритм Марцина", time, element);
                            rownumb++;

                            sThird.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sThird);
                    }

                    if (fibCheck.Checked)
                    {
                        FibAlgSort fibAlg = new FibAlgSort();
                        int element = del;
                        element = del;
                        while (element <= N)
                        {
                            int[] mas = new int[element];
                            for (int i = 0; i < element; i++) mas[i] = chastUpMass[i];
                            float time = 0;
                            for (int i = 0; i < M; i++)
                                time += fibAlg.Sort(mas, element);
                            time /= M;
                            if (time > max) { max = time; chart1.ChartAreas[0].AxisY.Maximum = max; }

                            dataGridView1.Rows.Add("Эмпирическая последовательность на числах Фибоначчи", time, element);
                            rownumb++;

                            sFourth.Points.AddXY(element, time);

                            if (element == N) break;
                            element += del;
                            if (element > N) element = N;
                        }
                        chart1.Series.Add(sFourth);
                    }
                }
            }
            chart1.DataBind();
        }
    }
}
