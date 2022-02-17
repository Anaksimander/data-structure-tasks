using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace data_structure_tasks.AVL_trees
{
    //https://stepik.org/lesson/45970/step/1?unit=24123
    class ComonTree
    {
        (int key, int left, int right)[] mass;
        private Node root;
        public ComonTree()
        {
            int n = int.Parse(Console.ReadLine());
            mass = new (int key, int left, int right)[n];

            int[] temp;
            for (int i = 0; i < n; i++)
            {
                temp = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                mass[i] = (temp[0], temp[1], temp[2]);
            }


            root = new Node(mass[0].key);
            root.Left = TieUp(mass[0].left);
            root.Right = TieUp(mass[0].right);

            InOreder(root);
            Console.WriteLine();
            PreOreder(root);
            Console.WriteLine();
            PostOreder(root);
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
            Console.Write($"{node.Key} ");
            InOreder(node.Right);
        }
        private void PreOreder(Node node)
        {
            if (node is null)
                return;
            Console.Write($"{node.Key} ");
            PreOreder(node.Left);
            PreOreder(node.Right);
        }
        private void PostOreder(Node node)
        {
            if (node is null)
                return;
            PostOreder(node.Left);
            PostOreder(node.Right);
            Console.Write($"{node.Key} ");
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
