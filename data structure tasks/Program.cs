using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using data_structure_tasks.Basic_data_structures;
using data_structure_tasks.Priority_Queues;
using data_structure_tasks.Disjoint_set_systems;
using data_structure_tasks.Hash_tables;

namespace data_structure_tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(1, 10, Factorial);

            Console.ReadLine();
        }

        static void Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Console.WriteLine($"Факториал числа {x} равен {result}");
            Thread.Sleep(3000);
        }
    }
}
