using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    class Rectangle
    {
        int M { get; set; }
        int N { get; set; }

        int[,] Arr;

        public Rectangle(int m, int n)
        {
            M = m;
            N = n;
            Arr = new int[m, n];
        }

        public int NumPath()
        {
            int i, j;
            for (i = 0; i < M; i++)
                Arr[i, 0] = 1;

            for (j = 0; j < N; j++)
                Arr[0, j] = 1;

            for (i = 1; i < M; i++)
            {
                for (j = 1; j < N; j++)
                    Arr[i, j] = Arr[i, j - 1] + Arr[i - 1, j];
            }

            return (Arr[M - 1, N - 1]);
        }
    }
}
