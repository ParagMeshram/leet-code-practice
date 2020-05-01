using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingRooms
{
    internal class Program
    {
        private static void Main()
        {
        }
    }

    /*

s1       e1 s2         e2
|---------| |----------|




s1        e1
|---------|
      |--------|
     s2        e2
     


      |--------|
     s1       e1
s2        e2
|---------|


s1                   e1
|---------------------|

    |----------|
    s2         e2


s2                   e2
|---------------------|

     |----------|
     s1        e1


*/

    public class SolutionBruteForce
    {
        public bool CanAttendMeetings(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0) return true;

            var intervalCount = intervals.Length;

            for (var i = 0; i < intervalCount - 1; i++)
            {
                for (var j = i + 1; j < intervalCount; j++)
                {
                    if (IsOverlap(intervals[i], intervals[j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool IsOverlap(int[] a, int[] b)
        {
            return Math.Min(a[1], b[1]) > Math.Max(a[0], b[0]);
        }
    }

    public class SolutionOptimal
    {
        public bool CanAttendMeetings(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0) return true;

            var intervalCount = intervals.Length;

            Array.Sort(intervals, Comparer<int[]>.Create((x, y) => x[0] - y[0])); //^^^

            for (var i = 1; i < intervalCount; i++)
            {
                if (IsOverlap(intervals[i - 1], intervals[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsOverlap(int[] a, int[] b)
        {
            return Math.Min(a[1], b[1]) > Math.Max(a[0], b[0]); //^^^
        }
    }
}
