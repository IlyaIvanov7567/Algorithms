using System;
using System.Diagnostics;

namespace Lesson3_StopWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new();

            PointClassFloat[] pointsClassFloat = new PointClassFloat[100];
            PointStructFloat[] pointsStructFloat = new PointStructFloat[100];
            PointStructDouble[] pointsStructDouble = new PointStructDouble[100];

            for (int i = 0; i < pointsClassFloat.Length; i++)
            {
                pointsClassFloat[i] = new PointClassFloat();
                pointsClassFloat[i].X = (float)(rnd.NextDouble() * 10);
                pointsClassFloat[i].Y = (float)(rnd.NextDouble() * 10);
            }

            for (int i = 0; i < pointsStructFloat.Length; i++)
            {
                pointsStructFloat[i].X = (float)(rnd.NextDouble() * 10);
                pointsStructFloat[i].Y = (float)(rnd.NextDouble() * 10);
            }

            for (int i = 0; i < pointsStructDouble.Length; i++)
            {
                pointsStructDouble[i].X = rnd.NextDouble() * 10;
                pointsStructDouble[i].Y = rnd.NextDouble() * 10;
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < pointsClassFloat.Length / 2; i++)
            {
                DistanceClassFloat(pointsClassFloat[i * 2], pointsClassFloat[i * 2 + 1]);
            }
            stopWatch.Stop();
            Console.WriteLine("Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float). Затраченное время: {0}", stopWatch.Elapsed);

            stopWatch.Restart();
            for (int i = 0; i < pointsStructFloat.Length / 2; i++)
            {
                DistanceStructFloat(pointsStructFloat[i * 2], pointsStructFloat[i * 2 + 1]);
            }
            stopWatch.Stop();
            Console.WriteLine("Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа float). Затраченное время: {0}", stopWatch.Elapsed);

            stopWatch.Restart();
            for (int i = 0; i < pointsStructDouble.Length / 2; i++)
            {
                DistanceStructDouble(pointsStructDouble[i * 2], pointsStructDouble[i * 2 + 1]);
            }
            stopWatch.Stop();
            Console.WriteLine("Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа double). Затраченное время: {0}", stopWatch.Elapsed);

            stopWatch.Restart();
            for (int i = 0; i < pointsStructFloat.Length / 2; i++)
            {
                DistanceStructFloat2(pointsStructFloat[i * 2], pointsStructFloat[i * 2 + 1]);
            }
            stopWatch.Stop();
            Console.WriteLine("Метод расчёта дистанции без квадратного корня со значимым типом (PointStruct — координаты типа float). Затраченное время: {0}", stopWatch.Elapsed);

            Console.ReadKey();
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
            return MathF.Sqrt((float)((x * x) + (y * y)));
        }

        //Метод расчёта дистанции без квадратного корня со значимым типом(PointStruct — координаты типа float)
        public static float DistanceStructFloat2(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
    }
}