using System;

// Функция согласно блок-схеме

int num;
Console.Write("Введите число: ");
num = int.Parse(Console.ReadLine());

int d = 0;
int i = 2;

while (i < num)
{
    if (num % i == 0)
    {
        d++;
        i++;
    }
    else
    {
        i++;
    }
}
if (d == 0)
{
    Console.WriteLine($"Число {num} простое");
}
else
{
    Console.WriteLine($"Число {num} не простое");
}