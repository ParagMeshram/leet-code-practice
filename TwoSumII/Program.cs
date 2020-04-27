using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSumII
{
    internal class Program
    {
        private static void Main()
        {

        }
    }

    // f
    // 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11
    //                                 b

    public class Solution
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length <= 1) return Array.Empty<int>();

            var forward = 0;
            var backward = numbers.Length - 1;

            while (forward < backward)
            {
                var sum = numbers[forward] + numbers[backward];

                if (target > sum)
                {
                    forward++;
                }
                else if (target < sum)
                {
                    backward--;
                }
                else
                {
                    return new[] { forward + 1, backward + 1 };
                }
            }

            return Array.Empty<int>();
        }
    }
}
