using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lesson4_Task1
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] myArr = new string[10000];
            for (int i = 0; i < myArr.Length; i++)
            {
                myArr[i] = Guid.NewGuid().ToString();
            }
            myArr[500] = "СТРОКА";

            HashSet<string> myHash = new HashSet<string>();
            for (int i = 0; i < 10000; i++)
            {
                myHash.Add(Guid.NewGuid().ToString());
            }
            myHash.Add("СТРОКА");

            int index = -1;
            string searchString = "СТРОКА";

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < myArr.Length; i++)
            {
                if (!string.IsNullOrEmpty(myArr[i]) && myArr[i] == searchString)
                {
                    break;
                }
            }
            stopWatch.Stop();
            Console.WriteLine($"Array search time: {stopWatch.Elapsed}");

            stopWatch.Restart();
            bool isFound = myHash.Contains(searchString);
            stopWatch.Stop();
            Console.WriteLine($"Hashset search time: {stopWatch.Elapsed}");
            Console.ReadKey();
        }
    }
}
