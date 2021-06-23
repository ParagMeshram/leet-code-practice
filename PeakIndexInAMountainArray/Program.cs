using System;

namespace PeakIndexInAMountainArray
{
    internal class Program
    {
        private static void Main()
        {
            var o = new Solution();

            o.PeakIndexInMountainArray(new[] { 1, 2, 3 });

            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int PeakIndexInMountainArray(int[] A)
        {
            var i = 0;

            while (A[i] < A[i + 1]) i++;

            return i;
        }
    }
}
