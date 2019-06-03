using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SIAOD7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridOneSort.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridTwoSort.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        int total = 0;
        Sort sr = new Sort();

        //однофазная сортировка
        private void button1_Click(object sender, EventArgs e)
        {

            int total = 15;
            dataGridOneSort.Rows.Clear();

            using (BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create)))
            {

                Random rndN = new Random();
                for (int i = 0; i < total; i++)
                {
                    int znach = rndN.Next(100);
                    bw.Write(znach);
                }
                bw.Close();
            }

            dataGridOneSort.Rows.Add();
            dataGridOneSort.Rows[0].HeaderCell.Value = "A";

            using (BinaryReader br = new BinaryReader(new FileStream("a.dat", FileMode.Open)))
            {
                for (int i = 0; i < total ; i++)
                {
                    dataGridOneSort[i,0].Value = Convert.ToString(br.ReadInt32());
                }
                br.Close();
            }

            //разделение
            sr.splitting(new FileStream("a.dat", FileMode.Open), new FileStream("b.dat", FileMode.Create), new FileStream("c.dat", FileMode.Create));

            bool noots = true;
            bool a = true;
            int rownumb = 1;

            while (noots)
            {
                noots = false;

                show(new FileStream("b.dat", FileMode.Open), "B", dataGridOneSort, rownumb);
                rownumb++;

                show(new FileStream("c.dat", FileMode.Open), "C", dataGridOneSort, rownumb);
                rownumb++;

                sr.sortOne(ref noots, new FileStream("b.dat", FileMode.Open), new FileStream("c.dat", FileMode.Open), new FileStream("d.dat", FileMode.Create), new FileStream("e.dat", FileMode.Create));
                a = true;

                if (!noots) break;

                show(new FileStream("d.dat", FileMode.Open), "D", dataGridOneSort, rownumb);
                rownumb++;

                show(new FileStream("e.dat", FileMode.Open), "E", dataGridOneSort, rownumb);
                rownumb++;

                noots = false;

                sr.sortOne(ref noots, new FileStream("d.dat", FileMode.Open), new FileStream("e.dat", FileMode.Open), new FileStream("b.dat", FileMode.Create), new FileStream("c.dat", FileMode.Create));
                a = false;
            }
            
            File.Delete("a.dat");

            if (a) File.Move("d.dat", "a.dat");
            else File.Move("b.dat", "a.dat");

            show(new FileStream("a.dat", FileMode.Open), "A", dataGridOneSort, rownumb);
        }

        //двуфазная сортировка
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridTwoSort.Rows.Clear();

            int total = 15;
            using (BinaryWriter bw = new BinaryWriter(new FileStream("a1.dat", FileMode.Create)))
            {

                Random rndN = new Random();
                int[] mass = {3,8,25,7,29,27,30,36,4,90,40,50,60,11,99 };
                for (int i = 0; i < total; i++)
                {
                    // int znach = rndN.Next(100);
                    int znach = mass[i];
                    bw.Write(znach);
                }
                bw.Close();
            }
            
            dataGridTwoSort.Rows.Add();
            dataGridTwoSort.Rows[0].HeaderCell.Value = "A";

            using (BinaryReader br = new BinaryReader(new FileStream("a1.dat", FileMode.Open)))
            {
                for (int i = 0; i < total; i++)
                {
                    dataGridTwoSort[i,0].Value= Convert.ToString(br.ReadInt32());
                }
                br.Close();
            }

            bool noots = true;
            int rownumb = 1;

            while (noots)
            {
                noots = false;
                sr.splitting(new FileStream("a1.dat", FileMode.Open), new FileStream("b1.dat", FileMode.Create), new FileStream("c1.dat", FileMode.Create));

                show(new FileStream("b1.dat", FileMode.Open), "B", dataGridTwoSort, rownumb);
                rownumb++;

                show(new FileStream("c1.dat", FileMode.Open), "C", dataGridTwoSort, rownumb);
                rownumb++;

                //слияние
                using (BinaryWriter bw = new BinaryWriter(new FileStream("a1.dat", FileMode.Create)))
                using (BinaryReader brb = new BinaryReader(new FileStream("b1.dat", FileMode.Open)))
                using (BinaryReader brc = new BinaryReader(new FileStream("c1.dat", FileMode.Open)))
                {
                    int znach1 = brb.ReadInt32();
                    int znach2 = brc.ReadInt32();

                    int nextznach1 = znach1;
                    int nextznach2 = znach2;

                    int zapislast = -1;
                    int zapis = -1;
                    bool seria1 = true, seria2 = true;

                    if (znach1 <= znach2)
                    {
                        sr.WriteA1(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref seria1, bw, brb);
                    }
                    else
                    {
                        sr.WriteA1(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref seria2, bw, brc);
                    }

                    while ((nextznach1 != -1) && (nextznach2 != -1))
                    {
                        while (seria1 && seria2)
                        {
                            if (nextznach1 <= nextznach2)
                            {
                                sr.writeA(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref seria1, bw, brb);
                            }
                            else
                            {
                                sr.writeA(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref seria2, bw, brc);
                            }
                        }

                        while (seria1)
                        {
                            sr.writeA(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref seria1, bw, brb);
                        }
                        while (seria2)
                        {
                            sr.writeA(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref seria2, bw, brc);
                        }

                        seria1 = seria2 = true;
                    }

                    seria1 = seria2 = true;

                    while (nextznach1 != -1)
                    {
                        sr.writeA(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref seria1, bw, brb);
                    }
                    while (nextznach2 != -1)
                    {
                        sr.writeA(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref seria2, bw, brc);
                    }
                    bw.Close();
                    brb.Close();
                    brc.Close();
                }
                show(new FileStream("a1.dat", FileMode.Open), "A", dataGridTwoSort, rownumb);
                rownumb++;
            }
        }
        
        //сравнение характеристик
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridCh.Rows.Clear();

            total = Convert.ToInt32(numericUpDown1.Text);
            using (BinaryWriter bw = new BinaryWriter(new FileStream("A4.dat", FileMode.Create)))
            {

                Random rndN = new Random();
                for (int i = 0; i < total; i++)
                {
                    int znach = rndN.Next(100);
                    bw.Write(znach);
                }
                bw.Close();
            }

            File.Delete("B4.dat");
            File.Copy("A4.dat", "B4.dat");

            int colread = 0;
            int colwrite = 0;
            int colsr = 0;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            bool noots = true;
            
            //Двухфазная
            while (noots)
            {
                noots = false;

                //разделение
                sr.splittingsr(new FileStream("B4.dat", FileMode.Open), new FileStream("b2.dat", FileMode.Create), new FileStream("c2.dat", FileMode.Create), ref colread, ref colwrite, ref colsr);

                {//слияние
                    using (BinaryWriter bw = new BinaryWriter(new FileStream("B4.dat", FileMode.Create)))
                    using (BinaryReader brb = new BinaryReader(new FileStream("b2.dat", FileMode.Open)))
                    using (BinaryReader brc = new BinaryReader(new FileStream("c2.dat", FileMode.Open)))
                    {
                        int znach1 = brb.ReadInt32();
                        colread++;

                        int znach2 = brc.ReadInt32();
                        colread++;

                        int nextznach1 = znach1;
                        int nextznach2 = znach2;
                        int zapislast = -1;
                        int zapis = -1;

                        bool seria1 = true, seria2 = true;
                        colsr++;

                        if (znach1 <= znach2)
                        {
                            sr.WriteAsr(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref seria1, bw, brb, ref colread, ref colwrite, ref colsr);

                        }
                        else
                        {
                            sr.WriteAsr(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref seria2, bw, brc, ref colread, ref colwrite, ref colsr);

                        }

                        while ((nextznach1 != -1) && (nextznach2 != -1))
                        {
                            while (seria1 && seria2)
                            {
                                colsr++;
                                if (nextznach1 <= nextznach2)
                                {
                                    sr.WriteAsr1(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref seria1, bw, brb, ref colread, ref colwrite, ref colsr);

                                }
                                else
                                {
                                    sr.WriteAsr1(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref seria2, bw, brc, ref colread, ref colwrite, ref colsr);

                                }
                            }

                            while (seria1)
                            {
                                sr.WriteAsr1(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref seria1, bw, brb, ref colread, ref colwrite, ref colsr);

                            }

                            while (seria2)
                            {
                                sr.WriteAsr1(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref seria2, bw, brc, ref colread, ref colwrite, ref colsr);

                            }

                            seria1 = seria2 = true;
                        }

                        while (nextznach1 != -1)
                        {
                            sr.WriteAsr1(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref seria1, bw, brb, ref colread, ref colwrite, ref colsr);

                        }

                        while (nextznach2 != -1)
                        {
                            sr.WriteAsr1(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref seria2, bw, brc, ref colread, ref colwrite, ref colsr);

                        }
                        bw.Close();
                        brb.Close();
                        brc.Close();
                    }

                }
            }
            sw.Stop();

            long t = sw.ElapsedTicks;
            string[] row = new string[5];
            row[0] = "Двухвазная";
            row[1] = Convert.ToString(t);
            row[2] = Convert.ToString(colread);
            row[3] = Convert.ToString(colwrite);
            row[4] = Convert.ToString(colsr);
            dataGridCh.Rows.Add(row);

            colread = 0;
            colwrite = 0;
            colsr = 0;
            sw.Restart();

            //разделение
            sr.splittingsr(new FileStream("A4.dat", FileMode.Open), new FileStream("b3.dat", FileMode.Create), new FileStream("c3.dat", FileMode.Create), ref colread, ref colwrite, ref colsr);

            noots = true;
            bool a = true;

            //Однофазная
            while (noots)
            {
                noots = false;

                sr.sortOnesr(ref noots, new FileStream("b3.dat", FileMode.Open), new FileStream("c3.dat", FileMode.Open), new FileStream("d3.dat", FileMode.Create), new FileStream("e3.dat", FileMode.Create), ref colread, ref colwrite, ref colsr);
                a = true;

                if (!noots) break;

                noots = false;

                sr.sortOnesr(ref noots, new FileStream("d3.dat", FileMode.Open), new FileStream("e3.dat", FileMode.Open), new FileStream("b3.dat", FileMode.Create), new FileStream("c3.dat", FileMode.Create), ref colread, ref colwrite, ref colsr);
                a = false;
            }
            sw.Stop();

            File.Delete("C4.dat");
            if (a) File.Move("d3.dat", "C4.dat");
            else File.Move("b3.dat", "C4.dat");

            t = sw.ElapsedTicks;
            row[0] = "Однофазная";
            row[1] = Convert.ToString(t);
            row[2] = Convert.ToString(colread);
            row[3] = Convert.ToString(colwrite);
            row[4] = Convert.ToString(colsr);
            dataGridCh.Rows.Add(row);

        }

        //вывод содержимого
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridShow.Rows.Clear();

            int from = Convert.ToInt32(numericUpDown2.Text);
            int to = Convert.ToInt32(numericUpDown3.Text);

            int rownum = 0;

            if (to <= from || to > total) MessageBox.Show("Некорретный диапазон!");
            else
            {
                dataGridShow.ColumnCount = total;

                if (total+1 <=20 )
                    dataGridShow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                else
                    dataGridShow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;

                if (Acheck.Checked)
                {
                   showsr(new FileStream("A4.dat", FileMode.Open), "A", dataGridShow, from, to, rownum);
                    rownum++;
                }

                if (Bcheck.Checked)
                {
                    showsr(new FileStream("B4.dat", FileMode.Open), "B", dataGridShow, from, to, rownum);
                    rownum++;
                }

                if (Ccheck.Checked)
                {
                    showsr(new FileStream("C4.dat", FileMode.Open), "C", dataGridShow, from, to, rownum);
                    rownum++;
                }
            }
        }
        
        //вывод в таблицу сортировок
        private void show(FileStream ser, string name, DataGridView a,int rownumb)
        {
            using (BinaryReader br = new BinaryReader(ser))
            {
                string[] row = new string[ser.Length];
               // row[0] = name;
                for (int i = 0; br.PeekChar() > -1; i++)
                {
                    a.Columns[i].HeaderCell.Value = "№ " + (i+1).ToString();
                    row[i] = Convert.ToString(br.ReadInt32());
                }
                a.Rows.Add(row);
                a.Rows[rownumb].HeaderCell.Value = name;
            }
        }

        //вывод в таблицу сортировок (при сравнении)
        private void showsr(FileStream ser, string name, DataGridView a, int from, int to,int rownumb)
        {
            using (BinaryReader br = new BinaryReader(ser))
            {
                for (int i = 1; i < from; i++)
                    br.ReadInt32();
                string[] row = new string[ser.Length];
                for (int i = 0; i < to - from + 1; i++)
                {
                    a.Columns[i].HeaderCell.Value = "№ " + (i+1).ToString();
                    row[i] = Convert.ToString(br.ReadInt32());
                }
                a.Rows.Add(row);
                a.Rows[rownumb].HeaderCell.Value = name;
            }
        }
    }
}
