using System;
using System.Collections.Generic;
using System.Linq;

using data_structure_tasks.Basic_data_structures;
using data_structure_tasks.Priority_Queues;
using data_structure_tasks.Disjoint_set_systems;
using data_structure_tasks.Hash_tables;

namespace data_structure_tasks
{
    class Program
    {
        static void Main(string[] args)
        {           
            int n  = int.Parse(Console.ReadLine());
            Queue<string> answer = new Queue<string>();
            string[] str;
            PhoneBook phoneBook = new PhoneBook();
            int temp;

            for (int i = 0; i < n; i++)
            {
                str = Console.ReadLine().Split(' ');

                switch (str[0])
                {
                    case "add":
                        temp = int.Parse(str[1]);
                        phoneBook.Add(temp, str[2]);
                        break;
                    case "del":
                        temp = int.Parse(str[1]);
                        phoneBook.Del(temp);
                        break;
                    case "find":
                        temp = int.Parse(str[1]);
                        answer.Enqueue(phoneBook.Find(temp));
                        break;
                    default:
                        break;
                }
            }

            foreach (var item in answer)
            {
                Console.WriteLine(item);
            }

            
            Console.Read();
        }
    }
}
