using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace SIAODKurs
{
    class VirtAlgSort
    {
        public float Sort( int[] Mass, int N, int P)
        {
            int[] points = new int[P + 1];
            for (int i = 0; i < P + 1; i++) points[i] = (int)(N / (P + 1));

            Stopwatch sw = new Stopwatch();
            sw.Start();

            int c = 2;
            int h = 1;

            while (c <= N)
            {
                c *= 2;
                h++;
            }
            h--;
            int x = 1;

            for (int s = h; s > 1; s--)
            {
                x = (2 * x) + 1;
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
                x /= 2;
            }
            sw.Stop();
            float t = sw.ElapsedTicks;
            return t;
        }
    }
}
