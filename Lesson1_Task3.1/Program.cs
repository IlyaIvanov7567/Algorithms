using System;

// Вычисление числа Фибоначчи с использованием рекурсии

int n;
Console.Write("Введите число: ");
n = int.Parse(Console.ReadLine());

Console.WriteLine("{0} член последовательности Фибоначчи равен {1}", n, Fibonacci(n));
Console.ReadKey();

static int Fibonacci(int n)
{
    if (n == 0)
        return 0;
    else if (n == 1)
        return 1;
    else
        return Fibonacci(n - 1) + Fibonacci(n - 2);
}