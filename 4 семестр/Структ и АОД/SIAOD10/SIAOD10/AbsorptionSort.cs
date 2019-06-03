using System;
using System.Diagnostics;
using System.IO;

namespace SIAOD10
{
    class AbsorptionSort
    {
        Selection ins = new Selection();
        public void absorption(string a, int kol, int Prop, ref int colread, ref int colwrite, ref int colsr, ref long time)
        {
            Stopwatch sw = new Stopwatch();
            int op = (int)(kol * Prop) / 100;
            int len = (int)kol / op;
            int[] ser = new int[op];
            int ost = kol % op;

            if (ost != 0)
                using (FileStream fs = File.Open(a, FileMode.Open))
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
            using (FileStream fs = File.Open(a, FileMode.Open))
            {

                Byte[] number = new Byte[4];
                for (int i = 0; i < op; i++)
                {
                    fs.Seek(-4 * (i + 1), SeekOrigin.End);
                    fs.Read(number, 0, 4);
                    colread++;
                    ser[i] = BitConverter.ToInt32(number, 0); ;
                }
                ins.selection(ser);

                fs.Seek(-4 * (op), SeekOrigin.End);
                for (int i = 0; i < op; i++)
                {

                    number = BitConverter.GetBytes(ser[i]);
                    fs.Write(number, 0, 4);
                    colwrite++;
                }

            }

            int serlength = op;
            while (serlength < kol)
            {
                using (FileStream fs = File.Open(a, FileMode.Open))
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
                    ins.selection(ser);
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
                            colwrite++;
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
                            colwrite++;

                            j++;
                            if (j < op) znach2 = ser[j];


                        }
                    }

                    while (lenfile < serlength)
                    {
                        number = BitConverter.GetBytes(znach);
                        fs.Seek(-4 * (smesh), SeekOrigin.End);
                        fs.Write(number, 0, 4);
                        colwrite++;
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
                        colwrite++;
                        smesh--;
                        j++;
                        if (j < op) znach2 = ser[j];
                    }
                    serlength += op;

                }
            }
            sw.Stop();

            time = sw.ElapsedTicks;
        }
    }
}
