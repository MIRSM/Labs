using System.Diagnostics;
using System.IO;

namespace SIAOD10
{
    class SimpleSort
    {
        public void TwoPhaseSimple(string a, int kol, ref int colread, ref int colwrite, ref int colsr, ref long time)
        {
            int k = 1;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            while (k < kol)
            {
                {
                    using (BinaryWriter bwc = new BinaryWriter(new FileStream("c2.dat", FileMode.Create)))
                    using (BinaryWriter bwb = new BinaryWriter(new FileStream("b2.dat", FileMode.Create)))
                    using (BinaryReader br = new BinaryReader(new FileStream(a, FileMode.Open)))
                    {
                        while (br.PeekChar() > -1)
                        {
                            for (int i = 0; i < k; i++)
                            {
                                if (br.PeekChar() > -1)
                                {
                                    int znach = br.ReadInt32();
                                    colread++;
                                    bwb.Write(znach);
                                    colwrite++;
                                }
                            }

                            for (int i = 0; i < k; i++)
                            {
                                if (br.PeekChar() > -1)
                                {
                                    int znach = br.ReadInt32();
                                    colread++;
                                    bwc.Write(znach);
                                    colwrite++;
                                }
                            }
                        }
                        br.Close();
                        bwb.Close();
                        bwc.Close();
                    }
                }
                sortTwosr(ref colread, ref colwrite, ref colsr, ref k, new FileStream(a, FileMode.Create), new FileStream("b2.dat", FileMode.Open), new FileStream("c2.dat", FileMode.Open));
                k *= 2;
            }
            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;
        }

        private void sortTwosr(ref int colread, ref int colwrite, ref int colsr, ref int k, FileStream a, FileStream b, FileStream c)
        {

            using (BinaryWriter br = new BinaryWriter(a))
            using (BinaryReader brb = new BinaryReader(b))
            using (BinaryReader brc = new BinaryReader(c))
            {
                int znach1 = -1;
                int znach2 = -1;

                if (brb.PeekChar() > -1)
                {
                    znach1 = brb.ReadInt32();
                    colread++;
                }
                if (brc.PeekChar() > -1)
                {
                    znach2 = brc.ReadInt32();
                    colread++;
                }

                while (znach1 != -1 && znach2 != -1)
                {
                    int i = 0;
                    int j = 0;

                    while (i < k && j < k && znach1 != -1 && znach2 != -1)
                    {
                        colsr++;
                        if (znach1 < znach2)
                        {
                            br.Write(znach1);
                            colwrite++;
                            if (brb.PeekChar() > -1) { znach1 = brb.ReadInt32(); colread++; }
                            else znach1 = -1;
                            i++;
                        }
                        else
                        {
                            br.Write(znach2);
                            colwrite++;
                            if (brc.PeekChar() > -1) { znach2 = brc.ReadInt32(); colread++; }
                            else znach2 = -1;
                            j++;
                        }
                    }

                    while (i < k && znach1 != -1)
                    {
                        br.Write(znach1);
                        colwrite++;
                        if (brb.PeekChar() > -1) { znach1 = brb.ReadInt32(); colread++; }
                        else znach1 = -1;
                        i++;
                    }
                    while (j < k && znach2 != -1)
                    {
                        br.Write(znach2);
                        colwrite++;
                        if (brc.PeekChar() > -1) { znach2 = brc.ReadInt32(); colread++; }
                        else znach2 = -1;
                        j++;
                    }
                }

                while (znach1 != -1)
                {
                    br.Write(znach1);
                    colwrite++;
                    if (brb.PeekChar() > -1) { znach1 = brb.ReadInt32(); colread++; }
                    else znach1 = -1;
                }
                while (znach2 != -1)
                {
                    br.Write(znach2);
                    colwrite++;
                    if (brc.PeekChar() > -1) { znach2 = brc.ReadInt32(); colread++; }
                    else znach2 = -1;
                }
            }
        }

        public void OnePhaseSimple(string a, int kol, ref int colread, ref int colwrite, ref int colsr, ref long time)
        {
            int k = 1;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            using (BinaryWriter bwc = new BinaryWriter(new FileStream("c.dat", FileMode.Create)))
            using (BinaryWriter bwb = new BinaryWriter(new FileStream("b.dat", FileMode.Create)))
            using (BinaryReader br = new BinaryReader(new FileStream(a, FileMode.Open)))
            {
                while (br.PeekChar() > -1)
                {
                    for (int i = 0; i < k; i++)
                    {
                        if (br.PeekChar() > -1)
                        {
                            int znach = br.ReadInt32();
                            colread++;
                            bwb.Write(znach);
                            colwrite++;
                        }
                    }
                    for (int i = 0; i < k; i++)
                    {
                        if (br.PeekChar() > -1)
                        {
                            int znach = br.ReadInt32();
                            colread++;
                            bwc.Write(znach);
                            colwrite++;
                        }
                    }
                }
                br.Close();
                bwb.Close();
                bwc.Close();

            }

            while (k < kol)
            {
                sortOnesr(ref colread, ref colwrite, ref colsr, ref k, new FileStream("b.dat", FileMode.Open), new FileStream("c.dat", FileMode.Open), new FileStream("d.dat", FileMode.Create), new FileStream("e.dat", FileMode.Create));
                k *= 2;

                sortOnesr(ref colread, ref colwrite, ref colsr, ref k, new FileStream("d.dat", FileMode.Open), new FileStream("e.dat", FileMode.Open), new FileStream("b.dat", FileMode.Create), new FileStream("c.dat", FileMode.Create));
                k *= 2;
            }
            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;
            if (File.Exists(a)) File.Delete(a);
            File.Move("b.dat", a);
        }

        private void sortOnesr(ref int colread, ref int colwrite, ref int colsr, ref int k, FileStream b, FileStream c, FileStream d, FileStream e)
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
                    colread++;
                }
                if (brc.PeekChar() > -1)
                {
                    znach2 = brc.ReadInt32();
                    colread++;
                }

                int ind = 1;
                while (znach1 != -1 && znach2 != -1)
                {
                    int i = 0;
                    int j = 0;
                    while (i < k && j < k && znach1 != -1 && znach2 != -1)
                    {
                        colsr++;
                        if (znach1 < znach2)
                        {
                            if (ind % 2 != 0) { bwd.Write(znach1); colwrite++; }
                            else { bwe.Write(znach1); colwrite++; }
                            if (brb.PeekChar() > -1) { znach1 = brb.ReadInt32(); colread++; }
                            else znach1 = -1;
                            i++;
                        }
                        else
                        {
                            if (ind % 2 != 0) { bwd.Write(znach2); colwrite++; }
                            else { bwe.Write(znach2); colwrite++; }
                            if (brc.PeekChar() > -1) { znach2 = brc.ReadInt32(); colread++; }
                            else znach2 = -1;
                            j++;
                        }
                    }

                    while (i < k && znach1 != -1)
                    {
                        if (ind % 2 != 0) bwd.Write(znach1);
                        else bwe.Write(znach1);
                        colwrite++;
                        if (brb.PeekChar() > -1) { znach1 = brb.ReadInt32(); colread++; }
                        else znach1 = -1;
                        i++;
                    }
                    while (j < k && znach2 != -1)
                    {
                        if (ind % 2 != 0) bwd.Write(znach2);
                        else bwe.Write(znach2);
                        colwrite++;
                        if (brc.PeekChar() > -1) { znach2 = brc.ReadInt32(); colread++; }
                        else znach2 = -1;
                        j++;
                    }
                    ind++;
                }

                while (znach1 != -1)
                {
                    if (ind % 2 != 0) bwd.Write(znach1);
                    else bwe.Write(znach1);
                    colwrite++;
                    if (brb.PeekChar() > -1) { znach1 = brb.ReadInt32(); colread++; }
                    else znach1 = -1;
                }
                while (znach2 != -1)
                {
                    if (ind % 2 != 0) bwd.Write(znach2);
                    else bwe.Write(znach2);
                    colwrite++;
                    if (brc.PeekChar() > -1) { znach2 = brc.ReadInt32(); colread++; }
                    else znach2 = -1;
                }
            }
        }
    }
}
