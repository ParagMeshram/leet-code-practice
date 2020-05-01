using System;

namespace MaxConsecutiveOnesIII
{
    internal class Program
    {
        private static void Main()
        {
        }
    }

    public class SolutionLeetCode
    {
        public int LongestOnes(int[] A, int K)
        {
            int zeroCount = 0;
            int maxLen = 0;

            for (int l = 0, r = 0; r < A.Length; r++)
            {
                if (A[r] == 0) zeroCount++;

                while (zeroCount > K)
                {
                    if (A[l] == 0) zeroCount--;
                    ++l;
                }

                maxLen = Math.Max(maxLen, r - l + 1);
            }

            return maxLen;
        }
    }

    /*

    Input => [1,1,1,0,0,1,1,1,1,0]
                                 s
                                 f
    */

    public class Solution
    {
        public int LongestOnes(int[] array, int k)
        {
            var slow = 0;
            var fast = 0;
            var zeroCount = 0;
            var longest = k;

            while (fast < array.Length)
            {
                if (array[fast] == 0)
                {
                    zeroCount++;
                }

                while (zeroCount > k)
                {
                    if (array[slow] == 0) zeroCount--;
                    slow++;
                }

                longest = Math.Max(longest, fast - slow + 1);

                fast++;
            }

            return longest;
        }
    }
}