using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPermutation
{
    internal class Program
    {
        private static void Main()
        {
            var array = new[] { 5, 4, 3, 2, 1 };
            var s = new Solution();
            s.NextPermutation(array);
            Console.ReadKey();
        }
    }

    public class NotASolutionJustTryingToPrintAllPermutations
    {
        public void NextPermutation(int[] nums)
        {
            var permCount = Factorial(nums.Length);
            Permute(nums, 0, nums.Length - 1);
        }

        public double Factorial(int number)
        {
            double result = 1;

            while (number != 1)
            {
                result *= number;
                number -= 1;
            }

            return result;
        }

        private void Permute(int[] nums, int l, int r) //^^^
        {
            if (l == r)
            {
                Console.WriteLine(string.Join(",", nums));
            }
            else
            {
                for (int i = l; i <= r; i++)
                {
                    Swap(nums, l, i);
                    Permute(nums, l + 1, r);
                    Swap(nums, l, i);
                }
            }
        }

        private void Swap(int[] nums, int from, int to)
        {
            var temp = nums[from];
            nums[from] = nums[to];
            nums[to] = temp;
        }
    }


    public class Solution
    {
        public void NextPermutation(int[] nums)
        {
            if (nums == null || nums.Length <= 1) return;

            var index = nums.Length - 2;

            while (index >= 0)
            {
                if (nums[index] < nums[index + 1])
                    break;

                index--;
            }

            if (index >= 0)
            {
                var j = nums.Length - 1;

                while (j >= 0 && nums[j] <= nums[index]) j--;

                Swap(nums, index, j);
            }

            Reverse(nums, index + 1, nums.Length - 1);
        }

        private static void Reverse(int[] nums, int from, int to)
        {
            while (from < to)
            {
                Swap(nums, from++, to--);
            }
        }

        private static void Swap(int[] nums, int from, int to)
        {
            var temp = nums[from];
            nums[from] = nums[to];
            nums[to] = temp;
        }
    }
}
