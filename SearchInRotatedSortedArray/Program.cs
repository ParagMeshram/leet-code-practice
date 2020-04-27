using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInRotatedSortedArray
{
    using System.Runtime.InteropServices;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var s = new SolutionSubOptimal();
            Console.WriteLine(s.Search(new[] { 5, 1, 3 }, 3));
            Console.ReadKey();
        }
    }

    public class SolutionSubOptimal
    {
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return -1;
            if (nums.Length == 1 && nums[0] == target) return 0;

            var low = 0;
            var high = nums.Length - 1;

            for (var index = 0; index < nums.Length - 1; index++)
            {
                if (nums[index] == target)
                {
                    return index;
                }

                if (nums[index + 1] == target)
                {
                    return index + 1;
                }

                if (nums[index] > nums[index + 1])
                {
                    low = index + 1;
                    break;
                }
            }

            while (low <= high)
            {
                var mid = (low + high) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[mid] < target)
                {
                    low = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    high = mid - 1;
                }
            }

            return -1;
        }
    }

    public class SolutionOptimalTwoPass
    {
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return -1;
            if (nums.Length == 1 && nums[0] == target) return 0;

            var pivot = FindPivot(nums);

            if (nums[pivot] == target) return pivot;

            if (pivot == 0) return Search(nums, 0, nums.Length, target);

            if (target < nums[0])
                return Search(nums, pivot, nums.Length - 1, target);

            return Search(nums, 0, pivot, target);
        }
        // [7,9,0,1,2,3]
        //        ^  
        private int FindPivot(int[] nums) //^^^
        {
            var low = 0;
            var high = nums.Length - 1;

            while (low <= high)
            {
                var pivot = (low + high) / 2;

                if (nums[pivot] > nums[pivot + 1])
                    return pivot + 1;

                if (nums[pivot] < nums[low])
                    high = pivot - 1;
                else
                    low = pivot + 1;
            }

            return 0;
        }

        private int Search(int[] nums, int low, int high, int target)
        {
            while (low <= high)
            {
                var mid = (low + high) / 2;

                if (nums[mid] == target)
                    return mid;

                if (nums[mid] < target)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return -1;
        }
    }

    public class SolutionOptimalOnePass
    {
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return -1;
            if (nums.Length == 1 && nums[0] == target) return 0;

            var low = 0;
            var high = nums.Length - 1;

            while (low <= high)
            {
                var mid = (low + high) / 2;

                if (nums[mid] == target) return mid;

                if (target < nums[mid])
                    high = mid - 1;
                else
                    low = mid + 1;
            }

            return -1;
        }
    }
}
