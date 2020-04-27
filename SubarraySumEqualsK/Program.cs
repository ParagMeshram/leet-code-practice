using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubarraySumEqualsK
{
    internal class Program
    {
        private static void Main()
        {
            Array.Copy();
            var array = new[]
            {
                1, 2, 1, 2, 1
            };

            var bf = new SolutionBruteForce();
            Console.WriteLine(bf.SubarraySum(array, 3));

            Console.ReadKey();
        }
    }

    // [1,2,3,4], k = 3
    public class SolutionBruteForce
    {
        public int SubarraySum(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0) return 0;

            var count = 0;

            for (var start = 0; start < nums.Length; start++)
            {
                for (var end = start; end < nums.Length; end++) 
                {
                    var sum = 0;

                    for (var i = start; i <= end; i++)
                    {
                        sum += nums[i];
                    }

                    if (sum == k) count++;
                }
            }

            return count;
        }
    }

    // [1,2,3, 4], k = 3
    // [1,3,6,10] => PREFIX
    // SUM[1..3] => PREFIX[3 + 1] - PREFIX[1] => 10 -  1 => 9

    public class SolutionPrefixSum
    {
        public int SubarraySum(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0) return 0;

            var prefix = new int [nums.Length + 1];

            prefix[0] = 0;

            for (var index = 1; index < prefix.Length; index++)
            {
                prefix[index] = prefix[index - 1] + nums[index - 1];
            }

            var count = 0;

            for (var start = 0; start < nums.Length; start++)
            {
                for (var end = start; end < nums.Length; end++)
                {
                    var sum = prefix[end] - prefix[start];

                    if (sum == k) count++;
                }
            }

            return count;
        }
    }
}
