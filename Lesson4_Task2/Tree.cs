using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4_Task2
{
    class Tree
    {
        public TreeNode rootNode { get; set; }
        public void AddItem(int value) // добавить узел
        {
            TreeNode newNode = new TreeNode { Value = value };
            TreeNode curNode = rootNode;
            bool added = false;

            if (curNode == null)
            {
                rootNode = newNode;
                return;
            }

            do
            {
                if (value >= curNode.Value)
                {
                    if (curNode.RightChild == null)
                    {
                        curNode.RightChild = newNode;
                        added = true;
                    }
                    else
                    {
                        curNode = curNode.RightChild;
                    }
                }
                if (value < curNode.Value)
                {
                    if (curNode.LeftChild == null)
                    {
                        curNode.LeftChild = newNode;
                        added = true;
                    }
                    else
                    {
                        curNode = curNode.LeftChild;
                    }
                }
            }
            while (!added);
        }
        public TreeNode GetNodeByValue(int value) //получить узел дерева по значению
        {

            TreeNode curNode = rootNode;
            bool finded = false;

            do
            {
                if (curNode == null)
                {
                    throw new Exception($"Узел со значением {value} не найден");
                }

                else if (curNode.Value == value)
                {
                    finded = true;
                    return curNode;
                }
                else if (curNode.Value > value)
                {
                    curNode = curNode.LeftChild;
                }
                else if (curNode.Value < value)
                {
                    curNode = curNode.RightChild;
                }

            }
            while (!finded);
            return curNode;
        }
        public TreeNode GetRoot()
        {
            if (rootNode == null)
                throw new Exception("Дерево не посажено");
            else
                return rootNode;
        }
        public void PrintTree(TreeNode node, int x, int y, int offset = 0) //вывести дерево в консоль
        {
            if (node != null)
            {
                if (offset == 0)
                    offset = x / 2;
                Console.SetCursorPosition(x, y);
                Console.WriteLine($"({node.Value})");
                PrintTree(node.LeftChild, x - offset, y + 1, offset / 2);
                PrintTree(node.RightChild, x + offset, y + 1, offset / 2);
            }
        }
        public TreeNode GetParent(int value)
        {
            TreeNode parent = null;
            TreeNode curNode = rootNode;
            bool got = false;
            do
            {
                if (curNode == null)
                {
                    throw new Exception($"Не найден узел со значением {value}");
                }
                else if (curNode.Value == value)
                {
                    got = true;
                }
                else if (curNode.Value > value)
                {
                    parent = curNode;
                    curNode = curNode.LeftChild;
                }
                else if (curNode.Value < value)
                {
                    parent = curNode;
                    curNode = curNode.RightChild;
                }
            }
            while (!got);
            return parent;
        }
        public void Removeitem(int value) // удалить узел по значению
        {
            TreeNode parent = GetParent(value);
            TreeNode removeNode = GetNodeByValue(value);

            if (rootNode.Value == value) // удаление корня
            {
                TreeNode replacenNode = removeNode.RightChild;
                
                while (replacenNode.LeftChild != null)
                {
                    replacenNode = replacenNode.LeftChild;
                }
                
                replacenNode.RightChild = rootNode.RightChild;
               
                replacenNode.LeftChild = rootNode.LeftChild;
                
                GetParent(replacenNode.Value).LeftChild = null;
                
                rootNode.LeftChild = null;
                
                rootNode.RightChild = null;
                
                rootNode = replacenNode;
            }

            else if (removeNode.RightChild == null && removeNode.LeftChild == null) // удаление листьев
            {
                if (parent.Value > value)
                {
                    parent.LeftChild = null;
                }
                else
                {
                    parent.RightChild = null;
                }
            }
            else if (removeNode.RightChild == null) // удаление узла имеющего только левого потомка
            {
                if (parent.Value > value)
                {
                    parent.LeftChild = removeNode.LeftChild;
                }
                else
                {
                    parent.RightChild = removeNode.LeftChild;
                }
            }
            else if (removeNode.LeftChild == null) // удаление узла имеющего только правого потомка
            {
                if (parent.Value > value)
                {
                    parent.LeftChild = removeNode.RightChild;
                }
                else
                {
                    parent.RightChild = removeNode.RightChild;
                }
            }
            else // удаление узла имеющего обоих потомков
            {

                TreeNode replaceNode = removeNode.RightChild;

                while (replaceNode.LeftChild != null)
                {
                    replaceNode = replaceNode.LeftChild;
                }

                replaceNode.RightChild = removeNode.RightChild;
                
                replaceNode.LeftChild = removeNode.LeftChild;
               
                GetParent(replaceNode.Value).LeftChild = null;

                if (parent.Value > value)
                {
                    parent.LeftChild = replaceNode;

                }
                else
                {
                    parent.RightChild = replaceNode;
                }
            }
        }
    }
}
