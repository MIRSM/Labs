using System.Diagnostics;

namespace SIAODKurs
{
    class FibAlgSort
    {
        public float Sort( int[] Mass, int N)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int[] x = {1,2,3,5,8,13,21,34,55,89,144,233,377,610,987,1597,2584,4181,6765};
            int i = 9;

            if (N >= 6756) i = 18;
            else
            {
                if (N >= 4181) i = 17;
                else
                {
                    if (N >= 2584) i = 16;
                    else
                    {
                        if (N >= 1597) i = 15;
                        else
                        {
                            if (N >= 987) i = 14;
                            else
                            {
                                if (N >= 610) i = 13;
                                else
                                {
                                    if (N >= 377) i = 12;
                                    else
                                    {
                                        if (N >= 233) i = 11;
                                        else
                                        {
                                            if (N >= 144) i = 10;
                                        }
                                    }
                                }
                            }
                        }
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
