using System;
using System.Collections.Generic;
using System.Text;

namespace data_structure_tasks.Priority_Queues
{
    //https://stepik.org/lesson/41560/step/1?unit=20013
    class PriorityHeap<T>
    {
        public enum ModeEnum
        {
            min,
            max,
        }

        private List<T> _data;
        private HeapComparer comparer;

        Queue<(int f, int s)> answer = new Queue<(int f, int s)>();
        public int Count { get; private set; }


        public T Max
        {
            get { 
                if(Count == 0)
                {
                    return default(T);
                }
                return _data[0];
            }  
        }
        private int Parent(int i) => (i-1) / 2;
        private int LeftChild(int i) => 2 * i + 1;
        private int RightChild(int i) => 2 * i + 2;
        public ModeEnum Mode { get; private set; }
        public PriorityHeap()
        {
            _data = new List<T>();
            Mode = ModeEnum.min;
            Count = 0;
            comparer = new HeapComparer();
            //Console.WriteLine(comparer.Compare(p1, p2));
        }
        public PriorityHeap(IEnumerable<T> collection)
        {
            _data = new List<T>(collection);
            Mode = ModeEnum.min;
            Count = _data.Count;

            comparer = new HeapComparer();


            for (int i = Count - 1; i >= 0; i--)
            {
                SiftDown(i);
            }           
        }
        public void PrintAnswer()
        {
            Console.WriteLine(answer.Count);
            if (answer.Count != 0)
            {
                foreach (var item in answer)
                {
                    Console.WriteLine($"{item.f} {item.s}");
                }
            }
        }
        public PriorityHeap<T> Insert(T value)
        {
            Count++;
            _data.Add(value);
            SiftUp(Count-1);
            return this;
        }
        public T ExtraxtMax()
        {
            T result = Max;
            _data[0] = _data[Count - 1];
            _data.RemoveAt(Count-1);
            Count--;
            SiftDown(0);
            return result;
        }
        //public T Remove(int i)
        //{
        //    T result = _data[i];
        //    _data[i] = object.
        //    return result;
        //}
        public void ChangePriorityElem(int i, T value)
        {
            T old = _data[i];
            _data[i] = value;

            if(comparer.Compare(_data[i], old, Mode) > 0)
            {
                SiftUp(i);
            }
            else
            {
                SiftDown(i);
            }
        }
        private void SiftDown(int number)
        {
            int l, r, index = number;

            while (true)
            {
                l = LeftChild(number);
                if ((l < Count) && comparer.Compare(_data[l], _data[index], Mode) > 0)
                {
                    index = l;
                }

                r = RightChild(number);
                if ((r < Count) && comparer.Compare(_data[r], _data[index], Mode) > 0)
                {
                    index = r;
                }

                if (index != number)
                {
                    (_data[number], _data[index]) = (_data[index], _data[number]);
                    answer.Enqueue((number, index));
                    number = index;
                }
                else
                    break;
            } 
        }
        private void SiftUp(int number)
        {
            int parent = Parent(number);
            while (number>0 && comparer.Compare(_data[number], _data[parent] , Mode) > 0)//return 1 _data[number] > if _data[Parent(number)]
            {
                (_data[number], _data[parent]) = (_data[parent], _data[number]);
                number = Parent(number);
                parent = Parent(number);
            }
        }
        class HeapComparer : IComparer<T>
        {
            /// <summary>
            /// по умолчанию min
            /// </summary>
            /// <param name="p1"></param>
            /// <param name="p2"></param>
            /// <returns></returns>
            public int Compare(T p1, T p2)
            {
                if (p1 is null || p2 is null)
                    throw new ArgumentException("Некорректное значение параметра - null");
                if (!(p1 is IComparable<T> && p2 is IComparable<T>))
                    throw new ArgumentException("параметр(ы) не поддерживают IComparable<T>");
                return ((IComparable<T>)p1).CompareTo(p2);
            }
            public int Compare(T p1, T p2, ModeEnum Mode)
            {
                if (p1 is null || p2 is null)
                    throw new ArgumentException("Некорректное значение параметра - null");
                if (!(p1 is IComparable<T> && p2 is IComparable<T>))
                    throw new ArgumentException("параметр(ы) не поддерживают IComparable<T>");

                if (Mode == ModeEnum.max)
                    return ((IComparable<T>)p1).CompareTo(p2);
                else
                    return ((IComparable<T>)p2).CompareTo(p1);
            }
        }
    }
}
