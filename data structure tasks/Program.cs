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
            
            Queue<int> answer = new Queue<int>();

            int[] temp = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int tableNum = temp[0];
            int actionNum = temp[1];
            int[] tableSizes = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            
            //PriorityHeap<int> heap = new PriorityHeap<int>(tableSizes);
            //int max = heap.Max;
            //int sum;

            DisjointSets set = new DisjointSets(tableSizes);

            for (int i = 0; i < actionNum; i++)
            {
                temp = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                set.Union(temp[0], temp[1]);

                answer.Enqueue(max);
            }

            foreach (var item in answer)
            {
                Console.WriteLine(item);
            }

            Console.Read();
        }
    }
}
