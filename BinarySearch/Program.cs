using System;

namespace BinarySearch
{
    internal class Program
    {
        private static void Main()
        {
            var array = new int[] { 5, 1, 3 };

            //Console.WriteLine(BinarySearch(array, 3));


            array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(BinarySearchUsingRecursion(array, 9));

            Console.ReadKey();
        }

        public static int BinarySearch(int[] input, int target)
        {
            if (input == null || input.Length == 0) return -1;
            if (input.Length == 1 && input[0] == target) return 0;

            var low = 0;
            var high = input.Length - 1;

            for (var index = 0; index < input.Length - 1; index++)
            {
                if (input[index] == target)
                {
                    return index;
                }

                if (input[index + 1] == target)
                {
                    return index + 1;
                }

                if (input[index] > input[index + 1])
                {
                    low = index + 1;
                    break;
                }
            }

            while (low <= high)
            {
                var mid = (low + high) / 2;

                if (input[mid] == target) return mid;

                if (input[mid] < target)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return -1;
        }


        public static int BinarySearchUsingRecursion(int[] input, int target)
        {
            if (input == null || input.Length == 0) return -1;
            if (input.Length == 1 && input[0] == target) return 0;

            return BinarySearchInternal(input, 0, input.Length - 1, target);
        }

        // [1,2,3,4,5,6,7,8,9]
        //          ^
        private static int BinarySearchInternal(int[] input, int low, int high, int target)
        {
            if (low > high) return -1;

            var mid = (low + high) / 2;

            if (input[mid] == target) return mid;

            if (input[mid] < target)
                return BinarySearchInternal(input, mid + 1, high, target);
            else
                return BinarySearchInternal(input, low, mid - 1, target);
        }
    }
}