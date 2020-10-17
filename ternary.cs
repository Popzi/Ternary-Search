using System;
using System.Linq;

namespace Uppgift4
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraysize = 100;
            int[] Arrayen = Enumerable.Range(0, arraysize)
                                .Select(x => Convert.ToInt32(x))
                                .ToArray();
            DateTime start = DateTime.Now;
            int Key = arraysize -1;
            int Test = Soek(0,Arrayen.Length - 1,Key,Arrayen);
            DateTime stop = DateTime.Now;
            TimeSpan tid = stop - start;
            if (Test != -1)
            {
                Console.WriteLine($"{Key} found in array on position {Test} in the array. \nTime taken: {tid.TotalMilliseconds} ms.");
                Console.ReadLine();
            } else
            {
                Console.WriteLine("Key not found in array!");
                Console.ReadLine();
            }

        }


        /// <summary>
        /// Split search into thirds instead of half
        /// Time complexity should be O(log3 n)  || SOURCE: https://www.techiedelight.com/ternary-search-vs-binary-search/
        /// </summary>
        /// <param name="index">0 <- starting from array index</param>
        /// <param name="range">Length of array. Counted from 0 to end of array. Array.length - 1</param>
        /// <param name="key">Key to search for</param>
        /// <param name="ar">The array to look in</param>
        /// <returns></returns>
        static int Soek(int index, int range, int key, int[] ar)
        {
            if (range >= index)
            {
                int m1 = index + (range - index) / 3; int m2 = range - (range - index) / 3;

                // m1 == key? m2 == key?  
                if (ar[m1] == key)
                {
                    return m1;
                }
                if (ar[m2] == key)
                {
                    return m2;
                }
                
                // key != m1 or m2
                if (key < ar[m1])
                {
                    // index | key | m1 
                    return Soek(index, m1 - 1, key, ar);
                }
                else if (key > ar[m2])
                {
                    // m2 | key | range   
                    return Soek(m2 + 1, range, key, ar);
                }
                else
                {
                    // m1 | key | m2  
                    return Soek(m1 + 1, m2 - 1, key, ar);
                }
            }
            // no such key exists
            return -1;
        }
    }
}
