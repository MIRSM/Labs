using System.IO;

namespace SIAOD7
{
    class Sort
    {
        //однофазная сортировка
        public void sortOne(ref bool noots, FileStream b, FileStream c, FileStream d, FileStream e)
        {
            using (BinaryReader brb = new BinaryReader(b))
            using (BinaryReader brc = new BinaryReader(c))
            using (BinaryWriter bwd = new BinaryWriter(d))
            using (BinaryWriter bwe = new BinaryWriter(e))
            {
                int switcf = 1;

                int znach1 = brb.ReadInt32();
                int znach2 = brc.ReadInt32();

                int nextznach1 = znach1;
                int nextznach2 = znach2;

                int zapislast = -1;
                int zapis = -1;

                bool ser1 = true, ser2 = true;

                if (znach1 <= znach2)
                {
                    if (switcf == 1) WriteA1(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwd, brb);
                    else WriteA1(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brb);
                }
                else
                {
                    if (switcf == 1) WriteA1(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwd, brc);
                    else WriteA1(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brc);
                }

                while ((nextznach1 != -1) && (nextznach2 != -1))
                {
                    while (ser1 && ser2)
                    {
                        if (nextznach1 <= nextznach2)
                        {
                            if (switcf == 1) writeA(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwd, brb);
                            else writeA(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brb);

                        }
                        else
                        {
                            if (switcf == 1) writeA(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwd, brc);
                            else writeA(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwe, brc);

                        }
                    }

                    while (ser1)
                    {
                        if (switcf == 1) writeA(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwd, brb);
                        else writeA(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brb);

                    }

                    while (ser2)
                    {
                        if (switcf == 1) writeA(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwd, brc);
                        else writeA(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwe, brc);

                    }
                    if (switcf == 1) switcf = 2;
                    else switcf = 1;

                    ser1 = ser2 = true;
                }

                ser1 = ser2 = true;

                while (nextznach1 != -1)
                {
                    if (switcf == 1) writeA(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwd, brb);
                    else writeA(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brb);

                    if (znach1 > nextznach1)
                    {
                        if (switcf == 1) switcf = 2;
                        else switcf = 1;
                    }
                }

                while (nextznach2 != -1)
                {
                    if (switcf == 1) writeA(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwd, brc);
                    else writeA(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwe, brc);

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

        //однофазная сортировка (сравнение)
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
                    if (switcf == 1) WriteAsr(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwd, brb, ref colread, ref colwrite, ref colsr);
                    else WriteAsr(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brb, ref colread, ref colwrite, ref colsr);
                }
                else
                {
                    if (switcf == 1) WriteAsr(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwd, brc, ref colread, ref colwrite, ref colsr);
                    else WriteAsr(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwe, brc, ref colread, ref colwrite, ref colsr);
                }

                while ((nextznach1 != -1) && (nextznach2 != -1))
                {
                    while (ser1 && ser2)
                    {
                        if (nextznach1 <= nextznach2)
                        {
                            if (switcf == 1) WriteAsr1(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwd, brb, ref colread, ref colwrite, ref colsr);
                            else WriteAsr1(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brb, ref colread, ref colwrite, ref colsr);
                        }
                        else
                        {
                            if (switcf == 1) WriteAsr1(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwd, brc, ref colread, ref colwrite, ref colsr);
                            else WriteAsr1(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwe, brc, ref colread, ref colwrite, ref colsr);
                        }
                    }

                    while (ser1)
                    {
                        if (switcf == 1) WriteAsr1(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwd, brb, ref colread, ref colwrite, ref colsr);
                        else WriteAsr1(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brb, ref colread, ref colwrite, ref colsr);
                    }

                    while (ser2)
                    {
                        if (switcf == 1) WriteAsr1(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwd, brc, ref colread, ref colwrite, ref colsr);
                        else WriteAsr1(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwe, brc, ref colread, ref colwrite, ref colsr);
                    }

                    if (switcf == 1) switcf = 2;
                    else switcf = 1;

                    ser1 = ser2 = true;
                }

                ser1 = ser2 = true;

                while (nextznach1 != -1)
                {
                    if (switcf == 1) WriteAsr1(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwd, brb, ref colread, ref colwrite, ref colsr);
                    else WriteAsr1(ref znach1, ref nextznach1, ref zapislast, ref zapis, ref noots, ref ser1, bwe, brb, ref colread, ref colwrite, ref colsr);

                    if (znach1 > nextznach1)
                    {
                        if (switcf == 1) switcf = 2;
                        else switcf = 1;
                    }
                }

                while (nextznach2 != -1)
                {
                    if (switcf == 1) WriteAsr1(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwd, brc, ref colread, ref colwrite, ref colsr);
                    else WriteAsr1(ref znach2, ref nextznach2, ref zapislast, ref zapis, ref noots, ref ser2, bwe, brc, ref colread, ref colwrite, ref colsr);

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

        //запись в файл А (однофазная сортировка)
        public void WriteA1(ref int znach, ref int nextznach, ref int zapislast, ref int zapis, ref bool noots, ref bool ser1, BinaryWriter bw, BinaryReader brb)
        {
            bw.Write(znach);
            zapislast = zapis;
            zapis = znach;

            if (zapislast > zapis) noots = true;

            if (brb.PeekChar() != -1) nextznach = brb.ReadInt32();
            else nextznach = -1;

            if (znach > nextznach || nextznach == -1) ser1 = false;
        }

        //запись в файл А (сравнение, однофазная)
        public void WriteAsr(ref int znach, ref int nextznach, ref int zapislast, ref int zapis, ref bool noots, ref bool ser1, BinaryWriter bw, BinaryReader brb, ref int colread, ref int colwrite, ref int colsr)
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

            colsr++;

            if (znach > nextznach || nextznach == -1) ser1 = false;
        }

        //Запись в файл А (двухфазная сортировка)
        public void writeA(ref int znach, ref int nextznach, ref int zapislast, ref int zapis, ref bool noots, ref bool ser1, BinaryWriter bw, BinaryReader brb)
        {
            bw.Write(nextznach);
            znach = nextznach;
            zapislast = zapis;
            zapis = znach;

            if (zapislast > zapis) noots = true;

            if (brb.PeekChar() != -1) nextznach = brb.ReadInt32();
            else nextznach = -1;

            if (znach > nextznach || nextznach == -1) ser1 = false;
        }
        
        //Запись в файл А (сравнение, двухфазная)
        public void WriteAsr1(ref int znach, ref int nextznach, ref int zapislast, ref int zapis, ref bool noots, ref bool ser1, BinaryWriter bw, BinaryReader brb, ref int colread, ref int colwrite, ref int colsr)
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

            colsr++;

            if (znach > nextznach || nextznach == -1) ser1 = false;
        }

        //Разделение файла
        public void splitting(FileStream a, FileStream b, FileStream c)
        {
            using (BinaryWriter bwc = new BinaryWriter(c))
            using (BinaryWriter bwb = new BinaryWriter(b))
            using (BinaryReader br = new BinaryReader(a))
            {
                int file = 1;
                int znach = br.ReadInt32();
                int nextznach = br.ReadInt32();

                bwb.Write(znach);

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
                    }
                    else
                    {
                        bwc.Write(nextznach);
                    }

                    znach = nextznach;

                    if (br.PeekChar() > -1) nextznach = br.ReadInt32();
                    else nextznach = -1;
                }

                br.Close();
                bwb.Close();
                bwc.Close();
            }
        }

        //Разделение файла (сравнение)
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
                    colsr++;
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
            
    }
}
