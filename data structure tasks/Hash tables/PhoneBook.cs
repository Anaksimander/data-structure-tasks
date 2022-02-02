using System;
using System.Collections.Generic;
using System.Text;

namespace data_structure_tasks.Hash_tables
{
    //https://stepik.org/lesson/41562/step/1?unit=20016
    class PhoneBook
    {
        public string[] names;
        public PhoneBook()
        {
            names = new string[10000000];
        }
        public void Add(int number, string name)
        {
            names[number] = name;
        }
        public void Del(int number)
        {
            if(names[number] != null)
            {
                names[number] = null;
            }
        }
        public string Find(int number)
        {
            if(names[number] == null)
            {
                return "not found";
            }
            else
            {
                return names[number];
            }
        }
    }
}
