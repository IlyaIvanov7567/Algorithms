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
            tree.AddItem(9);
            tree.AddItem(14);
            tree.AddItem(4);
            tree.AddItem(7);
            tree.AddItem(13);

            Console.WriteLine("До удаления узлов");
            tree.PrintTree(tree.rootNode, 20, 1);
            Console.WriteLine();
            Console.WriteLine($"Корнем дерева являетсяя узел со значением {tree.GetRoot().Value}");
            Console.WriteLine($"Родителем для узла со значением 14 явялется узел со значением {tree.GetParent(14).Value}");

            tree.Removeitem(10);
            tree.Removeitem(3);
            tree.Removeitem(8);

            Console.WriteLine();
            Console.WriteLine("После удаления узлов со значениями 3, 10 и 8");
            tree.PrintTree(tree.rootNode, 20, 10);
            Console.WriteLine();
            Console.WriteLine($"Корнем дерева являетсяя узел со значением {tree.GetRoot().Value}");
            Console.WriteLine($"Родителем для узла со значением 14 явялется узел со значением {tree.GetParent(14).Value}");

            Console.ReadKey();
        }
    }
}
