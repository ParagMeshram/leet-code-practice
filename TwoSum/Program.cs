using System;
using System.Collections.Generic;

namespace TwoSum
{
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var output = solution.TwoSum(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 9);

            Console.WriteLine(string.Join(", ", output));

            Console.ReadKey();
        }
    }

    // a + b = c
    // a = c - b;

    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var lookup = new Dictionary<int, int>();

            for (var index = 0; index < nums.Length; index++)
            {
                var complement = target - nums[index];
                
                if (lookup.ContainsKey(complement))
                    return new [] { lookup[complement], index };

                lookup.Add(nums[index], index);
            }

            return Array.Empty<int>();
        }

        public int[] TwoSum2(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return Array.Empty<int>();

            var lookup = new Dictionary<int, int>();

            for (var index = 0; index < nums.Length; index++)
            {
                var expected = target - nums[index];

                if (lookup.ContainsKey(expected))
                {
                    return new[] { lookup[expected], index };
                }

                lookup[nums[index]] = index;
            }

            return Array.Empty<int>();
        }
    }
}
