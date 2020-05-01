using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeIntervals.BySortingTwice
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int[][] Merge(int[][] intervals)
        {
            var output = new List<int[]>();

            var sorted = intervals.OrderBy(i => i[0]).ThenBy(i => i[1]).ToArray(); //^^^

            var start = 0;
            var end = 0;
            var index = 0;

            while (index < sorted.Length)
            {
                var current = sorted[index];

                start = current[0];
                end = current[1];

                index++;

                while (index < sorted.Length && sorted[index][0] <= end)
                {
                    end = Math.Max(end, sorted[index][1]);
                    index++;
                }

                output.Add(new[] { start, end });
            }

            return output.ToArray();
        }
    }
}