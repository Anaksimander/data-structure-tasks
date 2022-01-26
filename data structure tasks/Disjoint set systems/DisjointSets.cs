using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace data_structure_tasks.Disjoint_set_systems
{
    //https://stepik.org/lesson/41560/step/3?unit=20013
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
        public DisjointSets(IEnumerable<int> collection)
        {
            _data = new List<(int, int)>(collection.Count());
            _data.Add((0, 0));
            for (int i = 1; i <= collection.Count(); i++)
            {
                _data.Add((i, 0));
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
            if (i != _data[i].parent)
            {
                _data[i] = (Find(_data[i].parent), _data[i].rank);
            }
            return _data[i].parent;
        }
        public int OldFind(int i)
        {
            while(i != _data[i].parent)
            {
                i = _data[i].parent;
            }
            return i;
        }

        public void Union(int i, int j)
        {
            int i_id = Find(i);
            int j_id = Find(j);
            if(i_id == j_id)
            {
                return;
            }

            if(_data[i_id].rank > _data[j_id].rank)
            {
                _data[j_id] = (i_id, _data[j_id].rank);
            }
            else if(_data[i_id].rank == _data[j_id].rank)
            {
                _data[j_id] = (i_id, _data[j_id].rank);
                _data[i_id] = (_data[i_id].parent, _data[i_id].rank + 1);
            }
            else
            {
                _data[i_id] = (j_id, _data[i_id].rank);
            }
        }
    }
}
