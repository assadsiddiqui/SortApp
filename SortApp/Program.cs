using System;
using System.Collections.Generic;
using System.Linq;

namespace SortApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 9, 3, 2, 7, 5, 12, 12, 6, 4, 1, 17, 17, 31 };
            Console.WriteLine("Starting Array:");

            array.ToList().ForEach(x =>
            {
                Console.Write(x + ",");
            });

            var sortedArray = SortArrayWithSmallestInMiddle(array);

            Console.Write("\r\n\r\n");
            Console.WriteLine("Sorted Array:");
            sortedArray.ToList().ForEach(x =>
            {
                Console.Write(x + ",");
            });

            Console.Write("\r\n\r\n");
            FindDuplicate(array);
            Console.Write("\r\n\r\n");
            Console.Write("Press Enter Key to exit.");

            Console.ReadLine();
        }

        public static int[] SortArrayWithSmallestInMiddle(int[] inputArray)
        {
            // Sort array in a descending form
            Array.Sort(inputArray, new Comparison<int>(
                  (i1, i2) => i2.CompareTo(i1)));
            
            // Loop through each cell the odd number position will be at the top
            // and even number at bottom. Performance will be O(n)
            var properlySortedArray = new int[inputArray.Length];
            int max = inputArray.Length - 1;
            int min = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (i % 2 == 0)
                {
                    properlySortedArray[min] = inputArray[i];
                    min++;
                }
                else
                {
                    properlySortedArray[max] = inputArray[i];
                    max--;
                }
            }

            return properlySortedArray;
        }

        public static void FindDuplicate(int[] inputArray)
        {
            var dictionary = new Dictionary<int, int>();

            foreach(var input in inputArray)
            {
                if (dictionary.ContainsKey(input))
                {
                    dictionary[input]++;
                }
                else
                {
                    dictionary.Add(input, 1);
                }
            }

            Console.WriteLine($"The number of duplicates are {dictionary.Count(x=>x.Value>1)}");
            Console.WriteLine($"The duplicate numbers are:");
            Console.WriteLine(string.Join(", ", dictionary.Where(x => x.Value > 1).Select(x=>x.Key)));
        }

        public static void something()
        {
            Console.WriteLine("Something");
        }
    }
}
