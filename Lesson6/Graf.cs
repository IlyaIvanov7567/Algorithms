using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    class Graf
    {
        public static void DFS(int[,] w)
        {
            Console.WriteLine("---Обход в ширину---");
            int[] visited = new int[w.GetLength(0)]; // Пройденыные вершины: 0 - не пройдена, 1 - в очереди, 2 - пройдена

            var queue = new Queue<int>(); // Очередь

            int i = 0;

            queue.Enqueue(i);
            Console.WriteLine($"Добавляем в очередь вершину {i}");

            while (queue.Count > 0)
            {
                i = queue.Dequeue();
                Console.WriteLine($"Извлекаем из очереди вершину {i}");
                visited[i] = 2;

                for (int j = 0; j < w.GetLength(1); j++)
                {
                    if (w[i, j] != 0)
                    {
                        Console.WriteLine($"Найдена связь вершины {i} с вершиной {j}");
                        if (visited[j] == 0)
                        {
                            queue.Enqueue(j);
                            Console.WriteLine($"Добавляем в очередь вершину {j}");
                            visited[j] = 1;
                        }
                        else if (visited[j] == 1)
                        {
                            Console.WriteLine($"Не добавляем вершину {j} в очередь, так как вершина уже в очереди");
                        }
                        else
                        {
                            Console.WriteLine($"Не добавляем вершину {j} в очередь, так как вершина пройдена ранее");
                        }
                    }
                }
                Console.WriteLine($"Вершина {i} пройдена");
                Console.WriteLine();
            }
            Console.WriteLine("---Обход в ширину завершен---");
        }
        public static void BFS(int[,] w)
        {
            Console.WriteLine("---Обход в глубину---");
            int[] visited = new int[w.GetLength(0)]; // Пройденыные вершины: 0 - не пройдена, 1 - в очереди, 2 - пройдена

            var stack = new Stack<int>(); // стек

            int i = 0;

            stack.Push(i);
            Console.WriteLine($"Добавляем в стек вершину {i}");

            while (stack.Count > 0)
            {
                i = stack.Pop();
                Console.WriteLine($"Извлекаем из стека вершину {i}");
                visited[i] = 2;

                for (int j = 0; j < w.GetLength(1); j++)
                {
                    if (w[i, j] != 0)
                    {
                        Console.WriteLine($"Найдена связь вершины {i} с вершиной {j}");
                        if (visited[j] == 0)
                        {
                            stack.Push(j);
                            Console.WriteLine($"Добавляем в стек вершину {j}");
                            visited[j] = 1;
                        }
                        else if (visited[j] == 1)
                        {
                            Console.WriteLine($"Не добавляем вершину {j} в стек, так как вершина уже в стеке");
                        }
                        else
                        {
                            Console.WriteLine($"Не добавляем вершину {j} в стек, так как вершина пройдена ранее");
                        }
                    }
                }
                Console.WriteLine($"Вершина {i} пройдена");
                Console.WriteLine();
            }
            Console.WriteLine("---Обход в глубину завершен---");
        }
    }
}
