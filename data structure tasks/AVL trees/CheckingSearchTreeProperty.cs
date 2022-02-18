using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


//https://stepik.org/lesson/45970/step/2?unit=24123
namespace data_structure_tasks.AVL_trees
{
    class CheckingSearchTreeProperty
    {
        (int key, int left, int right)[] mass;
        private Node root;
        bool check = true;
        int lastelem = int.MinValue;
        public CheckingSearchTreeProperty()
        {
            int n = int.Parse(Console.ReadLine());
            mass = new (int key, int left, int right)[n];

            int[] temp;
            for (int i = 0; i < n; i++)
            {
                temp = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                mass[i] = (temp[0], temp[1], temp[2]);
            }

            if (n > 0)
            {
                root = new Node(mass[0].key);
                root.Left = TieUp(mass[0].left);
                root.Right = TieUp(mass[0].right);

                InOreder(root);
            }
            if(check)
                Console.WriteLine("CORRECT");
            else
                Console.WriteLine("INCORRECT");
        }
        private Node? TieUp(int i)
        {
            if (i == -1)
                return null;
            Node node = new Node(mass[i].key);
            node.Left = TieUp(mass[i].left);
            node.Right = TieUp(mass[i].right);
            return node;
        }

        private void InOreder(Node node)
        {
            if (node is null)
                return;
            InOreder(node.Left);
            if (lastelem > node.Key)
                check = false;
            lastelem = node.Key;
            InOreder(node.Right);
        }

        private class Node
        {
            public int Key { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }
            public int Hight { get; set; }
            public Node(int key, Node parent = null)
            {
                Key = key;
                Left = null;
                Right = null;
                Parent = parent;
                Hight = 0;
            }
        }
    }
}
