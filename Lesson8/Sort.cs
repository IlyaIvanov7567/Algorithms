using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    internal class Sort
    {
        public void BucketSort(int[] arr)
        {

            List<int>[] buckets = new List<int>[arr.Length];

            for (int i = 0; i < buckets.Length; ++i)
                buckets[i] = new List<int>();

            int minValue = arr[0];
            int maxValue = arr[0];

            for (int i = 1; i < arr.Length; ++i)
            {
                if (arr[i] < minValue)
                    minValue = arr[i];
                else if (arr[i] > maxValue)
                    maxValue = arr[i];
            }

            double numRange = maxValue - minValue;

            for (int i = 0; i < arr.Length; ++i)
            {

                int bcktIdx = (int)Math.Floor((arr[i] - minValue) / numRange * (buckets.Length - 1));

                buckets[bcktIdx].Add(arr[i]);
            }

            for (int i = 0; i < buckets.Length; ++i)
            {
                ShellSort(buckets[i].ToArray());
            }

            int idx = 0;

            for (int i = 0; i < buckets.Length; ++i)
            {
                for (int j = 0; j < buckets[i].Count; ++j)
                    arr[idx++] = buckets[i][j];
            }
        }
        static void Swap(ref int a, ref int b)
        {
            var t = a;
            a = b;
            b = t;
        }
        int[] ShellSort(int[] arr)
        {
            var d = arr.Length / 2;
            
            while (d >= 1)
            {
                for (var i = d; i < arr.Length; i++)
                {
                    var j = i;
                    
                    while ((j >= d) && (arr[j - d] > arr[j]))
                    {
                        Swap(ref arr[j], ref arr[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
            }

            return arr;
        }
    }
}
