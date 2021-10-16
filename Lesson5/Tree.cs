using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Tree
    {
        public TreeNode rootNode { get; set; }
        public void AddItem(int value)
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
                    if (curNode.rightChild == null)
                    {
                        curNode.rightChild = newNode;
                        added = true;
                    }
                    else
                    {
                        curNode = curNode.rightChild;
                    }
                }
                if (value < curNode.Value)
                {
                    if (curNode.leftChild == null)
                    {
                        curNode.leftChild = newNode;
                        added = true;
                    }
                    else
                    {
                        curNode = curNode.leftChild;
                    }
                }
            }
            while (!added);
        }
        public void PrintTree(TreeNode startNode, string indent = "")
        {
            if (startNode != null)
            {
                Console.WriteLine($"{indent} - [{startNode.Value}]");

                indent += new string(' ', 3);

                PrintTree(startNode.leftChild, indent);

                PrintTree(startNode.rightChild, indent);
            }
        }
        public void BFS(int value)
        {
            if (rootNode == null)
            {
                return;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();

            bool finded = false;

            string str = $"Looking for value {value}{Environment.NewLine}";

            queue.Enqueue(rootNode);
            str += $"Add value {rootNode.Value} to the queue{Environment.NewLine}";

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                str += $"Fetch value {node.Value} from the queue{Environment.NewLine}";

                if (node.Value == value)
                {
                    str += $"Bingo! {node.Value} is equal to {value}{Environment.NewLine}";
                    finded = true;
                    break;
                }

                else
                {
                    str += $"{node.Value} is not equal to {value}{Environment.NewLine}Continue searching...{Environment.NewLine}";
                }

                if (node.leftChild != null)
                {
                    queue.Enqueue(node.leftChild);
                    str += $"Add value {node.leftChild.Value} from the left subtree to the queue{Environment.NewLine}";
                }

                else
                {
                    str += $"The left subtree is empty{Environment.NewLine}";
                }

                if (node.rightChild != null)
                {
                    queue.Enqueue(node.rightChild);
                    str += $"Add value {node.rightChild.Value} from the right subtree to the queue{Environment.NewLine}";
                }

                else
                {
                    str += $"The right subtree is empty{Environment.NewLine}";
                }
            }

            if (!finded)
            {
                str += $"Value {value} not found{Environment.NewLine}To be continued...";
            }

            Console.WriteLine(str);
        }
        public void DFS(int value)
        {
            if (rootNode == null)
            {
                return;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();

            bool finded = false;

            string str = $"Looking for value {value}{Environment.NewLine}";

            stack.Push(rootNode);
            str += $"Add value {rootNode.Value} to the stack{Environment.NewLine}";

            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                str += $"Fetch value {node.Value} from the stack{Environment.NewLine}";

                if (node.Value == value)
                {
                    str += $"Bingo! {node.Value} is equal to {value}{Environment.NewLine}";
                    finded = true;
                    break;
                }

                else
                {
                    str += $"{node.Value} is not equal to {value}{Environment.NewLine}Continue searching...{Environment.NewLine}";
                }

                if (node.leftChild != null)
                {
                    stack.Push(node.leftChild);
                    str += $"Add value {node.leftChild.Value} from the left subtree to the stack{Environment.NewLine}";
                }

                else
                {
                    str += $"The left subtree is empty{Environment.NewLine}";
                }

                if (node.rightChild != null)
                {
                    stack.Push(node.rightChild);
                    str += $"Add value {node.rightChild.Value} from the right subtree to the stack{Environment.NewLine}";
                }

                else
                {
                    str += $"The right subtree is empty{Environment.NewLine}";
                }
            }

            if (!finded)
            {
                str += $"Value {value} not found{Environment.NewLine}To be continued...";
            }

            Console.WriteLine(str);
        }
    }
}

