using System;
using System.Collections.Generic;

namespace Lesson8
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = new int[15];
            
            Random rnd = new Random();

            for (int i = 0; i < arr.Length; ++i)
                arr[i] = rnd.Next(1, 100);

            Console.WriteLine(String.Join(" ", arr));
            
            Sort s = new Sort();
            
            s.BucketSort(arr);

            Console.WriteLine(String.Join(" ", arr));


        }
    }
}