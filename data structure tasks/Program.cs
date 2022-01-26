using System;
using System.Collections.Generic;
using System.Linq;

using data_structure_tasks.Basic_data_structures;
using data_structure_tasks.Priority_Queues;
using data_structure_tasks.Disjoint_set_systems;

namespace data_structure_tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            DisjointSets sets = new DisjointSets();

            for (int i = 1; i < 7; i++)
            {
                sets.MakeSet(i);
            }

            Console.Read();
        }
    }
}
