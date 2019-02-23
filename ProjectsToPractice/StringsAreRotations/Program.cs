using System;

namespace StringsAreRotations
{
    class Program
    {

        public static int GetRotationAmount(string first, string second)
        {
            int n = first.Length;
            int m = second.Length;

            if (n != m)
            {
                return -1;
            }

            int[] lps = new int[n];
            int len = 0;
            int i = 1;

            lps[0] = 0;

            while (i < n)
            {
                if (first[i] == second[len])
                {
                    lps[i] = ++len;
                    ++i;
                }
                else
                {
                    if (len == 0)
                    {
                        lps[i] = 0;
                        ++i;
                    }
                    else
                    {
                        len = lps[len - 1];
                    }
                }
            }

            i = 0;


            for (int k = lps[n-1]; k < m; ++k)
            {
                if(second[k] != first[i++])
                {
                    return -1; 
                }
            }

            return len; 
        }

        static void Main(string[] args)
        {
            int amount = GetRotationAmount("ABACD", "CDABA");
            Console.WriteLine("Rotasyon sayısı: " + amount);
        }
    }
}
