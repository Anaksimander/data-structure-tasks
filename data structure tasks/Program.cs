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
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            SampleSearch s = new SampleSearch(str1, str2);
            s.Print();

        }


    }
}
