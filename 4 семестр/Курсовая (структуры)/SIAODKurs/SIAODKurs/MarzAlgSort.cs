using System.Diagnostics;

namespace SIAODKurs
{
    class MarzAlgSort
    {
        public float Sort( int[] Mass, int N)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int[] x = { 1, 4, 10, 23, 57, 132, 301, 701, 1750 };
            int i = 4;

            if (N >= 1750) i = 8;
            else
            {
                if (N >= 701) i = 7;
                else
                {
                    if (N >= 301) i = 6;
                    else
                    {
                        if (N >= 132) i = 5;
                    }
                }
            }

            while (x[i] >= 0)
            {
                for (int j = 1 + x[i]; j < N; j++)
                {
                    int a = (j - x[i]);
                    Mass[0] = Mass[j];

                    do
                    {
                        if (Mass[a] > Mass[0])
                        {
                            Mass[a + x[i]] = Mass[a];
                            Mass[a] = Mass[0];
                        }
                        else break;

                    } while ((a -= x[i]) > 0);
                }
                if (x[i] == 1) break;
                i--;
            }
            sw.Stop();
            float t = sw.ElapsedTicks;
            return t;
        }
    }
}
