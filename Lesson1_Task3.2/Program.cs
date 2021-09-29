using System;

// Вычисление числа Фибоначчи с использованием цикла

int n;
int prev = 0;
int current = 1;
int temp;
int result = 0;

Console.Write("Введите число: ");
n = int.Parse(Console.ReadLine());


for (int i = 2; i <= n; i++)
{
    result = prev + current;
    temp = current;
    current = current + prev;
    prev = temp;
}

Console.WriteLine("{0} член последовательности Фибоначчи равен {1}", n, result);
Console.ReadKey();
