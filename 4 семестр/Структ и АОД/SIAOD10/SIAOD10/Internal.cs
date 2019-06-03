using System.Diagnostics;
using System.IO;

namespace SIAOD10
{
    class Internal
    {
        NaturalSort sr = new NaturalSort();
        Selection ins = new Selection();
        public void IWE(string a, int kol, int Prop, ref int colread, ref int colwrite, ref int colsr, ref long time)
        {
            int op = (int)(kol * Prop) / 100;
            int len = kol / op;
            int[][] ser = new int[len + 1][];
            for (int j = 0; j < len + 1; j++)
                ser[j] = new int[op];

            using (BinaryReader br = new BinaryReader(new FileStream(a, FileMode.Open)))
            {
                for (int j = 0; j < len; j++)
                    for (int i = 0; i < op; i++)
                        ser[j][i] = br.ReadInt32();

                for (int i = 0; br.PeekChar() != -1; i++)
                    ser[len][i] = br.ReadInt32();

                for (int j = 0; j < len; j++)
                    ser[j] = ins.selection(ser[j]);

            }
            using (BinaryWriter bw = new BinaryWriter(new FileStream(a, FileMode.Create)))
            {
                for (int j = 0; j < len; j++)
                    for (int i = 0; i < op; i++)
                        bw.Write(ser[j][i]);

                for (int i = 0; i < op && ser[len][i] != 0; i++)
                    bw.Write(ser[len][i]);
            }
            Stopwatch sw = new Stopwatch();

            sw.Start();

            sr.splittingsr(new FileStream(a, FileMode.Open), new FileStream("b5.dat", FileMode.Create), new FileStream("c5.dat", FileMode.Create), ref colread, ref colwrite, ref colsr);
            bool noots = true;
            bool v = true;

            while (noots)
            {
                noots = false;
                sr.sortOnesr(ref noots, new FileStream("b5.dat", FileMode.Open), new FileStream("c5.dat", FileMode.Open), new FileStream("d5.dat", FileMode.Create), new FileStream("e5.dat", FileMode.Create), ref colread, ref colwrite, ref colsr);
                v = true;

                if (!noots) break;

                noots = false;
                sr.sortOnesr(ref noots, new FileStream("d5.dat", FileMode.Open), new FileStream("e5.dat", FileMode.Open), new FileStream("b5.dat", FileMode.Create), new FileStream("c5.dat", FileMode.Create), ref colread, ref colwrite, ref colsr);
                v = false;
            }

            sw.Stop();
            time = sw.ElapsedTicks;
            if (File.Exists(a)) File.Delete(a);

            if (v) File.Move("d5.dat", a);
            else File.Move("b5.dat", a);

        }
    }
}
