using System;
using System.Collections.Generic;
using System.Text;

namespace data_structure_tasks
{
    class StackWithMax
    {
        Stack<int> data = new Stack<int>();
        Stack<int> dataMax = new Stack<int>();

        public int Count { get; private set; }

        public int Max
        {
            get {
                if (Count == 0)
                    return 0;
                return dataMax.Peek(); 
            }
        }

        public StackWithMax()
        {

        }

        public void Push(int value)
        {
            if (data.Count == 0)
            {
                Count++;
                data.Push(value);
                dataMax.Push(value);
            }
            else
            {
                data.Push(value);
                Count++;
                if (dataMax.Peek() > value)
                {
                    dataMax.Push(dataMax.Peek());
                }
                else
                {
                    dataMax.Push(value);
                }
                
            }
        }

        public int Peek()
        {
            try
            {
                return data.Peek();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Pop()
        {
            try
            {
                dataMax.Pop();
                Count--;
                return data.Pop();
            }catch(Exception ex)
            {
                throw ex;
            } 
        }
    }
}
