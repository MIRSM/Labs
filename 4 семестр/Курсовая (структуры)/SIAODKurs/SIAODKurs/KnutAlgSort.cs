using System.Diagnostics;

namespace SIAODKurs
{
    class KnutAlgSort
    {
        public float Sort( int[] Mass, int N)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int x = 1;

            while (x < N)
            {
                x = x * 3 + 1;
            }

            while (x >= 1)
            {
                for (int j = 1 + x; j < N; j++)
                {
                    int a = (j - x);
                    Mass[0] = Mass[j];

                    do
                    {
                        if (Mass[a] > Mass[0])
                        {
                            Mass[a + x] = Mass[a];
                            Mass[a] = Mass[0];
                        }
                        else break;

                    } while ((a -= x) > 0);
                }
                x =(x-1) / 3;
            }
            sw.Stop();
            float t = sw.ElapsedTicks;
            return t;
        }
    }
}
