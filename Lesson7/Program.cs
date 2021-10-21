using System;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle(8, 9);

            Console.WriteLine(r.NumPath());

            Console.ReadKey();
        }
    }
}
