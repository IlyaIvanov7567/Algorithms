using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] w = new int[6, 6] // Матрица связанности
            {
                {0, 1, 1, 0, 0, 0},
                {1, 0, 1, 1, 0, 0},
                {1, 1, 0, 1, 1, 0},
                {0, 1, 1, 0, 1, 1},
                {0, 0, 1, 1, 0, 1},
                {0, 0, 0, 1, 1, 0}
            };

            for (int k = 0; k < w.GetLength(0); k++) // Вывод матрицы для наглядности
            {
                for (int j = 0; j < w.GetLength(1); j++)
                {
                    Console.Write($"{w[k, j]}  ");
                }
                Console.WriteLine();
            }

            Graf.DFS(w);

            Console.ReadKey();
        }
    }
}
