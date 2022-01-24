using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace data_structure_tasks
{
    class MaximumInWindow
    {
        int num;
        int[] strNumbers;
        Queue<int> numersLine;
        int width;
        Queue<int> answer = new Queue<int>();
        StackWithMax leftStack = new StackWithMax();
        StackWithMax rightStack = new StackWithMax();
        public MaximumInWindow()
        {
            num = int.Parse(Console.ReadLine());
            strNumbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            width = int.Parse(Console.ReadLine());
            numersLine = new Queue<int>(strNumbers);
        }

        public void WorkOut()
        {

            for (int i = 0; i < width; i++)
            {
                leftStack.Push(numersLine.Dequeue());
            }
            while ((leftStack.Count + rightStack.Count == width) || (numersLine.Count != 0))
            {
                if (leftStack.Count + rightStack.Count < width)
                {
                    leftStack.Push(numersLine.Dequeue());
                }

                if (rightStack.Count == 0)
                {
                    for (int i = 0, j = leftStack.Count; i < j; i++)
                    {
                        rightStack.Push(leftStack.Pop());
                    }

                    if (leftStack.Max <= rightStack.Max)
                    {
                        answer.Enqueue(rightStack.Max);
                    }
                    else
                    {
                        answer.Enqueue(leftStack.Max);
                    }
                    rightStack.Pop();
                }
                else
                {
                    if(leftStack.Max < rightStack.Max)
                    {
                        answer.Enqueue(rightStack.Max);
                    }
                    else
                    {
                        answer.Enqueue(leftStack.Max);
                    }
                    rightStack.Pop();
                }
            }
            foreach (var item in answer)
            {
                Console.Write(item + " ");
            }
        }
    }
}
