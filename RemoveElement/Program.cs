using System;

namespace RemoveElement
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var solution = new Solution();

            var input = new[] { 11, 29, 23, 4, 51, 6, 14, 6, 90, 18 };

            var output = solution.RemoveElement(input, 6);


            for (var index = 0; index < output; index++)
            {
                Console.WriteLine(input[index]);
            }

            Console.ReadKey();
        }
    }


    public class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {
            if (nums == null || nums.Length == 0) return 0;

            var slow = 0;
            var fast = 0;

            while (fast < nums.Length)
            {
                if (nums[fast] != val)
                {
                    nums[slow] = nums[fast];
                    slow++;
                }

                fast++;
            }

            return slow;
        }

        public int RemoveElement2(int[] numbers, int value)
        {
            if (numbers == null || numbers.Length == 0) return 0;

            var slow = 0;
            var fast = 0;

            while (fast < numbers.Length)
            {
                if (numbers[fast] == value)
                {
                    fast++;
                    continue;
                }

                numbers[slow++] = numbers[fast++];
            }

            return slow;
        }
    }
}


// Index => 00, 01, 02, 03, 04, 05, 06, 07, 08, 09
// Ptrs  =>                          s                    
// Nums  => 11, 29, 23,  4, 51,  14, 14,  6, 90, 18
// Ptrs  =>                               f

// Index => 00, 01, 02, 03, 04, 05, 06, 07, 08, 09
// Nums  => 11, 29, 23,  4, 51,  6, 14,  6, 90, 18
// Ptrs  =>                      f<-s


// Index => 00, 01, 02, 03, 04, 05, 06, 07, 08, 09
// Nums  => 11, 29, 23,  4, 51,  14, 14,  6, 90, 18
// Ptrs  =>                           f   s