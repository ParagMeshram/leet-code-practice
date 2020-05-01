using System;

namespace MaximumSubarray
{
    internal class Program
    {
        private static void Main()
        {
            var solution = new Solution();

            var output = solution.MaxSubArray(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });

            Console.WriteLine(output);

            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            return 0;
        }
    }
}