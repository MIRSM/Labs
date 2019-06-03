using System.Diagnostics;
using System.IO;

namespace SIAOD10
{
    class NaturalSort
    {
        public void TwoPhaseNatural(string a, int kol, ref int colread, ref int colwrite, ref int colsr, ref long time)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            bool noots = true;
            while (noots)
            {
                noots = false;

                //фаза разделения

                splittingsr(new FileStream(a, FileMode.Open), new FileStream("b3.dat", FileMode.Create), new FileStream("c3.dat", FileMode.Create), ref colread, ref colwrite, ref colsr);

                {//фаза слияния
                    using (BinaryWriter bw = new BinaryWriter(new FileStream(a, FileMode.Create)))
                    using (BinaryReader brb = new BinaryReader(new FileStream("b3.dat", FileMode.Open)))
                    using (BinaryReader brc = new BinaryReader(new FileStream("c3.dat", FileMode.Open)))
                    {
                        int znach1 = brb.ReadInt32();
                        colread++;

                        int znach2 = brc.ReadInt32();
                        colread++;

                        int nextznach1 = znach1;
                        int nextznach2 = znach2;
                        int zapislast = -1;
                        int zapis = -1;
                        bool ser1 = true, ser2 = true;

                        colsr++;
                        if (znach1 <= znach2)
                        {
                            writeina1sr(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bw, brb, ref colread, ref colwrite, ref colsr);

                        }
                        else
                        {
                            writeina1sr(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bw, brc, ref colread, ref colwrite, ref colsr);

                        }

                        while ((nextznach1 != -1) && (nextznach2 != -1))
                        {
                            while (ser1 && ser2)
                            {
                                colsr++;
                                if (nextznach1 <= nextznach2)
                                {
                                    writeinasr(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bw, brb, ref colread, ref colwrite, ref colsr);

                                }
                                else
                                {
                                    writeinasr(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bw, brc, ref colread, ref colwrite, ref colsr);

                                }
                            }

                            while (ser1)
                            {
                                writeinasr(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bw, brb, ref colread, ref colwrite, ref colsr);

                            }
                            while (ser2)
                            {
                                writeinasr(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bw, brc, ref colread, ref colwrite, ref colsr);

                            }
                            ser1 = ser2 = true;
                        }

                        while (nextznach1 != -1)
                        {
                            writeinasr(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bw, brb, ref colread, ref colwrite, ref colsr);

                        }
                        while (nextznach2 != -1)
                        {
                            writeinasr(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bw, brc, ref colread, ref colwrite, ref colsr);

                        }

                        bw.Close();
                        brb.Close();
                        brc.Close();
                    }

                }
            }
            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;

        }

        public void splittingsr(FileStream a, FileStream b, FileStream c, ref int colread, ref int colwrite, ref int colsr)
        {
            int file = 1;
            using (BinaryWriter bwc = new BinaryWriter(c))
            using (BinaryWriter bwb = new BinaryWriter(b))
            using (BinaryReader br = new BinaryReader(a))
            {
                int znach = br.ReadInt32();
                colread++;

                int nextznach = br.ReadInt32();
                colread++;

                bwb.Write(znach);
                colwrite++;

                while (nextznach != -1)
                {
                    if (znach > nextznach)
                    {
                        switch (file)
                        {
                            case 1:
                                file = 2;
                                break;
                            case 2:
                                file = 1;
                                break;
                        }
                    }

                    if (file == 1)
                    {
                        bwb.Write(nextznach);
                        colwrite++;
                    }
                    else
                    {
                        bwc.Write(nextznach);
                        colwrite++;
                    }
                    znach = nextznach;
                    if (br.PeekChar() > -1) { nextznach = br.ReadInt32(); colread++; }
                    else nextznach = -1;
                }

                br.Close();
                bwb.Close();
                bwc.Close();

            }
        }

        public void writeina1sr(ref int znach, ref int nextznach, ref int zapislast, ref int zapis, ref bool noots, ref bool ser1, BinaryWriter bw, BinaryReader brb, ref int colread, ref int colwrite, ref int colsr)
        {
            bw.Write(znach);
            colwrite++;

            zapislast = zapis;
            zapis = znach;
            if (zapislast > zapis) noots = true;

            if (brb.PeekChar() != -1) { nextznach = brb.ReadInt32(); colread++; }
            else nextznach = -1;
            colsr++;

            if (znach > nextznach || nextznach == -1) ser1 = false;
        }

        public void writeinasr(ref int znach, ref int nextznach, ref int zapislast, ref int zapis, ref bool noots, ref bool ser1, BinaryWriter bw, BinaryReader brb, ref int colread, ref int colwrite, ref int colsr)
        {
            bw.Write(nextznach);
            colwrite++;

            znach = nextznach;
            zapislast = zapis;
            zapis = znach;
            if (zapislast > zapis) noots = true;

            if (brb.PeekChar() != -1) { nextznach = brb.ReadInt32(); colread++; }
            else nextznach = -1;
            colsr++;

            if (znach > nextznach || nextznach == -1) ser1 = false;
        }

        public void OnePhaseNatural(string a, int kol, ref int colread, ref int colwrite, ref int colsr, ref long time)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            bool noots = true;
            splittingsr(new FileStream(a, FileMode.Open), new FileStream("b4.dat", FileMode.Create), new FileStream("c4.dat", FileMode.Create), ref colread, ref colwrite, ref colsr);
            noots = true;
            bool v = true;

            while (noots)
            {
                noots = false;
                sortOnesr(ref noots, new FileStream("b4.dat", FileMode.Open), new FileStream("c4.dat", FileMode.Open), new FileStream("d4.dat", FileMode.Create), new FileStream("e4.dat", FileMode.Create), ref colread, ref colwrite, ref colsr);
                v = true;

                if (!noots) break;

                noots = false;
                sortOnesr(ref noots, new FileStream("d4.dat", FileMode.Open), new FileStream("e4.dat", FileMode.Open), new FileStream("b4.dat", FileMode.Create), new FileStream("c4.dat", FileMode.Create), ref colread, ref colwrite, ref colsr);
                v = false;
            }
            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;
            if (File.Exists(a)) File.Delete(a);
            if (v) File.Move("d4.dat", a);
            else File.Move("b4.dat", a);
        }

        public void sortOnesr(ref bool noots, FileStream b, FileStream c, FileStream d, FileStream e, ref int colread, ref int colwrite, ref int colsr)
        {
            using (BinaryReader brb = new BinaryReader(b))
            using (BinaryReader brc = new BinaryReader(c))
            using (BinaryWriter bwd = new BinaryWriter(d))
            using (BinaryWriter bwe = new BinaryWriter(e))
            {
                int switcf = 1;
                int znach1 = brb.ReadInt32();
                colread++;

                int znach2 = brc.ReadInt32();
                colread++;

                int nextznach1 = znach1;
                int nextznach2 = znach2;
                int zapislast = -1;
                int zapis = -1;
                bool ser1 = true, ser2 = true;

                colsr++;
                if (znach1 <= znach2)
                {
                    if (switcf == 1) writeina1sr(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwd, brb, ref colread, ref colwrite, ref colsr);
                    else writeina1sr(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brb, ref colread, ref colwrite, ref colsr);
                }
                else
                {
                    if (switcf == 1) writeina1sr(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwd, brc, ref colread, ref colwrite, ref colsr);
                    else writeina1sr(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwe, brc, ref colread, ref colwrite, ref colsr);
                }
                while ((nextznach1 != -1) && (nextznach2 != -1))
                {
                    while (ser1 && ser2)
                    {
                        if (nextznach1 <= nextznach2)
                        {
                            if (switcf == 1) writeinasr(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwd, brb, ref colread, ref colwrite, ref colsr);
                            else writeinasr(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brb, ref colread, ref colwrite, ref colsr);
                        }
                        else
                        {
                            if (switcf == 1) writeinasr(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwd, brc, ref colread, ref colwrite, ref colsr);
                            else writeinasr(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwe, brc, ref colread, ref colwrite, ref colsr);

                        }
                    }

                    while (ser1)
                    {
                        if (switcf == 1) writeinasr(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwd, brb, ref colread, ref colwrite, ref colsr);
                        else writeinasr(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brb, ref colread, ref colwrite, ref colsr);
                    }
                    while (ser2)
                    {
                        if (switcf == 1) writeinasr(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwd, brc, ref colread, ref colwrite, ref colsr);
                        else writeinasr(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwe, brc, ref colread, ref colwrite, ref colsr);
                    }
                    if (switcf == 1) switcf = 2;
                    else switcf = 1;

                    ser1 = ser2 = true;
                }
                ser1 = ser2 = true;

                while (nextznach1 != -1)
                {
                    if (switcf == 1) writeinasr(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwd, brb, ref colread, ref colwrite, ref colsr);
                    else writeinasr(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brb, ref colread, ref colwrite, ref colsr);
                    if (znach1 > nextznach1)
                    {
                        if (switcf == 1) switcf = 2;
                        else switcf = 1;
                    }
                }
                while (nextznach2 != -1)
                {
                    if (switcf == 1) writeinasr(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwd, brc, ref colread, ref colwrite, ref colsr);
                    else writeinasr(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwe, brc, ref colread, ref colwrite, ref colsr);
                    if (znach2 > nextznach2)
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
    }
}
