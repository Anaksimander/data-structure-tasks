using System;
using System.Collections.Generic;
using System.Text;

namespace data_structure_tasks.Hash_tables
{
    //https://stepik.org/lesson/41562/step/3?unit=20016
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
                h = (h + (pattern[i] * Pow(x,i)) % p) % p;
            }

            for (int i = tL - pL, g = 0; i < tL; i++, g++)
            {
                l = (l + (text[i] * Pow(x, g)) % p) % p;
            }

            if (l == h)
            {
                if (pattern[0] == text[tL - pL])
                    answer.AddLast(tL - pL);
            }

            if (tL > pL)
                for (int j = tL - pL - 1; j >= 0; j--)
                {
                    l = ((((l + p - (text[j + pL] * Pow(x,pL - 1)) % p) % p) * x) % p
                      + (text[j])) % p;
                    if (l == h)
                        if (pattern[0] == text[j])
                            answer.AddFirst(j);
                }
        }


        private double Pow(double x, int y)
        {
            if (y == 0)
            {
                powX[0] = 1;
                return 1.0;
            }      
            else if (y == 1)
            {
                powX[1] = x;
                return x;
            }
            else
                if(powX[y] == 0)
                    powX[y] = powX[y-1] * x % p;
            return powX[y];
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
