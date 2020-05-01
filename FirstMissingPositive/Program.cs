using System;
using System.Collections.Generic;

namespace FirstMissingPositive
{
    internal class Program
    {
        private static void Main()
        {
            var array = new[] { 3, 4, -1, 1 };

            var solution = new Solution();

            Console.WriteLine(solution.FirstMissingPositive(array));
        }
    }

    public class Solution
    {
        public int FirstMissingPositive(int[] nums)
        {
            var min = 1;
            var hashSet = new HashSet<int>();

            foreach (var num in nums)
            {
                if (num > 0)
                {
                    min = Math.Min(num, min);

                    if (!hashSet.Contains(num))
                    {
                        hashSet.Add(num);
                    }
                }
            }

            while (true)
            {
                if (!hashSet.Contains(min))
                    break;
                min++;
            }

            return min;
        }
    }
}