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

        //public void RemoveItem(int value) // удалить узел по значению
        //{
        //    if (rootNode == null)
        //        throw new Exception("Дерево не посажено");
        //    TreeNode delNode = GetNodeByValue(value);
        //    if (delNode.LeftChild == null && delNode.RightChild == null)
        //    {

        //    }
        //}
    }
}
