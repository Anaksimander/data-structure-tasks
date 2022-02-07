using System;
using System.Collections.Generic;
using System.Text;

namespace data_structure_tasks.Hash_tables
{
    class SampleSearch
    {
        double x = 263;
        double p = 1000000007;
        int pL, tL;
        double[] powX;

        LinkedList<int> answer = new LinkedList<int>();

        public SampleSearch(string pattern, string text)
        {
            pL = pattern.Length;
            tL = text.Length;
            powX = new double[pL];

            double h = 0;
            double l = 0;

            for (int i = 0; i < pL; i++)
            {
                powX[i] = Pow(x, i);
                h = (h + (pattern[i] * powX[i]) % p) % p;
            }

            for (int i = tL - pL, g = 0; i < tL; i++, g++)
            {
                l = (l + (text[i] * powX[g]) % p) % p;
            }

            if (l == h)
            {
                if (pattern[0] == text[tL - pL])
                    answer.AddLast(tL - pL);
            }

            if (tL > pL)
                for (int j = tL - pL - 1; j >= 0; j--)
                {
                    l = ((((l + p - (text[j + pL] * powX[pL - 1]) % p) % p) * x) % p
                      + (text[j])) % p;
                    if (l == h)
                        if (pattern[0] == text[j])
                            answer.AddFirst(j);
                }
        }


        private double Pow(double x, int y)
        {
            double result = x;
            if (y == 0)
                return 1.0;
            else if (y == 1)
            {
                return x;
            }
            else
                for (int i = 2; i <= y; i++)
                {
                    result *= x;
                    result = result % p;
                }
            return result;
        }

        public void Print()
        {
            foreach (var item in answer)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
