using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace data_structure_tasks.Priority_Queues
{
    //https://stepik.org/lesson/41560/step/2?unit=20013
    
    class ParallelProcessing 
    {
        long[] processes;
        int processorsNum, processesNum;
        PriorityHeap<(long, long)> workHeap;
        public ParallelProcessing()
        {
            int[] temp = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            processorsNum = temp[0];
            processesNum = temp[1];
            processes = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();
            workHeap = new PriorityHeap<(long, long)>();

            for (int i = 0; i < processorsNum; i++)
            {
                workHeap.Insert((0L, i));
            }
            foreach (var item in processes)
            {
                var tempCort = workHeap.ExtraxtMax();

                Console.WriteLine($"{tempCort.Item2} {tempCort.Item1}");

                workHeap.Insert((tempCort.Item1 + item, tempCort.Item2));
            }
        }
    }
}
