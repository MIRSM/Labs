using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SIAOD8
{
    public partial class Form1 : Form
    {
        int kol = 15;

        //Заполнение "ОП"
        public int[] Selection(int[] a)
        {
            int j = a.Length - 1;
            int kol = 0;
            while (j > 0)
            {
                int m = a[0];
                int k = 0;
                int i = 1;
                while (i <= j)
                {
                    if (m < a[i])
                    {
                        m = a[i];
                        k = i;
                    }
                    i++;
                }
                a[k] = a[j];
                a[j] = m;
                j--;
                kol++;
            }
            return a;
        }

        //Сортировка
        public void Sort1(ref int k, FileStream b, FileStream c, FileStream d, FileStream e)
        {
            using (BinaryReader brb = new BinaryReader(b))
            using (BinaryReader brc = new BinaryReader(c))
            using (BinaryWriter bwd = new BinaryWriter(d))
            using (BinaryWriter bwe = new BinaryWriter(e))
            {
                int znach1 = -1;
                int znach2 = -1;
                if (brb.PeekChar() > -1) znach1 = brb.ReadInt32();//Если следующий доступный символ не -1
                if (brc.PeekChar() > -1) znach2 = brc.ReadInt32();
                int ind = 1;

                while (znach1 != -1 && znach2 != -1)
                {
                    int i = 0;
                    int j = 0;
                    while (i < k && j < k && znach1 != -1 && znach2 != -1)
                    {
                        if (znach1 < znach2)
                        {
                            if (ind % 2 != 0) bwd.Write(znach1);
                            else bwe.Write(znach1);

                            if (brb.PeekChar() > -1) znach1 = brb.ReadInt32();
                            else znach1 = -1;
                            i++;
                        }
                        else
                        {
                            if (ind % 2 != 0) bwd.Write(znach2);
                            else bwe.Write(znach2);

                            if (brc.PeekChar() > -1) znach2 = brc.ReadInt32();
                            else znach2 = -1;
                            j++;
                        }
                    }
                    while (i < k && znach1 != -1)
                    {
                        if (ind % 2 != 0) bwd.Write(znach1);
                        else bwe.Write(znach1);

                        if (brb.PeekChar() > -1) znach1 = brb.ReadInt32();
                        else znach1 = -1;
                        i++;
                    }
                    while (j < k && znach2 != -1)
                    {
                        if (ind % 2 != 0) bwd.Write(znach2);
                        else bwe.Write(znach2);

                        if (brc.PeekChar() > -1) znach2 = brc.ReadInt32();
                        else znach2 = -1;
                        j++;
                    }
                    ind++;
                }
                while (znach1 != -1)
                {
                    if (ind % 2 != 0) bwd.Write(znach1);
                    else bwe.Write(znach1);

                    if (brb.PeekChar() > -1) znach1 = brb.ReadInt32();
                    else znach1 = -1;
                }
                while (znach2 != -1)
                {
                    if (ind % 2 != 0) bwd.Write(znach2);
                    else bwe.Write(znach2);

                    if (brc.PeekChar() > -1) znach2 = brc.ReadInt32();
                    else znach2 = -1;
                }
            }
        }

        //Сортировка (характеристики)
        public void Sort1sr(ref bool noots, FileStream b, FileStream c, FileStream d, FileStream e, ref int colread, ref int colwrite, ref int colsr)
        {
            using (BinaryReader brb = new BinaryReader(b))
            using (BinaryReader brc = new BinaryReader(c))
            using (BinaryWriter bwd = new BinaryWriter(d))
            using (BinaryWriter bwe = new BinaryWriter(e))
            {
                int switcf = 1;
                int num1 = brb.ReadInt32();
                colread++;
                int num2 = brc.ReadInt32();
                colread++;
                int nextnum1 = num1;
                int nextnum2 = num2;
                int zapislast = -1;
                int zapis = -1;
                bool ser1 = true, ser2 = true;
                colsr++;
                if (num1 <= num2)
                {
                    if (switcf == 1) Writeina1sr(ref num1, ref nextnum1, ref zapislast, ref zapis, ref noots, ref ser1, bwd, brb, ref colread, ref colwrite, ref colsr);
                    else Writeina1sr(ref num1, ref nextnum1, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brb, ref colread, ref colwrite, ref colsr);
                }
                else
                {
                    if (switcf == 1) Writeina1sr(ref num2, ref nextnum2, ref zapislast, ref zapis, ref noots, ref ser2, bwd, brc, ref colread, ref colwrite, ref colsr);
                    else Writeina1sr(ref num2, ref nextnum2, ref zapislast, ref zapis, ref noots, ref ser2, bwe, brc, ref colread, ref colwrite, ref colsr);
                }
                while ((nextnum1 != -1) && (nextnum2 != -1))
                {
                    while (ser1 && ser2)
                    {
                        colsr++;
                        if (nextnum1 <= nextnum2)
                        {
                            if (switcf == 1) Writeinasr(ref num1, ref nextnum1, ref zapislast, ref zapis, ref noots, ref ser1, bwd, brb, ref colread, ref colwrite, ref colsr);
                            else Writeinasr(ref num1, ref nextnum1, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brb, ref colread, ref colwrite, ref colsr);
                        }
                        else
                        {
                            if (switcf == 1) Writeinasr(ref num2, ref nextnum2, ref zapislast, ref zapis, ref noots, ref ser2, bwd, brc, ref colread, ref colwrite, ref colsr);
                            else Writeinasr(ref num2, ref nextnum2, ref zapislast, ref zapis, ref noots, ref ser2, bwe, brc, ref colread, ref colwrite, ref colsr);

                        }
                    }

                    while (ser1)
                    {
                        if (switcf == 1) Writeinasr(ref num1, ref nextnum1, ref zapislast, ref zapis, ref noots, ref ser1, bwd, brb, ref colread, ref colwrite, ref colsr);
                        else Writeinasr(ref num1, ref nextnum1, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brb, ref colread, ref colwrite, ref colsr);
                    }
                    while (ser2)
                    {
                        if (switcf == 1) Writeinasr(ref num2, ref nextnum2, ref zapislast, ref zapis, ref noots, ref ser2, bwd, brc, ref colread, ref colwrite, ref colsr);
                        else Writeinasr(ref num2, ref nextnum2, ref zapislast, ref zapis, ref noots, ref ser2, bwe, brc, ref colread, ref colwrite, ref colsr);
                    }
                    if (switcf == 1) switcf = 2;
                    else switcf = 1;
                    ser1 = ser2 = true;
                }
                ser1 = ser2 = true;
                while (nextnum1 != -1)
                {
                    if (switcf == 1) Writeinasr(ref num1, ref nextnum1, ref zapislast, ref zapis, ref noots, ref ser1, bwd, brb, ref colread, ref colwrite, ref colsr);
                    else Writeinasr(ref num1, ref nextnum1, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brb, ref colread, ref colwrite, ref colsr);
                    if (num1 > nextnum1)
                    {
                        if (switcf == 1) switcf = 2;
                        else switcf = 1;
                    }
                }
                while (nextnum2 != -1)
                {
                    if (switcf == 1) Writeinasr(ref num2, ref nextnum2, ref zapislast, ref zapis, ref noots, ref ser2, bwd, brc, ref colread, ref colwrite, ref colsr);
                    else Writeinasr(ref num2, ref nextnum2, ref zapislast, ref zapis, ref noots, ref ser2, bwe, brc, ref colread, ref colwrite, ref colsr);
                    if (num2 > nextnum2)
                    {
                        if (switcf == 1) switcf = 2;
                        else switcf = 1;
                    }
                }
                bwd.Close();
                bwe.Close();
                brb.Close();
                brc.Close();
            }
        }
        
        //Первое соединение файлов (характеристики)
        public void Writeina1sr(ref int znach, ref int nextznach, ref int zapislast, ref int zapis, ref bool noots, ref bool ser1, BinaryWriter bw, BinaryReader brb, ref int colread, ref int colwrite, ref int colsr)
        {
            bw.Write(znach);
            colwrite++;

            zapislast = zapis;
            zapis = znach;

            if (zapislast > zapis) noots = true;

            if (brb.PeekChar() != -1)
            {
                nextznach = brb.ReadInt32();
                colread++;
            }
            else nextznach = -1;

            //colsr++;
            if (znach > nextznach || nextznach == -1) ser1 = false;
        }

        //Соединение файлов (характеристики)
        public void Writeinasr(ref int znach, ref int nextznach, ref int zapislast, ref int zapis, ref bool noots, ref bool ser1, BinaryWriter bw, BinaryReader brb, ref int colread, ref int colwrite, ref int colsr)
        {
            bw.Write(nextznach);
            colwrite++;

            znach = nextznach;
            zapislast = zapis;
            zapis = znach;

            if (zapislast > zapis) noots = true;

            if (brb.PeekChar() != -1)
            {
                nextznach = brb.ReadInt32();
                colread++;
            }
            else nextznach = -1;

            //сcolsr++;
            if (znach > nextznach || nextznach == -1) ser1 = false;
        }

        //Вывод на экран во вкладке "Сортировка"
        private void Show(FileStream ser, string name, DataGridView a, int rownumb)
        {
            using (BinaryReader br = new BinaryReader(ser))
            {
                string[] row = new string[ser.Length];

                for (int i = 0; br.PeekChar() > -1; i++)
                {
                    row[i] = Convert.ToString(br.ReadInt32());
                }

                a.Rows.Add(row);
                a.Rows[rownumb].HeaderCell.Value = name;
            }
        }

        //Вывод на экран во вкладке "Характеристики"
        private void ShowSr(FileStream ser, string name, DataGridView a, int from, int to, int rownum)
        {
            using (BinaryReader br = new BinaryReader(ser))
            {
                for (int i = 1; i < from; i++)
                    br.ReadInt32();
                string[] row = new string[ser.Length];

                for (int i = 0; i < to - from + 1; i++)
                {
                    row[i] = Convert.ToString(br.ReadInt32());
                }
                a.Rows.Add(row);
                a.Rows[rownum].HeaderCell.Value = name;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        //"Сортировка"
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Rows.Clear();
            int kol = 15;
            int op = 3;
            int rownumb = 0;

            using (BinaryWriter bw = new BinaryWriter(new FileStream("a9.dat", FileMode.Create)))
            {
                Random randNumber = new Random();
                for (int i = 0; i < kol; i++)
                {
                    int znach = randNumber.Next(100);
                    bw.Write(znach);
                }
                bw.Close();
            }

            int len = (int)kol / op;
            int[] ser = new int[3];
            int q = 0, p;

            using (BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create)))
            using (BinaryReader br = new BinaryReader(new FileStream("a9.dat", FileMode.Open)))
            {
                for (int j = 1; br.PeekChar() > -1; j++)
                {
                    p = 0;
                    while (p < op)
                    {
                        ser[p] = br.ReadInt32();
                        p++;
                    }

                    ser = Selection(ser);
                    for (int i = 0; i < 3; i++)
                        bw.Write(ser[i]);
                }
                br.Close();
                bw.Close();
            }

            Show(new FileStream("a.dat", FileMode.Open), "A", dataGridView1, rownumb);
            rownumb++;

            using (BinaryReader br = new BinaryReader(new FileStream("a.dat", FileMode.Open)))
            using (BinaryWriter bw1 = new BinaryWriter(new FileStream("b.dat", FileMode.Create)))
            using (BinaryWriter bw2 = new BinaryWriter(new FileStream("c.dat", FileMode.Create)))
            {
                for (int j = 1; br.PeekChar() > -1; j++)
                {
                    p = 0;
                    while (p < op)
                    {
                        ser[p] = br.ReadInt32();
                        p++;
                    }

                    ser = Selection(ser);
                    if (q % 2 == 0)
                    {
                        for (int i = 0; i < op; i++)
                            bw1.Write(ser[i]);
                    }
                    else
                    {
                        for (int i = 0; i < op; i++)
                            bw2.Write(ser[i]);
                    }
                    q++;
                }
                br.Close();
                bw1.Close();
                bw2.Close();
            }

            int k = op;
            bool a = true;
            while (k < kol)
            {
                Show(new FileStream("b.dat", FileMode.Open), "B", dataGridView1, rownumb);
                rownumb++;

                Show(new FileStream("c.dat", FileMode.Open), "C", dataGridView1, rownumb);
                rownumb++;

                Sort1(ref k, new FileStream("b.dat", FileMode.Open), new FileStream("c.dat", FileMode.Open), new FileStream("d.dat", FileMode.Create), new FileStream("e.dat", FileMode.Create));

                k *= 2;
                a = true;
                if (k > kol) break;
                Show(new FileStream("d.dat", FileMode.Open), "D", dataGridView1, rownumb);
                rownumb++;

                Show(new FileStream("e.dat", FileMode.Open), "E", dataGridView1, rownumb);
                rownumb++;

                Sort1(ref k, new FileStream("d.dat", FileMode.Open), new FileStream("e.dat", FileMode.Open), new FileStream("b.dat", FileMode.Create), new FileStream("c.dat", FileMode.Create));
                k *= 2;
                a = false;
            }

            File.Delete("a.dat");
            if (a) File.Move("d.dat", "a.dat");
            else File.Move("b.dat", "a.dat");

            Show(new FileStream("a.dat", FileMode.Open), "A", dataGridView1, rownumb);
            rownumb++;

        }

        //"Характеристики"
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView2.Rows.Clear();
            kol = Convert.ToInt32(numericUpDown1.Text);
            Stopwatch sw = new Stopwatch();
            using (BinaryWriter bw = new BinaryWriter(new FileStream("a9.dat", FileMode.Create)))
            {

                Random randNumber = new Random();
                for (int i = 0; i < kol; i++)
                {
                    int num = randNumber.Next(100);
                    bw.Write(num);
                }
                bw.Close();
            }

            for (int Prop = 1; Prop < 11; Prop++)
            {
                File.Delete("a1.dat");
                File.Copy("a9.dat", "a1.dat");
                int op = (int)(kol * Prop) / 100;
                int len = kol / op;
                int[] ser = new int[op];
                int q = 0, p;
                using (BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create)))
                using (BinaryReader br = new BinaryReader(new FileStream("a1.dat", FileMode.Open)))
                {
                    for (int j = 1; br.PeekChar() > -1; j++)
                    {
                        p = 0;
                        while (p < op && br.PeekChar() > -1)
                        {
                            ser[p] = br.ReadInt32();
                            p++;
                        }

                        ser = Selection(ser);
                        for (int i = 0; i < op; i++)
                            bw.Write(ser[i]);
                    }
                    br.Close();
                    bw.Close();
                }
                using (BinaryReader br = new BinaryReader(new FileStream("a.dat", FileMode.Open)))
                using (BinaryWriter bw1 = new BinaryWriter(new FileStream("b.dat", FileMode.Create)))
                using (BinaryWriter bw2 = new BinaryWriter(new FileStream("c.dat", FileMode.Create)))
                {
                    for (int j = 1; br.PeekChar() > -1; j++)
                    {
                        p = 0;
                        while (p < op && br.PeekChar() > -1)
                        {
                            ser[p] = br.ReadInt32();
                            p++;
                        }
                        ser = Selection(ser);
                        if (q % 2 == 0)
                        {
                            for (int i = 0; i < op; i++)
                                bw1.Write(ser[i]);
                        }
                        else
                        {
                            for (int i = 0; i < op; i++)
                                bw2.Write(ser[i]);
                        }
                        q++;
                    }
                    br.Close();
                    bw1.Close();
                    bw2.Close();
                }
                sw.Restart();
                int colread = 0;
                int colwrite = 0;
                int colsr = 0;
                bool noots = true;
                bool a = true;
                while (noots)
                {
                    noots = false;
                    Sort1sr(ref noots, new FileStream("b.dat", FileMode.Open), new FileStream("c.dat", FileMode.Open), new FileStream("d.dat", FileMode.Create), new FileStream("e.dat", FileMode.Create), ref colread, ref colwrite, ref colsr);
                    a = true;
                    if (!noots) break;
                    noots = false;
                    Sort1sr(ref noots, new FileStream("d.dat", FileMode.Open), new FileStream("e.dat", FileMode.Open), new FileStream("b.dat", FileMode.Create), new FileStream("c.dat", FileMode.Create), ref colread, ref colwrite, ref colsr);
                    a = false;
                }
                sw.Stop();
                string f = "";
                switch (Prop)
                {
                    case 1:
                        f = "B1.dat";
                        break;
                    case 2:
                        f = "B2.dat";
                        break;
                    case 3:
                        f = "B3.dat";
                        break;
                    case 4:
                        f = "B4.dat";
                        break;
                    case 5:
                        f = "B5.dat";
                        break;
                    case 6:
                        f = "B6.dat";
                        break;
                    case 7:
                        f = "B7.dat";
                        break;
                    case 8:
                        f = "B8.dat";
                        break;
                    case 9:
                        f = "B9.dat";
                        break;
                    case 10:
                        f = "B10.dat";
                        break;
                }
                if (File.Exists(f)) File.Delete(f);
                if (a) File.Move("d.dat", f);
                else File.Move("b.dat", f);
                long t = sw.ElapsedTicks;
                string[] st = new string[5];
                st[0] = Convert.ToString(Prop);
                st[1] = Convert.ToString(t);
                st[2] = Convert.ToString(colread);
                st[3] = Convert.ToString(colwrite);
                st[4] = Convert.ToString(colsr);
                dataGridView2.Rows.Add(st);
            }
        }

        //Вывод результатов во вкладке "Характеристики"
        private void button3_Click(object sender, EventArgs e)
        {
            int from = Convert.ToInt32(numericUpDown2.Text);
            int to = Convert.ToInt32(numericUpDown3.Text);
            int rownum = 0;
            bool check = false;

            dataGridView3.Rows.Clear();

            if (to <= from || to > kol)
            {
                MessageBox.Show("Неверный диапазон!");
            }
            else
            {
                if (to - from >= 200)
                {
                    MessageBox.Show("Большое кол-во выводимых элементов! (Не больше 200!)");

                }
                else
                {
                    dataGridView3.ColumnCount = to - from;
                    if (to - from < 24) dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    else
                        dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    if (ACheck.Checked)
                    {
                        string f = "a.dat";
                        ShowSr(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B1Check.Checked)
                    {
                        string f = "B1.dat";
                        ShowSr(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B2Check.Checked)
                    {
                        string f = "B2.dat";
                        ShowSr(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B3Check.Checked)
                    {
                        string f = "B3.dat";
                        ShowSr(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B4Check.Checked)
                    {
                        string f = "B4.dat";
                        ShowSr(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B5Check.Checked)
                    {
                        string f = "B5.dat";
                        ShowSr(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B6Check.Checked)
                    {
                        string f = "B6.dat";
                        ShowSr(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B7Check.Checked)
                    {
                        string f = "B7.dat";
                        ShowSr(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B8Check.Checked)
                    {
                        string f = "B8.dat";
                        ShowSr(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B9Check.Checked)
                    {
                        string f = "B9.dat";
                        ShowSr(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B10Check.Checked)
                    {
                        string f = "B10.dat";
                        ShowSr(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (!check) dataGridView3.Rows.Clear();
                }
            }
        }
    }
}
