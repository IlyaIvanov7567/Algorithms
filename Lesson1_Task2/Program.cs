using System;

// Асимптотическую сложность O(f(N) × g(N) × h(3N)) = O(f(N) × g(N) × h(N)) = 
// = O(f(N^3)) = O(f(inputArray.Length^3))

public static int StrangeSum(int[] inputArray)
{
    int sum = 0;
    for (int i = 0; i < inputArray.Length; i++)             // O(f(N))
    {
        for (int j = 0; j < inputArray.Length; j++)         // O(g(N))
        {
            for (int k = 0; k < inputArray.Length; k++)     // O(h(3N))
            {
                int y = 0;

                if (j != 0)
                {
                    y = k / j;
                }

                sum += inputArray[i] + i + k + j + y;
            }
        }
    }

    return sum;
}