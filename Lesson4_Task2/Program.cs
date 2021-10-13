using System;

namespace Lesson4_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.AddItem(8);
            tree.AddItem(3);
            tree.AddItem(10);
            tree.AddItem(1);
            tree.AddItem(6);
            tree.AddItem(14);
            tree.AddItem(4);
            tree.AddItem(7);
            tree.AddItem(13);

            Console.WriteLine(tree.GetParent(10).Value);

            //tree.PrintTree(tree.rootNode, 20, 0);
            
            Console.ReadKey();
        }
    }
}
