using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace data_structure_tasks.Disjoint_set_systems
{
    //https://stepik.org/lesson/41560/step/3?unit=20013
    class DisjointSets
    {
        List<(int parent, int rank, int size)> _data;
        public DisjointSets()
        {
            _data = new List<(int, int, int)>();
            _data.Add((0, 0, 1));
        }
        public DisjointSets(int num)
        {
            _data = new List<(int, int, int)>(num);
            for (int i = 0; i < num; i++)
            {
                _data.Add((i, 0, 1));
            }
        }
        public DisjointSets(int[] collection)
        {
            _data = new List<(int, int, int)>(collection.Length);
            _data.Add((0, 0, 1));
            for (int i = 0; i < collection.Count(); i++)
            {
                _data.Add((i+1, 0, collection[i]));
            }
        }
        public DisjointSets MakeSet(int i)
        {
            //i -= 1;
            for (int j = _data.Count; _data.Count <= i; j++)
            {
                _data.Add((i, 0, 1));
            }

            _data[i] = (i, 0, 1);
            return this;
        }
        public int Find(int i)
        {
            if (i != _data[i].parent && _data[_data[i].parent].parent != _data[i].parent)
            {
                _data[i] = (Find(_data[i].parent), 0, 1);
                _data[_data[i].parent] = (_data[_data[i].parent].parent, _data[_data[i].parent].rank, _data[_data[i].parent].size + 1);
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

            if (_data[i_id].rank > _data[j_id].rank)
            {
                _data[j_id] = (i_id, _data[j_id].rank, _data[j_id].size);// узел j_id цепляется к узлу i_id
                _data[i_id] = (_data[i_id].parent, _data[i_id].rank, _data[i_id].size + _data[j_id].size);// увеличиваем размер 
            }
            else if (_data[i_id].rank == _data[j_id].rank)
            {
                _data[j_id] = (i_id, _data[j_id].rank, _data[j_id].size);// узел j_id цепляется к узлу i_id
                _data[i_id] = (_data[i_id].parent, _data[i_id].rank + 1, _data[i_id].size + _data[j_id].size);
            }
            else
            {
                _data[i_id] = (j_id, _data[i_id].rank, _data[i_id].size);
                _data[j_id] = (_data[j_id].parent, _data[j_id].rank, _data[j_id].size + _data[i_id].size);
            }
        }
        public (int parent, int rank, int size) this[int index]
        {
            get
            {
                return _data[index];
            }
        }

    }
}
