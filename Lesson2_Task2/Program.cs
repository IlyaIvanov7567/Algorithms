using System;

// Асимптотическую сложность O(F(log inputArray.Length))

var arr = new int[] { 1, 2, 4, 6, 8, 10, 12, 14, 15 };

int searchValue = 4;
Console.WriteLine("Индекс искомого элемента массива со значением {1} = {0}", BinarySearch(arr, searchValue), searchValue);

int BinarySearch(int[] inputArray, int searchValue)
{
    int min = 0;
    int max = inputArray.Length - 1;
    while (min <= max)
    {
        int mid = (min + max) / 2;
        if (searchValue == inputArray[mid])
        {
            return mid;
        }
        else if (searchValue < inputArray[mid])
        {
            max = mid - 1;
        }
        else
        {
            min = mid + 1;
        }
    }
    return -1;
}

