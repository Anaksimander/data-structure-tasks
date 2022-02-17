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
        //рекурсивный метод добавления числа и подсчета высоты узла
        private int Adding(Node node, int value)
        {
            //значение уходит влево
            if (node.Key > value)
            {
                //если левый сын не занят то прикрепляется 
                if (node.Left == null)
                {
                    node.Left = new Node(value);
                    node.Left.Parent = node;
                    //если нету правого сына но высоата изменилась
                    if (node.Right == null)
                    {
                        node.Hight++;
                        return Cheak(node, "right");
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
                    return Cheak(node, "right");
                }
            }
            //вправо
            else
            {
                //если правый сын не занят то прикрепляется
                if (node.Right == null)
                {
                    node.Right = new Node(value);
                    node.Right.Parent = node;
                    //если нету левого сына но высоата изменилась
                    if (node.Left == null)
                    {
                        node.Hight++;
                        return Cheak(node, "right");//1
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
                    return Cheak(node, "right");
                }
            }
        }

        //проверяет высоту дерева и если это дерево выше, то уровнавешивает с соседом
        private int Cheak(Node node, string side)//возращает 0 если произошло уровновешивание
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
                    if (node.Left != null && node.Left.Hight >= node.Right.Hight)
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
                }      
                
            }
            return 1;
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
