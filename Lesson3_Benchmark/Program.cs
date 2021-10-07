using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

/*
 * Что я делаю:
 * 1. Объявляю класс Точка public class Point
 * 2. Объявляю класс Бенчмарк, в котором буду замерять производительность public class BechmarkClass
 * 3. В классе Бенчмарк объявляю метод для рассчета расстояния между точками, 
 * который на вход принимает две точки public void Distance
 * 4. В классе Бенчмарк объявляю метод, производительность которого хочу померить public void TestDistance.
 * Метод на вход должен принимать массив точек и в цикле вызывать метод Distance,
 * передавая в него две точки (с четным индексом и не четным)
 * 
 * Вопросы:
 * 1. Как в бенчмарк передать массив точек?
 * Инициализировать массив циклом в классе BechmarkClass не получается - ошибка.
 * Инициализировать массив в методе Main получается, но не получаетсяя передать его в бенчмарк.
 * Инициализировать массив внутри тестируемого метода нельзя по условиям задачи.
 * Инициализацию массива произвожу циклом с использованием класса Random.
 * 
 * 2. Ругается на неправильную сигнатуру тестового метода - метод TestDistance не должен иметь аргументов.
 * А как тогда передать массив?
 */

namespace Lesson3_test2
{
    class Program
    {
        static void Main(string[] args)
        {
            Point[] arrPoints = new Point[10];

            Random rnd = new();

            for (int i = 0; i < arrPoints.Length; i++)
            {
                arrPoints[i] = new Point();
                arrPoints[i].X = (float)(rnd.NextDouble() * 10);
                arrPoints[i].Y = (float)(rnd.NextDouble() * 10);
            }
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    public class BechmarkClass
    {
        public void Distance(Point pointOne, Point pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            var result = (float)Math.Sqrt((x * x) + (y * y));
        }

        [Benchmark]
        public void TestDistance(Point[] arrPoints)
        {
            for (int i = 0; i < arrPoints.Length / 2; i++)
            {
                Distance(arrPoints[i * 2], arrPoints[i * 2 + 1]);
            }
        }
    }

    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }
    }
}
