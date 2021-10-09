using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lesson3_test2
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    [RankColumn]
    [MemoryDiagnoser]
    public class BechmarkClass
    {
        //Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float)
        public static float DistanceClassFloat(PointClassFloat pointOne, PointClassFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y)); 
        }

        //Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа float)
        public static float DistanceStructFloat(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        //Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа double)
        public static double DistanceStructDouble(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        //Метод расчёта дистанции без квадратного корня со значимым типом(PointStruct — координаты типа float)
        public static float DistanceStructFloat2(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        [Benchmark]
        public void TestDistanceClassFloat()
        {
            PointClassFloat[] arrPoints = new PointClassFloat[100];

            Random rnd = new();

            for (int i = 0; i < arrPoints.Length; i++)
            {
                arrPoints[i] = new PointClassFloat();
                arrPoints[i].X = (float)(rnd.NextDouble() * 10);
                arrPoints[i].Y = (float)(rnd.NextDouble() * 10);
            }

            for (int i = 0; i < arrPoints.Length / 2; i++)
            {
                DistanceClassFloat(arrPoints[i * 2], arrPoints[i * 2 + 1]);
            }
        }
        [Benchmark]
        public void TestDistanceStructFloat()
        {
            PointStructFloat[] arrPoints = new PointStructFloat[100];

            Random rnd = new();

            for (int i = 0; i < arrPoints.Length; i++)
            {
                arrPoints[i].X = (float)(rnd.NextDouble() * 10);
                arrPoints[i].Y = (float)(rnd.NextDouble() * 10);
            }

            for (int i = 0; i < arrPoints.Length / 2; i++)
            {
                DistanceStructFloat(arrPoints[i * 2], arrPoints[i * 2 + 1]);
            }
        }
        [Benchmark]
        public void TestDistanceStructDouble()
        {
            PointStructDouble[] arrPoints = new PointStructDouble[100];

            Random rnd = new();

            for (int i = 0; i < arrPoints.Length; i++)
            {
                arrPoints[i].X = rnd.NextDouble() * 10;
                arrPoints[i].Y = rnd.NextDouble() * 10;
            }

            for (int i = 0; i < arrPoints.Length / 2; i++)
            {
                DistanceStructDouble(arrPoints[i * 2], arrPoints[i * 2 + 1]);
            }
        }
        [Benchmark]
        public void TestDistanceStructFloat2()
        {
            PointStructFloat[] arrPoints = new PointStructFloat[100];

            Random rnd = new();

            for (int i = 0; i < arrPoints.Length; i++)
            {
                arrPoints[i].X = (float)(rnd.NextDouble() * 10);
                arrPoints[i].Y = (float)(rnd.NextDouble() * 10);
            }

            for (int i = 0; i < arrPoints.Length / 2; i++)
            {
                DistanceStructFloat2(arrPoints[i * 2], arrPoints[i * 2 + 1]);
            }
        }
    }

    public class PointClassFloat
    {
        public float X { get; set; }
        public float Y { get; set; }
    }
    public struct PointStructFloat
    {
        public float X { get; set; }
        public float Y { get; set; }
    }
    public struct PointStructDouble
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
