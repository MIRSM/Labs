namespace SIAOD10
{
    class Selection
    {
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
    }
}
