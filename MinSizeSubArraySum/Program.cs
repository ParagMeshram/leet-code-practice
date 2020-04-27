using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinSizeSubArraySum
{
    internal class Program
    {
        private static void Main()
        {
        }
    }

    /*
    
        Input: s = 7, nums = [2,3,1,2, 4, 3]
                             [0,2,5,6,8,12, 15]

                             [2,5,6,8,12, 15]

                             [2,3]
                             [2,3,1]
                             [2,3,1,2]
                             [2,3,1,2,4]
                             [2,3,1,2,4,3]

    */


    public class Solution
    {
        public int MinSubArrayLenBruteForce(int s, int[] nums)
        {
            //var prefixSum = new int[nums.Length];

            //prefixSum[0] = nums[0];

            //for (var index = 1; index < nums.Length; index++)
            //{
            //    prefixSum[index] = prefixSum[index - 1] + nums[index];
            //}

            var minLength = int.MaxValue;

            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    var sum = 0;

                    for (var k = i; k <= j; k++)
                    {
                        sum += nums[k];
                    }

                    if (sum >= s)
                    {
                        minLength = Math.Min(minLength, j - i + 1);
                        break;
                    }
                }
            }

            return minLength == int.MaxValue ? 0 : minLength;
        }


        public int MinSubArrayLenPrefixSum(int s, int[] nums)
        {
            var prefix = new int[nums.Length];

            prefix[0] = nums[0];

            for (var index = 1; index < prefix.Length; index++)
            {
                prefix[index] = prefix[index - 1] + nums[index];
            }

            var minLength = int.MaxValue;

            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = i; j < nums.Length; j++)
                {
                    var sum = prefix[j] - prefix[i] + nums[i];

                    if (sum >= s)
                    {
                        minLength = Math.Min(minLength, j - i + 1);
                        break;
                    }
                }
            }

            return minLength == int.MaxValue ? 0 : minLength;
        }


        public int MinSubArrayLen(int target, int[] numbers)
        {
            var slow = 0;
            var fast = 0;
            var sum = 0;
            var min = int.MaxValue;

            while (fast < numbers.Length)
            {
                sum += numbers[fast];

                if (sum >= target)
                {
                    min = Math.Min(min, fast + 1 - slow);
                    sum -= numbers[slow++];
                }

                fast++;
            }

            return min;
        }

    }
}
