using System;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree myTree = new Tree();

            Random rnd = new Random();

            for (int i = 0; i <= 10; i++)
            {
                myTree.AddItem(rnd.Next(1, 15));
            }

            myTree.PrintTree(myTree.rootNode, "");

            Console.WriteLine("----------BFS----------");
            myTree.BFS(4);

            Console.WriteLine("----------DFS----------");
            myTree.DFS(4);

            Console.ReadKey();
        }
    }
}
