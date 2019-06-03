using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIAOD10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleSort simple = new SimpleSort();
        NaturalSort natural = new NaturalSort();
        Internal iwe = new Internal();
        AbsorptionSort absorption = new AbsorptionSort();

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkTwoPhaseSimple.Checked | checkOnePhaseSimple.Checked | checkTwoPhaseNatural.Checked | checkOnePhaseNatural.Checked | checkInternal.Checked | checkAbsor.Checked)
            {
                int kolEnd = Convert.ToInt32(numericKol.Text);
                int op = Convert.ToInt32(numericOP.Text);
                int t = Convert.ToInt32(numericT.Text);
                int kolElinGraph = 10;
                int kolBegin = kolEnd * 10 / 100;
                int step = (0 + kolEnd) / kolElinGraph;
                long[] simpleTwoMas = new long[kolElinGraph + 1];
                long[] simpleOneMas = new long[kolElinGraph + 1];
                long[] naturalTwoMas = new long[kolElinGraph + 1];
                long[] naturalOneMas = new long[kolElinGraph + 1];
                long[] intrenalMas = new long[kolElinGraph + 1];
                long[] AbsorMas = new long[kolElinGraph + 1];
                int[] kolElemMas = new int[kolElinGraph + 1];
                chart1.ChartAreas[0].AxisX.Minimum = 0;

                for (int j = 1, kol = kolBegin; kol < kolEnd + 1; j++, kol += step)
                {
                    kolElemMas[j] = kol;
                    using (BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create)))
                    {
                        Random randNumber = new Random();
                        for (int i = 0; i < kol; i++)
                        {
                            int znach = 1 + randNumber.Next(100);
                            bw.Write(znach);
                        }
                        bw.Close();
                    }

                    if (checkTwoPhaseSimple.Checked)
                    {
                        long sr = 0;
                        for (int i = 0; i < t; i++)
                        {
                            if (File.Exists("simpleTwo.dat")) File.Delete("simpleTwo.dat");
                            File.Copy("a.dat", "simpleTwo.dat");
                            int colread = 0;
                            int colwrite = 0;
                            int colsr = 0;
                            long time = 0;
                            simple.TwoPhaseSimple("simpleTwo.dat", kol, ref colread, ref colwrite, ref colsr, ref time);
                            sr += time;
                        }
                        sr = sr / t;
                        simpleTwoMas[j] = sr;

                    }

                    if (checkOnePhaseSimple.Checked)
                    {
                        long sr = 0;
                        for (int i = 0; i < t; i++)
                        {
                            if (File.Exists("simpleOne.dat")) File.Delete("simpleOne.dat");
                            File.Copy("a.dat", "simpleOne.dat");
                            int colread = 0;
                            int colwrite = 0;
                            int colsr = 0;
                            long time = 0;
                            simple.OnePhaseSimple("simpleOne.dat", kol, ref colread, ref colwrite, ref colsr, ref time);
                            sr += time;
                        }
                        sr = sr / t;
                        simpleOneMas[j] = sr;
                    }

                    if (checkTwoPhaseNatural.Checked)
                    {
                        long sr = 0;
                        for (int i = 0; i < t; i++)
                        {
                            if (File.Exists("naturalTwo.dat")) File.Delete("naturalTwo.dat");
                            File.Copy("a.dat", "naturalTwo.dat");
                            int colread = 0;
                            int colwrite = 0;
                            int colsr = 0;
                            long time = 0;
                            natural.TwoPhaseNatural("naturalTwo.dat", kol, ref colread, ref colwrite, ref colsr, ref time);
                            sr += time;
                        }
                        sr = sr / t;
                        naturalTwoMas[j] = sr;
                    }

                    if (checkOnePhaseNatural.Checked)
                    {
                        long sr = 0;
                        for (int i = 0; i < t; i++)
                        {
                            if (File.Exists("naturalOne.dat")) File.Delete("naturalOne.dat");
                            File.Copy("a.dat", "naturalOne.dat");
                            int colread = 0;
                            int colwrite = 0;
                            int colsr = 0;
                            long time = 0;
                            natural.OnePhaseNatural("naturalOne.dat", kol, ref colread, ref colwrite, ref colsr, ref time);
                            sr += time;
                        }
                        sr = sr / t;
                        naturalOneMas[j] = sr;
                    }

                    if (checkInternal.Checked)
                    {
                        long sr = 0;
                        for (int i = 0; i < t; i++)
                        {
                            if (File.Exists("IWE.dat")) File.Delete("IWE.dat");
                            File.Copy("a.dat", "IWE.dat");
                            int colread = 0;
                            int colwrite = 0;
                            int colsr = 0;
                            long time = 0;
                            iwe.IWE("IWE.dat", kol, op, ref colread, ref colwrite, ref colsr, ref time);
                            sr += time;
                        }
                        sr = sr / t;
                        intrenalMas[j] = sr;

                    }

                    if (checkAbsor.Checked)
                    {
                        long sr = 0;
                        for (int i = 0; i < t; i++)
                        {
                            if (File.Exists("Absorption.dat")) File.Delete("Absorption.dat");
                            File.Copy("a.dat", "Absorption.dat");
                            int colread = 0;
                            int colwrite = 0;
                            int colsr = 0;
                            long time = 0;
                            absorption.absorption("Absorption.dat", kol, op, ref colread, ref colwrite, ref colsr, ref time);
                            sr += time;
                        }
                        sr = sr / t;
                        AbsorMas[j] = sr;
                    }
                }

                chart1.Series["двухфазная сортировка простым слиянием"].Points.Clear();
                if (checkTwoPhaseSimple.Checked)
                {
                    chart1.Series["двухфазная сортировка простым слиянием"].Points.DataBindXY(kolElemMas, simpleTwoMas);
                    chart1.Series["двухфазная сортировка простым слиянием"].Color = Color.YellowGreen;
                }

                chart1.Series["однофазная сортировка простым слиянием"].Points.Clear();
                if (checkOnePhaseSimple.Checked)
                {
                    chart1.Series["однофазная сортировка простым слиянием"].Points.DataBindXY(kolElemMas, simpleOneMas);
                    chart1.Series["однофазная сортировка простым слиянием"].Color = Color.Red;
                }

                chart1.Series["двухфазная сортировка естественным слиянием"].Points.Clear();
                if (checkTwoPhaseNatural.Checked)
                {
                    chart1.Series["двухфазная сортировка естественным слиянием"].Points.DataBindXY(kolElemMas, naturalTwoMas);
                    chart1.Series["двухфазная сортировка естественным слиянием"].Color = Color.Turquoise;
                }

                chart1.Series["однофазная сортировка естественным слиянием"].Points.Clear();
                if (checkOnePhaseNatural.Checked)
                {
                    chart1.Series["однофазная сортировка естественным слиянием"].Points.DataBindXY(kolElemMas, naturalOneMas);
                    chart1.Series["однофазная сортировка естественным слиянием"].Color = Color.Lime;
                }

                chart1.Series["внутренняя сортировка с внешним слиянием"].Points.Clear();
                if (checkInternal.Checked)
                {
                    chart1.Series["внутренняя сортировка с внешним слиянием"].Points.DataBindXY(kolElemMas, intrenalMas);
                    chart1.Series["внутренняя сортировка с внешним слиянием"].Color = Color.Blue;
                }

                chart1.Series["сортировка методом поглощения"].Points.Clear();
                if (checkAbsor.Checked)
                {
                    chart1.Series["сортировка методом поглощения"].Points.DataBindXY(kolElemMas, AbsorMas);
                    chart1.Series["сортировка методом поглощения"].Color = Color.Magenta;
                }
            }
            else
            {
                const string message = "Выберите хотя бы 1 пункт";
                const string caption = "Ни один пункт не выбран";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkTwoPhaseSimple.Checked | checkOnePhaseSimple.Checked | checkTwoPhaseNatural.Checked | checkOnePhaseNatural.Checked | checkInternal.Checked | checkAbsor.Checked)
            {
                dataGridView1.Rows.Clear();
                int kol = Convert.ToInt32(numericKol.Text);
                int op = Convert.ToInt32(numericOP.Text);
                using (BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create)))
                {
                    Random randNumber = new Random();
                    for (int i = 0; i < kol; i++)
                    {
                        int znach = 1 + randNumber.Next(100);
                        bw.Write(znach);
                    }
                    bw.Close();
                }
                if (checkTwoPhaseSimple.Checked)
                {
                    if (File.Exists("simpleTwo.dat")) File.Delete("simpleTwo.dat");
                    File.Copy("a.dat", "simpleTwo.dat");
                    int colread = 0;
                    int colwrite = 0;
                    int colsr = 0;
                    long time = 0;
                    simple.TwoPhaseSimple("simpleTwo.dat", kol, ref colread, ref colwrite, ref colsr, ref time);
                    string[] row = new string[5];
                    row[0] = "двухфазная сортировка простым слиянием";
                    row[1] = Convert.ToString(time);
                    row[2] = Convert.ToString(colread);
                    row[3] = Convert.ToString(colwrite);
                    row[4] = Convert.ToString(colsr);
                    dataGridView1.Rows.Add(row);

                }
                if (checkOnePhaseSimple.Checked)
                {
                    if (File.Exists("simpleOne.dat")) File.Delete("simpleOne.dat");
                    File.Copy("a.dat", "simpleOne.dat");
                    int colread = 0;
                    int colwrite = 0;
                    int colsr = 0;
                    long time = 0;
                    simple.OnePhaseSimple("simpleOne.dat", kol, ref colread, ref colwrite, ref colsr, ref time);
                    string[] row = new string[5];
                    row[0] = "однофазная сортировка простым слиянием";
                    row[1] = Convert.ToString(time);
                    row[2] = Convert.ToString(colread);
                    row[3] = Convert.ToString(colwrite);
                    row[4] = Convert.ToString(colsr);
                    dataGridView1.Rows.Add(row);
                }
                if (checkTwoPhaseNatural.Checked)
                {
                    if (File.Exists("naturalTwo.dat")) File.Delete("naturalTwo.dat");
                    File.Copy("a.dat", "naturalTwo.dat");
                    int colread = 0;
                    int colwrite = 0;
                    int colsr = 0;
                    long time = 0;
                    natural.TwoPhaseNatural("naturalTwo.dat", kol, ref colread, ref colwrite, ref colsr, ref time);
                    string[] row = new string[5];
                    row[0] = "двухфазная сортировка естественным слиянием";
                    row[1] = Convert.ToString(time);
                    row[2] = Convert.ToString(colread);
                    row[3] = Convert.ToString(colwrite);
                    row[4] = Convert.ToString(colsr);
                    dataGridView1.Rows.Add(row);
                }
                if (checkOnePhaseNatural.Checked)
                {
                    if (File.Exists("naturalOne.dat")) File.Delete("naturalOne.dat");
                    File.Copy("a.dat", "naturalOne.dat");
                    int colread = 0;
                    int colwrite = 0;
                    int colsr = 0;
                    long time = 0;
                    natural.OnePhaseNatural("naturalOne.dat", kol, ref colread, ref colwrite, ref colsr, ref time);
                    string[] row = new string[5];
                    row[0] = "однофазная сортировка естественным слиянием";
                    row[1] = Convert.ToString(time);
                    row[2] = Convert.ToString(colread);
                    row[3] = Convert.ToString(colwrite);
                    row[4] = Convert.ToString(colsr);
                    dataGridView1.Rows.Add(row);
                }
                if (checkInternal.Checked)
                {
                    if (File.Exists("IWE.dat")) File.Delete("IWE.dat");
                    File.Copy("a.dat", "IWE.dat");
                    int colread = 0;
                    int colwrite = 0;
                    int colsr = 0;
                    long time = 0;
                    iwe.IWE("IWE.dat", kol, op, ref colread, ref colwrite, ref colsr, ref time);
                    string[] row = new string[5];
                    row[0] = "внутренняя сортировка с внешним слиянием";
                    row[1] = Convert.ToString(time);
                    row[2] = Convert.ToString(colread);
                    row[3] = Convert.ToString(colwrite);
                    row[4] = Convert.ToString(colsr);
                    dataGridView1.Rows.Add(row);

                }
                if (checkAbsor.Checked)
                {
                    if (File.Exists("Absorption.dat")) File.Delete("Absorption.dat");
                    File.Copy("a.dat", "Absorption.dat");
                    int colread = 0;
                    int colwrite = 0;
                    int colsr = 0;
                    long time = 0;
                    absorption.absorption("Absorption.dat", kol, op, ref colread, ref colwrite, ref colsr, ref time);
                    string[] row = new string[5];
                    row[0] = "сортировка методом поглощения";
                    row[1] = Convert.ToString(time);
                    row[2] = Convert.ToString(colread);
                    row[3] = Convert.ToString(colwrite);
                    row[4] = Convert.ToString(colsr);
                    dataGridView1.Rows.Add(row);
                }
            }
            else
            {
                const string message = "Выберите сортировку!";
                const string caption = "Ни один пункт не выбран";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
