using System;
using System.Collections.Generic;
using System.Text;


//https://stepik.org/lesson/41563/step/4?unit=20012
namespace data_structure_tasks.AVL_trees
{
    class SearchTrees
    {
        public int Count { get; set; }
        private Node Root { get; set; }
        public SearchTrees()
        {
            Count = 0;
            Root = null;
        }
        public int? Find(int value)
        {
            if (Finding(value, Root) is Node node)
                return node.Key;
            else
                return null;
        }
        public Node? FindNode(int value)
        {
            if (Finding(value, Root) is Node node)
                return node;
            else
                return null;
        }
        private Node? Finding(int key, Node node)
        {
            if (node == null)
                return null;
            if (key == node.Key)
                return node;
            else if (key > node.Key)
                return Finding(key, node.Right);
            else
                return Finding(key, node.Left);
        }
        public void Add(int value)
        {
            if(Root == null)
            {
                Root = new Node(value);
                Count++;
            }
            else
            {
                Adding(Root, value);
                Count++;
            }
        }
        //рекурсивный метод добавления числа и подсчета высоты каждого узла
        private int Adding(Node node, int value)
        {
            //значение уходит влево
            if (node.Key > value)
            {
                //если левый сын не занят то прикрепляется 
                if (node.Left == null)
                {
                    node.Left = new Node(value)
                    {
                        Parent = node
                    };
                    //если нету правого сына но высоата изменилась
                    if (node.Right == null)
                    {
                        node.Hight++;
                        return 1;
                    }        
                    else
                        return 0;
                }
                //иначе уходит в глубь левого сына
                else
                {
                    if(Adding(node.Left, value) == 1 && (node.Right == null || node.Left.Hight > node.Right.Hight))
                    {
                        node.Hight++;
                    }           
                    return Cheak(node);
                }
            }
            //вправо
            else
            {
                //если правый сын не занят то прикрепляется
                if (node.Right == null)
                {
                    node.Right = new Node(value)
                    {
                        Parent = node
                    };
                    //если нету левого сына но высоата изменилась
                    if (node.Left == null)
                    {
                        node.Hight++;
                        return 1;//1
                    }
                    else
                        return 0;
                }
                //иначе уходит в глубь правого сына
                else
                {
                    if (Adding(node.Right, value) == 1 && (node.Left == null || node.Right.Hight > node.Left.Hight))
                    {
                        node.Hight++;
                    }    
                    return Cheak(node);
                }
            }
        }
        //проверяет высоту дерева и если это дерево выше, то уровнавешивает с соседом
        private int Cheak(Node node)//возращает 0 если произошло уровновешивание
        {
            if(node.Parent != null)
            {
                //right longer
                if((node.Parent.Left == null && node.Hight == 1)||
                    (node.Hight - node.Parent.Left.Hight == 2))
                {
                    //малое вращение
                    if (node.Right != null && node.Right.Hight >= node.Left.Hight)
                    {
                        Node parent = node.Parent;
                        Node left = node.Left;

                        node.Parent = parent.Parent;
                        node.Left = parent;
                        parent.Parent = node;

                        parent.Right = left;
                        if (left != null)
                            left.Parent = parent;

                        if (Root == parent)
                            Root = node;
                        parent.Hight--;
                        return 0;
                    }
                    else//большое вращение
                    {
                        Node parent = node.Parent;
                        Node left = node.Left.Left;
                        Node right = node.Left.Right;
                        Node mainNode = node.Left;

                        parent.Right = left;
                        left.Parent = parent;

                        node.Left = right;
                        if (right != null)
                            right.Parent = node;

                        mainNode.Left = parent;
                        mainNode.Right = node;
                        mainNode.Parent = parent.Parent;
                        parent.Parent = mainNode;
                        node.Parent = mainNode;

                        if (Root == parent)
                            Root = mainNode;

                        parent.Hight--;
                        mainNode.Hight++;
                        return 0;
                    }
                }
                //left longer
                else if((node.Parent.Right == null && node.Hight == 1) ||
                    (node.Hight - node.Parent.Right.Hight == 2))
                {
                    //малое вращение
                    if (node.Left != null && node.Left.Hight >= node.Right.Hight)
                    {
                        Node parent = node.Parent;
                        Node right = node.Right;

                        node.Parent = parent.Parent;
                        node.Right = parent;
                        parent.Parent = node;

                        parent.Left = right;
                        if (right != null)
                            right.Parent = parent;

                        if (Root == parent)
                            Root = node;
                        parent.Hight--;
                        return 0;
                    }
                    else//большое вращение
                    {
                        Node parent = node.Parent;
                        Node left = node.Right.Left;
                        Node right = node.Right.Right;
                        Node mainNode = node.Right;

                        parent.Left = right;
                        right.Parent = parent;

                        node.Right = left;
                        if (left != null)
                            left.Parent = node;

                        mainNode.Right = parent;
                        mainNode.Left = node;
                        mainNode.Parent = parent.Parent;
                        parent.Parent = mainNode;
                        node.Parent = mainNode;

                        if (Root == parent)
                            Root = mainNode;

                        parent.Hight--;
                        mainNode.Hight++;
                        return 0;
                    }
                }      
                
            }
            return 1;
        }
        //public bool Delete(int value)
        //{
        //    if(Finding(value, Root) is Node node)
        //    {
        //        if(node.Left == null && node.Right == null)
        //        {
        //            node.Parent.
        //        }

        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        public class Node
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
