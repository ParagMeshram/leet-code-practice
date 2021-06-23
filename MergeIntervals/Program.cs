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

    /*
        s           e
        |-----------|
               |----------|
               s          e


        s                           e
        |---------------------------|
               |----------|
               s          e

        s           e
        |-----------|
                        |----------|
                        s          e

     */

    public class Solution2
    {
        public int[][] Merge(int[][] intervals)
        {
            const int start = 0;
            const int end = 1;

            var merged = new List<int[]>();

            var sorted = intervals.OrderBy(i => i[0]).ToArray(); //^^^

            // Array.Sort(intervals, (a, b) => a[0] - b[0]);  //^^^


            merged.Add(sorted[start]);

            for (var index = 1; index < sorted.Length; index++)
            {
                var curr = sorted[index];
                var prev = merged.Last();

                if (curr[start] < prev[end]) // overlapping
                {
                    prev[end] = Math.Max(prev[end], curr[end]);
                }
                else // non-overlapping
                {
                    merged.Add(curr);
                }
            }
            

            return merged.ToArray();
        }
    }
}