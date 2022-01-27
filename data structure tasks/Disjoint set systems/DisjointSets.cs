using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace data_structure_tasks.Disjoint_set_systems
{
    //https://stepik.org/lesson/41235/?unit=19819
    class DisjointSets
    {
        List<(int parent, int rank)> _data;
        public DisjointSets()
        {
            _data = new List<(int, int)>();
            _data.Add((0, 0));
        }
        public DisjointSets(int num)
        {
            _data = new List<(int, int)>(num);
            for (int i = 0; i < num; i++)
            {
                _data.Add((i, 0));
            }
        }
        public DisjointSets(int[] collection)
        {
            _data = new List<(int, int)>(collection.Length);
            _data.Add((0, 0));
            for (int i = 0; i < collection.Length; i++)
            {
                _data.Add((i+1, 0));
            }
        }
        public DisjointSets MakeSet(int i)
        {
            //i -= 1;
            for (int j = _data.Count; _data.Count <= i; j++)
            {
                _data.Add((i, 0));
            }

            _data[i] = (i, 0);
            return this;
        }
        public int Find(int i)
        {
            if (i != _data[i].parent && _data[_data[i].parent].parent != _data[i].parent)
            {
                _data[i] = (Find(_data[i].parent), 0);
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
                _data[j_id] = (i_id, _data[j_id].rank);// узел j_id цепляется к узлу i_id
            }
            else if (_data[i_id].rank == _data[j_id].rank)
            {
                _data[j_id] = (i_id, _data[j_id].rank);// узел j_id цепляется к узлу i_id
            }
            else
            {
                _data[i_id] = (j_id, _data[i_id].rank);
            }
        }
        public (int parent, int rank) this[int index]
        {
            get
            {
                return _data[index];
            }
        }
    }
}
