using System;

namespace MoveZeroes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var solution = new Solution();

            var input = new[] { 0, 1, 5, 8, 0 };

            solution.MoveZeroes2(input);


            for (var index = 0; index < input.Length; index++)
            {
                Console.WriteLine(input[index]);
            }

            Console.ReadKey();
        }
    }

    public class Solution
    {
        public void MoveZeroes(int[] nums)
        {
            if (nums == null || nums.Length == 0) return;

            var slow = 0;
            var fast = 0;

            while (fast < nums.Length)
            {
                if (nums[fast] != 0)
                {
                    nums[slow++] = nums[fast];
                }

                fast++;
            }

            while (slow < nums.Length) nums[slow++] = 0;
        }


        public void MoveZeroes2(int[] nums)
        {
            if (nums == null || nums.Length == 0) return;

            var slow = 0;
            var fast = 0;

            while (fast < nums.Length)
            {
                if (nums[fast] == 0)
                {
                    fast++;
                    continue;
                }

                nums[slow++] = nums[fast++];
            }

            while (slow < nums.Length) nums[slow++] = 0;
        }
    }
}