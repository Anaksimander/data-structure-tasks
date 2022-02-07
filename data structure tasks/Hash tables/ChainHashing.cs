using System;
using System.Collections.Generic;
using System.Text;

namespace data_structure_tasks.Hash_tables
{
    class ChainHashing
    {
        LinkedList<string>[] mass;
        double x = 263;
        double p = 1000000007;
        double m;

        Queue<string> answer = new Queue<string>();

        public ChainHashing(int size)
        {
            mass = new LinkedList<string>[size];
            m = size;
            for (int i = 0; i < m; i++)
            {
                mass[i] = new LinkedList<string>();
            }                    
        }

        private int H(string str)
        {
            double h = 0;
            for (int i = 0; i < str.Length; i++)
            {
                h = (h + (str[i] * Pow(x, i))) % p;     
            }
            //h = h % p;
            h = h % m;
            return (int)h;
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

        public void Add(string str)
        {
            int h = H(str);
            if (mass[h].Find(str) == null)
                mass[h].AddFirst(str);
        }
        public void Del(string str)
        {
            int h = H(str);
            if(mass[h].Find(str) != null)
                mass[h]?.Remove(mass[h]?.Find(str));
        }
        public void Find(string str)
        {
            int h = H(str);
            if (mass[h].Find(str) == null)
                answer.Enqueue("no");
            else
                answer.Enqueue("yes");
        }
        public void Check(int i)
        {
            StringBuilder sb = new StringBuilder();
            //string temp;
            if (mass[i].Count == 0)
                answer.Enqueue(" ");
            else
                foreach (var item in mass[i])
                {
                    sb.Append($"{item} ");
                }
                answer.Enqueue(sb.ToString());
        }
        public void printAnswer()
        {
            foreach (var item in answer)
            {
                Console.WriteLine(item);
            }
        }
    }
}
