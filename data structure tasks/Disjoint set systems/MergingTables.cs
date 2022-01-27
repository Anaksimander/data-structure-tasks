using System;
using System.Collections.Generic;
using System.Text;

namespace data_structure_tasks.Disjoint_set_systems
{
    //https://stepik.org/lesson/41560/step/3?unit=20013
    class MergingTables
    {
        private List<(int parent, int size)> _data;
        public int Max { get; private set; } = int.MinValue;
        public MergingTables()
        {
            _data = new List<(int, int)>();
            _data.Add((0, 1));
        }
        public MergingTables(int num)
        {
            _data = new List<(int, int)>(num);
            for (int i = 0; i < num; i++)
            {
                _data.Add((i, 1));
            }
        }
        public MergingTables(int[] collection)
        {
            _data = new List<(int, int)>(collection.Length);
            _data.Add((0, 1));
            for (int i = 0; i < collection.Length; i++)
            {
                if(Max < collection[i])
                {
                    Max = collection[i];
                }
                _data.Add((i + 1, collection[i]));
            }
        }
        public MergingTables MakeSet(int i)
        {
            //i -= 1;
            for (int j = _data.Count; _data.Count <= i; j++)
            {
                _data.Add((i, 1));
            }

            _data[i] = (i, 1);
            return this;
        }
        public int Find(int i)
        {
            if (i != _data[i].parent && _data[_data[i].parent].parent != _data[i].parent)
            {
                _data[i] = (Find(_data[i].parent), 1);
                _data[_data[i].parent] = (_data[_data[i].parent].parent, _data[_data[i].parent].size);
            }
            return _data[i].parent;
        }
        public void Union(int i, int j)
        {
            int i_id = Find(i);
            int j_id = Find(j);
            if (i_id == j_id)
            {
                return;
            }

            _data[j_id] = (i_id, _data[j_id].size);// узел j_id цепляется к узлу i_id
            _data[i_id] = (_data[i_id].parent, _data[i_id].size + _data[j_id].size);// увеличиваем размер }
            if (Max < _data[i_id].size)
            {
                Max = _data[i_id].size;
            }
        }
        public (int parent, int size) this[int index]
        {
            get
            {
                return _data[index];
            }
        }
    }
}
