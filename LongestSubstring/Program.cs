using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubstring
{
    internal class Program
    {
        private static void Main()
        {

            int[][] jagged_arr = new int[4][];

            // Initialize the elements 
            jagged_arr[0] = new int[] { 1, 2, 3, 4 };
            jagged_arr[1] = new int[] { 11, 34, 67 };
            jagged_arr[2] = new int[] { 89, 23 };
            jagged_arr[3] = new int[] { 0, 45, 78, 53, 99 };

            //Console.WriteLine(jagged_arr.GetLowerBound(0));
            //Console.WriteLine(jagged_arr.GetUpperBound(0));
            //Console.WriteLine(jagged_arr.GetLowerBound(1));
            //Console.WriteLine(jagged_arr.GetUpperBound(1));

            for (int i = 0; i < jagged_arr.Length; i++)
            {
                for (int j = 0; j < jagged_arr[i].Length; j++)
                {
                    Console.Write(jagged_arr[i][j] + ",");
                }

                Console.WriteLine();
            }

            // Console.ReadKey();


            int[,] array = new int[4, 6];

            // Initialize the elements 
            array = new int[,]
            {
                { 1, 2, 3, 4, 9, 7 },
                { 6, 9, 3, 10, 4, 2 },
                { 56, 1, 45, 4, 1, 0 },
                { 1, 99, 3, 4, 4, 8 },
            };

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + ",");
                }

                Console.WriteLine();
            }

            Console.WriteLine(array.GetLowerBound(0));
            Console.WriteLine(array.GetUpperBound(0));
            Console.WriteLine(array.GetLowerBound(1));
            Console.WriteLine(array.GetUpperBound(1));


            Console.ReadKey();

            const string input = "ﯔﯔﯔﯔﯔ";
            var output = new Solution().LengthOfLongestSubstring(input);
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
    
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            var hashSet = s.GroupBy(c => c)
                           .Select(c => new { Char = c.Key, Count = c.Count() })
                           .Where(c => c.Count > 1)
                           .Select(c=> c.Char)
                           .ToHashSet();
            var max = 0;
            var distinct = 0;

            for (int index = 0; index < s.Length; index++)
            {
                var ch = s[index];

                if (hashSet.Contains(ch)) // Duplicate
                {
                    max = Math.Max(max, distinct);
                    distinct = 0;
                }
                else
                {
                    distinct++;
                }
            }

            return max;
        }
    }

    //public static class Extensions
    //{
    //    public static IEnumerable<char> ToEnumerable(this string s)
    //    {
    //        foreach (var ch in s)
    //        {
    //            yield return ch;
    //        }
    //    }
    //}
}
