using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SIAOD9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Сортировка ОП
        public int[] selection(int[] a)
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

        //Вывод на экран (сортировка)
        private void show(FileStream ser, string name, DataGridView a,int rownumb)
        {
            using (BinaryReader br = new BinaryReader(ser))
            {
                string[] row = new string[ser.Length];
                //row[0] = name;
                for (int i = 0; br.PeekChar() > -1; i++)
                {
                    row[i] = Convert.ToString(br.ReadInt32());
                }
                a.Rows.Add(row);
                a.Rows[rownumb].HeaderCell.Value = name;
            }
        }

        //Вывод на экран (сортировка)
        private void show(int[] ser, string name, DataGridView a, int bias,int rownumb)
        {
            string[] row = new string[ser.Length + bias];

            //row[0] = name;
            for (int i = 0; i < ser.Length; i++)
            {
                row[bias + i ] = Convert.ToString(ser[i]);
            }
            a.Rows.Add(row);
            a.Rows[rownumb].HeaderCell.Value = name;
        }

        //Вывод на экран (содержимое файла)
        private void showft(FileStream ser, string name, DataGridView a, int from, int to, int rownum)
        {
            using (BinaryReader br = new BinaryReader(ser))
            {
                for (int j = 1; j < from; j++)
                    br.ReadInt32();
                string[] row = new string[ser.Length];
               
                int i = 0;
                while (i < to - from + 1)
                {
                    int znach = br.ReadInt32();
                    if (znach != 0)
                    {
                        row[i] = Convert.ToString(znach);
                        i++;
                    }
                }
                a.Rows.Add(row);
                a.Rows[rownum].HeaderCell.Value = name;
            }
        }

        int kol = 15;

        //Кнопка "Сортировка"
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int kol = 15;
            int op = 3;
            int rownumb = 0;

            using (BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create)))
            {
                Random randNumber = new Random();
                for (int i = 0; i < kol; i++)
                {
                    int znach = randNumber.Next(100);
                    bw.Write(znach);
                }
                bw.Close();
            }

            using (BinaryReader br = new BinaryReader(new FileStream("a.dat", FileMode.Open)))
            {
                string[] row = new string[15];

                for (int i = 0; br.PeekChar() > -1; i++)
                {
                    row[i] = Convert.ToString(br.ReadInt32());
                }

                dataGridView1.Rows.Add(row);
                dataGridView1.Rows[rownumb].HeaderCell.Value = "A";
                br.Close();
            }
            rownumb++;

            int len = (int)kol / op;
            int[] ser = new int[op];

            using (FileStream fs = File.Open("a.dat", FileMode.Open))
            {

                Byte[] number = new Byte[4];
                for (int i = 0; i < op; i++)
                {
                    fs.Seek(-4 * (i + 1), SeekOrigin.End);
                    fs.Read(number, 0, 4);
                    ser[i] = BitConverter.ToInt32(number, 0); ;
                }

                selection(ser);
                show(ser, "ОП", dataGridView1, kol - op, rownumb);
                rownumb++;
                fs.Seek(-4 * (op), SeekOrigin.End);

                for (int i = 0; i < op; i++)
                {

                    number = BitConverter.GetBytes(ser[i]);
                    fs.Write(number, 0, 4);
                }
            }

            show(new FileStream("a.dat", FileMode.Open), "A", dataGridView1, rownumb);
            rownumb++;
            int serlength = op;

            while (serlength < kol)
            {
                using (FileStream fs = File.Open("a.dat", FileMode.Open))
                {
                    int smesh = serlength + op;
                    int smechread = serlength;
                    fs.Seek(-4 * (smesh), SeekOrigin.End);
                    Byte[] numbers = new Byte[4 * op];
                    fs.Read(numbers, 0, 4 * op);

                    for (int i = 0; i < op; i++)
                        ser[i] = BitConverter.ToInt32(numbers, 4 * i);

                    selection(ser);
                    show(ser, "ОП", dataGridView1, kol - smesh, rownumb);
                    rownumb++;

                    Byte[] number = new Byte[4];
                    fs.Seek(-4 * smechread, SeekOrigin.End);
                    smechread--;
                    fs.Read(number, 0, 4);

                    int znach = BitConverter.ToInt32(number, 0);
                    int znach2 = ser[0];
                    int lenfile = 0, j = 0;

                    while (lenfile < serlength && j < op)
                    {
                        if (znach < znach2)
                        {
                            number = BitConverter.GetBytes(znach);

                            fs.Seek(-4 * (smesh), SeekOrigin.End);
                            fs.Write(number, 0, 4);
                            smesh--;

                            fs.Seek(-4 * (smechread), SeekOrigin.End);
                            smechread--;

                            fs.Read(number, 0, 4);
                            znach = BitConverter.ToInt32(number, 0);
                            lenfile++;
                        }
                        else
                        {
                            number = BitConverter.GetBytes(znach2);
                            fs.Seek(-4 * (smesh), SeekOrigin.End);
                            smesh--;
                            fs.Write(number, 0, 4);
                            j++;

                            if (j < op) znach2 = ser[j];

                        }
                    }

                    while (lenfile < serlength)
                    {
                        number = BitConverter.GetBytes(znach);
                        fs.Seek(-4 * (smesh), SeekOrigin.End);
                        fs.Write(number, 0, 4);
                        smesh--;

                        fs.Seek(-4 * (smechread), SeekOrigin.End);
                        smechread--;

                        fs.Read(number, 0, 4);
                        znach = BitConverter.ToInt32(number, 0);
                        lenfile++;
                    }
                    while (j < op)
                    {
                        number = BitConverter.GetBytes(znach2);
                        fs.Seek(-4 * (smesh), SeekOrigin.End);
                        fs.Write(number, 0, 4);
                        smesh--;
                        j++;

                        if (j < op) znach2 = ser[j];
                    }

                    serlength += op;
                }
                show(new FileStream("a.dat", FileMode.Open), "A", dataGridView1, rownumb);
                rownumb++;
            }
        }

        //Кнопка "Сравнить"
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            kol = Convert.ToInt32(numericUpDown1.Text);
            Stopwatch sw = new Stopwatch();

            using (BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create)))
            {
                Random randNumber = new Random();
                for (int i = 0; i < kol; i++)
                {
                    int znach = 1 + randNumber.Next(100);//zz[i];
                    bw.Write(znach);
                }
                bw.Close();
            }

            for (int Prop = 1; Prop < 11; Prop++)
            {
                if (File.Exists("a2.dat")) File.Delete("a2.dat");
                File.Copy("a.dat", "a2.dat");

                int op = (int)(kol * Prop) / 100;
                int len = (int)kol / op;
                int[] ser = new int[op];
                int colwrites = 0;
                int colread = 0;
                int colsr = 0;
                int ost = kol % op;

                if (ost != 0)
                    using (FileStream fs = File.Open("a2.dat", FileMode.Open))
                    {
                        for (int i = 0; i < op - ost; i++)
                        {
                            Byte[] number = new Byte[4];
                            number = BitConverter.GetBytes(0);
                            fs.Seek(0, SeekOrigin.End);
                            fs.Write(number, 0, 4);
                        }
                    }

                sw.Restart();
                using (FileStream fs = File.Open("a2.dat", FileMode.Open))
                {

                    Byte[] number = new Byte[4];
                    for (int i = 0; i < op; i++)
                    {
                        fs.Seek(-4 * (i + 1), SeekOrigin.End);
                        fs.Read(number, 0, 4);
                        colread++;
                        ser[i] = BitConverter.ToInt32(number, 0); ;
                    }

                    selection(ser);
                    fs.Seek(-4 * (op), SeekOrigin.End);

                    for (int i = 0; i < op; i++)
                    {

                        number = BitConverter.GetBytes(ser[i]);
                        fs.Write(number, 0, 4);
                        colwrites++;
                    }

                }

                int serlength = op;
                while (serlength < kol)
                {
                    using (FileStream fs = File.Open("a2.dat", FileMode.Open))
                    {
                        int smesh = serlength + op;
                        int smechread = serlength;

                        fs.Seek(-4 * (smesh), SeekOrigin.End);
                        Byte[] numbers = new Byte[4 * op];
                        fs.Read(numbers, 0, 4 * op);

                        for (int i = 0; i < op; i++)
                        {
                            ser[i] = BitConverter.ToInt32(numbers, 4 * i);
                            colread++;
                        }

                        selection(ser);

                        Byte[] number = new Byte[4];
                        fs.Seek(-4 * smechread, SeekOrigin.End);
                        smechread--;
                        fs.Read(number, 0, 4);

                        int znach = BitConverter.ToInt32(number, 0);
                        int znach2 = ser[0];
                        int lenfile = 0, j = 0;
                       
                        while (lenfile < serlength && j < op)
                        {
                            colsr++;
                            if (znach < znach2)
                            {
                                number = BitConverter.GetBytes(znach);
                                fs.Seek(-4 * (smesh), SeekOrigin.End);
                                fs.Write(number, 0, 4);
                                colwrites++;
                                smesh--;

                                fs.Seek(-4 * (smechread), SeekOrigin.End);
                                smechread--;

                                fs.Read(number, 0, 4);
                                colread++;

                                znach = BitConverter.ToInt32(number, 0);
                                lenfile++;
                            }
                            else
                            {
                                number = BitConverter.GetBytes(znach2);
                                fs.Seek(-4 * (smesh), SeekOrigin.End);
                                smesh--;

                                fs.Write(number, 0, 4);
                                colwrites++;
                                j++;

                                if (j < op) znach2 = ser[j];

                            }
                        }

                        while (lenfile < serlength)
                        {
                            number = BitConverter.GetBytes(znach);
                            fs.Seek(-4 * (smesh), SeekOrigin.End);
                            fs.Write(number, 0, 4);
                            colwrites++;
                            smesh--;

                            fs.Seek(-4 * (smechread), SeekOrigin.End);
                            smechread--;

                            fs.Read(number, 0, 4);
                            colread++;

                            znach = BitConverter.ToInt32(number, 0);
                            lenfile++;
                        }

                        while (j < op)
                        {
                            number = BitConverter.GetBytes(znach2);
                            fs.Seek(-4 * (smesh), SeekOrigin.End);
                            fs.Write(number, 0, 4);
                            colwrites++;
                            smesh--;
                            j++;

                            if (j < op) znach2 = ser[j];
                        }
                        serlength += op;
                    }
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

                File.Move("a2.dat", f);
                long t = sw.ElapsedTicks;
                string[] st = new string[5];
                st[0] = Convert.ToString(Prop);
                st[1] = Convert.ToString(t);
                st[2] = Convert.ToString(colread);
                st[3] = Convert.ToString(colwrites);
                st[4] = Convert.ToString(colsr);
                dataGridView2.Rows.Add(st);
            }
        }

        //Кнопка "Отобразить"
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
                        string f = "A.dat";
                        showft(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B1Check.Checked)
                    {
                        string f = "B1.dat";
                        showft(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B2Check.Checked)
                    {
                        string f = "B2.dat";
                        showft(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B3Check.Checked)
                    {
                        string f = "B3.dat";
                        showft(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B4Check.Checked)
                    {
                        string f = "B4.dat";
                        showft(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B5Check.Checked)
                    {
                        string f = "B5.dat";
                        showft(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B6Check.Checked)
                    {
                        string f = "B6.dat";
                        showft(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B7Check.Checked)
                    {
                        string f = "B7.dat";
                        showft(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B8Check.Checked)
                    {
                        string f = "B8.dat";
                        showft(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B9Check.Checked)
                    {
                        string f = "B9.dat";
                        showft(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (B10Check.Checked)
                    {
                        string f = "B10.dat";
                        showft(new FileStream(f, FileMode.Open), f, dataGridView3, from, to, rownum);
                        rownum++;
                        check = true;
                    }

                    if (!check) dataGridView3.Rows.Clear();
                }
            }
        }
    }

}
