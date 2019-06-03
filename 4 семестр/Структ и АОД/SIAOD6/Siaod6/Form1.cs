using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
/*
5
4
1
23
4
7
1
6
53
9
8
7
4
11
32
*/
namespace Siaod6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool Enter = false;
        int total = 0;
        private void OnePhaseSort(ref int k, FileStream b, FileStream c, FileStream d, FileStream e)
        {
            using (BinaryReader brb = new BinaryReader(b))
            using (BinaryReader brc = new BinaryReader(c))
            using (BinaryWriter bwd = new BinaryWriter(d))
            using (BinaryWriter bwe = new BinaryWriter(e))
            {
                int znach1 = -1;                    //значение считываемого числа
                int znach2 = -1;                    //значение считываемого числа
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

        private void TwoPhaseSort(ref int k, FileStream a, FileStream b, FileStream c)
        {
            using (BinaryWriter bwA = new BinaryWriter(a))
            using (BinaryReader brb = new BinaryReader(b))
            using (BinaryReader brc = new BinaryReader(c))
            {
                int znach1 = -1;
                int znach2 = -1;
                if (brb.PeekChar() > -1) znach1 = brb.ReadInt32();
                if (brc.PeekChar() > -1) znach2 = brc.ReadInt32();
                while (znach1 != -1 && znach2 != -1)
                {
                    int i = 0;
                    int j = 0;
                    while (i < k && j < k && znach1 != -1 && znach2 != -1)
                    {
                        if (znach1 < znach2)
                        {
                            bwA.Write(znach1);
                            if (brb.PeekChar() > -1) znach1 = brb.ReadInt32();
                            else znach1 = -1;
                            i++;
                        }
                        else
                        {
                            bwA.Write(znach2);
                            if (brc.PeekChar() > -1) znach2 = brc.ReadInt32();
                            else znach2 = -1;
                            j++;
                        }
                    }
                    while (i < k && znach1 != -1)
                    {
                        bwA.Write(znach1);
                        if (brb.PeekChar() > -1) znach1 = brb.ReadInt32();
                        else znach1 = -1;
                        i++;
                    }
                    while (j < k && znach2 != -1)
                    {
                        bwA.Write(znach2);
                        if (brc.PeekChar() > -1) znach2 = brc.ReadInt32();
                        else znach2 = -1;
                        j++;
                    }

                }
                while (znach1 != -1)
                {
                    bwA.Write(znach1);
                    if (brb.PeekChar() > -1) znach1 = brb.ReadInt32();
                    else znach1 = -1;
                }
                while (znach2 != -1)
                {
                    bwA.Write(znach2);
                    if (brc.PeekChar() > -1) znach2 = brc.ReadInt32();
                    else znach2 = -1;
                }


            }

        }

        private void show(FileStream fsA, string name, DataGridView a, int rownumb)
        {
            using (BinaryReader brA = new BinaryReader(fsA))
            {
                string[] row = new string[fsA.Length];
                for (int i = 0; brA.PeekChar() > -1; i++)
                {
                    row[i] = Convert.ToString(brA.ReadInt32());
                }
                a.Rows.Add(row);
                a.Rows[rownumb].HeaderCell.Value = name;
            }
        }

        private void showSr(FileStream fsA, string name, DataGridView a, int rownumb,int t,int k,int n)
        {
            using (BinaryReader brA = new BinaryReader(fsA))
            {
                string[] row = new string[fsA.Length];
                for(int i = 0; i < t; i++)
                {
                    brA.ReadInt32();
                }
                for (int i=0; t <= k; t++,i++)
                {
                    row[i] = Convert.ToString(brA.ReadInt32());
                }
                a.Rows.Add(row);
                a.Rows[rownumb].HeaderCell.Value = name;
            }
        }

        private void OnePhaseSortSr(ref int numread, ref int numwrite, ref int numsr, ref int k, FileStream b, FileStream c, FileStream d, FileStream e)
        {
            using (BinaryReader brb = new BinaryReader(b))
            using (BinaryReader brc = new BinaryReader(c))
            using (BinaryWriter bwd = new BinaryWriter(d))
            using (BinaryWriter bwe = new BinaryWriter(e))
            {
                int znach1 = -1;
                int znach2 = -1;
                if (brb.PeekChar() > -1)
                {
                    znach1 = brb.ReadInt32();
                    numread++;
                }
                if (brc.PeekChar() > -1)
                {
                    znach2 = brc.ReadInt32();
                    numread++;
                }
                int ind = 1;
                while (znach1 != -1 && znach2 != -1)
                {
                    int i = 0;
                    int j = 0;
                    while (i < k && j < k && znach1 != -1 && znach2 != -1)
                    {
                        numsr++;
                        if (znach1 < znach2)
                        {
                            if (ind % 2 != 0) { bwd.Write(znach1); numwrite++; }
                            else { bwe.Write(znach1); numwrite++; }
                            if (brb.PeekChar() > -1) { znach1 = brb.ReadInt32(); numread++; }
                            else znach1 = -1;
                            i++;
                        }
                        else
                        {
                            if (ind % 2 != 0) { bwd.Write(znach2); numwrite++; }
                            else { bwe.Write(znach2); numwrite++; }
                            if (brc.PeekChar() > -1) { znach2 = brc.ReadInt32(); numread++; }
                            else znach2 = -1;
                            j++;
                        }
                    }
                    while (i < k && znach1 != -1)
                    {
                        if (ind % 2 != 0) bwd.Write(znach1);
                        else bwe.Write(znach1);
                        numwrite++;
                        if (brb.PeekChar() > -1) { znach1 = brb.ReadInt32(); numread++; }
                        else znach1 = -1;
                        i++;
                    }
                    while (j < k && znach2 != -1)
                    {
                        if (ind % 2 != 0) bwd.Write(znach2);
                        else bwe.Write(znach2);
                        numwrite++;
                        if (brc.PeekChar() > -1) { znach2 = brc.ReadInt32(); numread++; }
                        else znach2 = -1;
                        j++;
                    }
                    ind++;
                }
                while (znach1 != -1)
                {
                    if (ind % 2 != 0) bwd.Write(znach1);
                    else bwe.Write(znach1);
                    numwrite++;
                    if (brb.PeekChar() > -1) { znach1 = brb.ReadInt32(); numread++; }
                    else znach1 = -1;
                }
                while (znach2 != -1)
                {
                    if (ind % 2 != 0) bwd.Write(znach2);
                    else bwe.Write(znach2);
                    numwrite++;
                    if (brc.PeekChar() > -1) { znach2 = brc.ReadInt32(); numread++; }
                    else znach2 = -1;
                }


            }


        }

        private void TwoPhaseSortSr(ref int numread, ref int numwrite, ref int numsr, ref int k, FileStream a, FileStream b, FileStream c)
        {
            using (BinaryWriter bwA = new BinaryWriter(a))
            using (BinaryReader brb = new BinaryReader(b))
            using (BinaryReader brc = new BinaryReader(c))
            {
                int znach1 = -1;
                int znach2 = -1;
                if (brb.PeekChar() > -1)
                {
                    znach1 = brb.ReadInt32();
                    numread++;
                }
                if (brc.PeekChar() > -1)
                {
                    znach2 = brc.ReadInt32();
                    numread++;
                }
                while (znach1 != -1 && znach2 != -1)
                {
                    int i = 0;
                    int j = 0;
                    while (i < k && j < k && znach1 != -1 && znach2 != -1)
                    {
                        numsr++;
                        if (znach1 < znach2)
                        {
                            bwA.Write(znach1);
                            numwrite++;
                            if (brb.PeekChar() > -1) { znach1 = brb.ReadInt32(); numread++; }
                            else znach1 = -1;
                            i++;
                        }
                        else
                        {
                            bwA.Write(znach2);
                            numwrite++;
                            if (brc.PeekChar() > -1) { znach2 = brc.ReadInt32(); numread++; }
                            else znach2 = -1;
                            j++;
                        }
                    }
                    while (i < k && znach1 != -1)
                    {
                        bwA.Write(znach1);
                        numwrite++;
                        if (brb.PeekChar() > -1) { znach1 = brb.ReadInt32(); numread++; }
                        else znach1 = -1;
                        i++;
                    }
                    while (j < k && znach2 != -1)
                    {
                        bwA.Write(znach2);
                        numwrite++;
                        if (brc.PeekChar() > -1) { znach2 = brc.ReadInt32(); numread++; }
                        else znach2 = -1;
                        j++;
                    }

                }
                while (znach1 != -1)
                {
                    bwA.Write(znach1);
                    numwrite++;
                    if (brb.PeekChar() > -1) { znach1 = brb.ReadInt32(); numread++; }
                    else znach1 = -1;
                }
                while (znach2 != -1)
                {
                    bwA.Write(znach2);
                    numwrite++;
                    if (brc.PeekChar() > -1) { znach2 = brc.ReadInt32(); numread++; }
                    else znach2 = -1;
                }


            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int rownumb = 1;
            int total = 15;
            dataGridView1.Rows.Clear();
            using (BinaryWriter bwA = new BinaryWriter(new FileStream("a1.dat", FileMode.Create)))
            {

                Random randNumber = new Random();
                for (int i = 0; i < total; i++)
                {
                    int znach = randNumber.Next(100);
                    bwA.Write(znach);
                }
                bwA.Close();
            }
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].HeaderCell.Value = "A";
            using (BinaryReader brA = new BinaryReader(new FileStream("a1.dat", FileMode.Open)))
            {
                for (int i = 0; i < total ; i++)
                {
                    dataGridView1[i, 0].Value = Convert.ToString(brA.ReadInt32());
                }
                brA.Close();
            }

            int k = 1;
            while (k < total)
            {
                {
                    using (BinaryWriter bwc = new BinaryWriter(new FileStream("c1.dat", FileMode.Create)))
                    using (BinaryWriter bwb = new BinaryWriter(new FileStream("b1.dat", FileMode.Create)))
                    using (BinaryReader brA = new BinaryReader(new FileStream("a1.dat", FileMode.Open)))
                    {
                        while (brA.PeekChar() > -1)
                        {
                            for (int i = 0; i < k; i++)
                            {
                                if (brA.PeekChar() > -1)
                                {
                                    int znach = brA.ReadInt32();
                                    bwb.Write(znach);
                                }
                            }
                            for (int i = 0; i < k; i++)
                            {
                                if (brA.PeekChar() > -1)
                                {
                                    int znach = brA.ReadInt32();
                                    bwc.Write(znach);
                                }
                            }
                        }
                        brA.Close();
                        bwb.Close();
                        bwc.Close();

                    }
                    show(new FileStream("b1.dat", FileMode.Open), "B", dataGridView1, rownumb);
                    rownumb++;
                    show(new FileStream("c1.dat", FileMode.Open), "C", dataGridView1, rownumb);
                    rownumb++;
                }
                TwoPhaseSort(ref k, new FileStream("a1.dat", FileMode.OpenOrCreate), new FileStream("b1.dat", FileMode.Open), new FileStream("c1.dat", FileMode.Open));
                show(new FileStream("a1.dat", FileMode.Open), "A", dataGridView1, rownumb);
                rownumb++;
                k *= 2;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rownumb = 1;
            int total = 15;
            dataGridView2.Rows.Clear();
            using (BinaryWriter bwA = new BinaryWriter(new FileStream("a.dat", FileMode.Create)))
            {

                Random randNumber = new Random();
                for (int i = 0; i < total; i++)
                {
                    int znach = randNumber.Next(100);
                    bwA.Write(znach);
                }
                bwA.Close();
            }
            dataGridView2.Rows.Add();
            dataGridView2.Rows[0].HeaderCell.Value = "A";
            using (BinaryReader brA = new BinaryReader(new FileStream("a.dat", FileMode.Open)))
            {
                for (int i = 0; i < total; i++)
                {
                    dataGridView2[i, 0].Value = Convert.ToString(brA.ReadInt32());
                }
                brA.Close();
            }

            int k = 1;
            {
                FileStream fsA = new FileStream("a.dat", FileMode.Open);
                FileStream fsB = new FileStream("b.dat", FileMode.Create);
                FileStream fsC = new FileStream("c.dat", FileMode.Create);
                using (BinaryWriter bwc = new BinaryWriter(fsC))
                using (BinaryWriter bwb = new BinaryWriter(fsB))
                using (BinaryReader brA = new BinaryReader(fsA))
                {
                    while (brA.PeekChar() > -1)
                    {
                        for (int i = 0; i < k; i++)
                        {
                            if (brA.PeekChar() > -1)
                            {
                                int znach = brA.ReadInt32();
                                bwb.Write(znach);
                            }
                        }
                        for (int i = 0; i < k; i++)
                        {
                            if (brA.PeekChar() > -1)
                            {
                                int znach = brA.ReadInt32();
                                bwc.Write(znach);
                            }
                        }
                    }
                    brA.Close();
                    bwb.Close();
                    bwc.Close();

                }
            }
            while (k < total)
            {
                show(new FileStream("b.dat", FileMode.Open), "B", dataGridView2, rownumb);
                rownumb++;
                show(new FileStream("c.dat", FileMode.Open), "C", dataGridView2, rownumb);
                rownumb++;
                OnePhaseSort(ref k, new FileStream("b.dat", FileMode.Open), new FileStream("c.dat", FileMode.Open), new FileStream("d.dat", FileMode.Create), new FileStream("e.dat", FileMode.Create));
                k *= 2;
                show(new FileStream("d.dat", FileMode.Open), "D", dataGridView2, rownumb);
                rownumb++;
                show(new FileStream("e.dat", FileMode.Open), "E", dataGridView2, rownumb);
                rownumb++;
                OnePhaseSort(ref k, new FileStream("d.dat", FileMode.Open), new FileStream("e.dat", FileMode.Open), new FileStream("b.dat", FileMode.Create), new FileStream("c.dat", FileMode.Create));
                k *= 2;
            }
            File.Delete("a.dat");
            File.Move("b.dat", "a.dat");
            show(new FileStream("a.dat", FileMode.Open), "A", dataGridView2, rownumb);
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            total = Convert.ToInt32(numericUpDown1.Value);
            using (BinaryWriter bw = new BinaryWriter(new FileStream("A4.dat", FileMode.Create)))
            {

                Random randNumber = new Random();
                for (int i = 0; i < total; i++)
                {
                    int znach = randNumber.Next(100);
                    bw.Write(znach);
                }
                bw.Close();
            }
            File.Delete("B4.dat");
            File.Copy("A4.dat", "B4.dat");
            int k = 1;
            int numread = 0;
            int numwrite = 0;
            int numsr = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (k < total)
            {
                {
                    using (BinaryWriter bwc = new BinaryWriter(new FileStream("c2.dat", FileMode.Create)))
                    using (BinaryWriter bwb = new BinaryWriter(new FileStream("b2.dat", FileMode.Create)))
                    using (BinaryReader br = new BinaryReader(new FileStream("B4.dat", FileMode.Open)))
                    {
                        while (br.PeekChar() > -1)
                        {
                            for (int i = 0; i < k; i++)
                            {
                                if (br.PeekChar() > -1)
                                {
                                    int znach = br.ReadInt32();
                                    numread++;
                                    bwb.Write(znach);
                                    numwrite++;
                                }
                            }
                            for (int i = 0; i < k; i++)
                            {
                                if (br.PeekChar() > -1)
                                {
                                    int znach = br.ReadInt32();
                                    numread++;
                                    bwc.Write(znach);
                                    numwrite++;
                                }
                            }
                        }
                        br.Close();
                        bwb.Close();
                        bwc.Close();

                    }
                }
                TwoPhaseSortSr(ref numread, ref numwrite, ref numsr, ref k, new FileStream("B4.dat", FileMode.Create), new FileStream("b2.dat", FileMode.Open), new FileStream("c2.dat", FileMode.Open));
                k *= 2;
            }
            stopWatch.Stop();
            long t = stopWatch.ElapsedTicks;
            string[] row = new string[5];
            row[0] = "Двухвазная";
            row[1] = Convert.ToString(t);
            row[2] = Convert.ToString(numread);
            row[3] = Convert.ToString(numwrite);
            row[4] = Convert.ToString(numsr);
            dataGridView3.Rows.Add(row);
            k = 1;
            numread = 0;
            numwrite = 0;
            numsr = 0;
            stopWatch.Restart();

            using (BinaryWriter bwc = new BinaryWriter(new FileStream("c3.dat", FileMode.Create)))
            using (BinaryWriter bwb = new BinaryWriter(new FileStream("b3.dat", FileMode.Create)))
            using (BinaryReader br = new BinaryReader(new FileStream("A4.dat", FileMode.Open)))
            {
                while (br.PeekChar() > -1)
                {
                    for (int i = 0; i < k; i++)
                    {
                        if (br.PeekChar() > -1)
                        {
                            int znach = br.ReadInt32();
                            numread++;
                            bwb.Write(znach);
                            numwrite++;
                        }
                    }
                    for (int i = 0; i < k; i++)
                    {
                        if (br.PeekChar() > -1)
                        {
                            int znach = br.ReadInt32();
                            numread++;
                            bwc.Write(znach);
                            numwrite++;
                        }
                    }
                }
                br.Close();
                bwb.Close();
                bwc.Close();

            }

            while (k < total)
            {
                OnePhaseSortSr(ref numread, ref numwrite, ref numsr, ref k, new FileStream("b3.dat", FileMode.Open), new FileStream("c3.dat", FileMode.Open), new FileStream("d3.dat", FileMode.Create), new FileStream("e3.dat", FileMode.Create));
                k *= 2;
                OnePhaseSortSr(ref numread, ref numwrite, ref numsr, ref k, new FileStream("d3.dat", FileMode.Open), new FileStream("e3.dat", FileMode.Open), new FileStream("b3.dat", FileMode.Create), new FileStream("c3.dat", FileMode.Create));
                k *= 2;
            }
            stopWatch.Stop();
            File.Delete("C4.dat");
            File.Move("b3.dat", "C4.dat");
            t = stopWatch.ElapsedTicks;
            row[0] = "Однофазная";
            row[1] = Convert.ToString(t);
            row[2] = Convert.ToString(numread);
            row[3] = Convert.ToString(numwrite);
            row[4] = Convert.ToString(numsr);
            dataGridView3.Rows.Add(row);
            Enter = true;   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Enter)
            {
                dataGridView4.Rows.Clear();
                dataGridView4.ColumnCount = total;

                dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                int rownum = 0;
                int t = Convert.ToInt32(numericUpDown2.Value) - 1;
                int k = Convert.ToInt32(numericUpDown3.Value) - 1;
                int n = Convert.ToInt32(numericUpDown1.Value) - 1;
                if (k - t < 24) dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                else dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                if (t > k || k > n) MessageBox.Show("Некорректно задан диапазон!");
                else
                {
                    if (aCheckBox.Checked)
                    {
                        // dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        showSr(new FileStream("A4.dat", FileMode.Open), "A", dataGridView4, rownum, t, k, n);
                        rownum++;

                    }
                    if (bCheckBox.Checked)
                    {
                        //  dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        showSr(new FileStream("B4.dat", FileMode.Open), "B", dataGridView4, rownum, t, k, n);
                        rownum++;
                    }
                    if (cCheckBox.Checked)
                    {
                        //dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        showSr(new FileStream("C4.dat", FileMode.Open), "C", dataGridView4, rownum, t, k, n);
                        rownum++;
                    }
                }
            }
            else MessageBox.Show("Нет файла!");
        }
    }
}
