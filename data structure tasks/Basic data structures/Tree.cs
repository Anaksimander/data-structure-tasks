using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace data_structure_tasks.Basic_data_structures
{
    //https://stepik.org/lesson/41234/step/2?unit=19818
    class Tree
    {
        int num;
        int[] strNumbers;
        public Tree()
        {
            num = int.Parse(Console.ReadLine());
            strNumbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            Console.WriteLine(Height_prop);
        }

        private int Height_prop
        {
            get {
                int max=0;
                int temp;
                for (int i = 0; i < strNumbers.Length; i++)
                {
                    temp = Height(i, 0);
                    if (temp > max)
                        max = temp;
                }
                return max; 
            }
        }

        private int Height(int number, int height)
        {
            height++;
            if(strNumbers[number] == -1)
            {
                return height;
            }
            else
            {
                return Height(strNumbers[number], height);
            }
        }
    }
}
