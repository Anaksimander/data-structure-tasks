using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


//https://stepik.org/lesson/45970/step/2?unit=24123
namespace data_structure_tasks.AVL_trees
{
    //ненавижу эту задачу :)
    class CheckingSearchTreeProperty
    {
        (int key, int left, int right)[] mass;
        private Node root;
        bool check = true;
        long lastelem = long.MinValue;

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
                root.Left = TieUp(mass[0].left, root);
                root.Right = TieUp(mass[0].right, root);

                InOrederLeft(root);
            }
            if (check)
                Console.WriteLine("CORRECT");
            else
                Console.WriteLine("INCORRECT");
        }
        private Node? TieUp(int i, Node parent)
        {
            if (i == -1)
                return null;
            Node node = new Node(mass[i].key) { Parent = parent };
            
            node.Left = TieUp(mass[i].left, node);
            node.Right = TieUp(mass[i].right, node);
            return node;
        }

        private void InOrederLeft(Node node)
        {
            if (node is null)
                return;
            InOrederLeft(node.Left);
            if(lastelem >= node.Key)
                if (node.Parent != null && node.Parent.Parent != null)
                {
                    if (node.Parent.Parent.Key != node.Key)
                        check = false;
                }
                else
                    if(node.Left.Right == null || node.Left.Right.Key != node.Key)
                        check = false;

            if (node.Parent != null && node.Key >= node.Parent.Key)
                check = false;

            lastelem = node.Key;

            InOrederRight(node.Right);
        }
        private void InOrederRight(Node node)
        {
            if (node is null)
                return;
            InOrederLeft(node.Left);
            if (lastelem > node.Key)
                check = false;
            lastelem = node.Key;
            InOrederRight(node.Right);
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
