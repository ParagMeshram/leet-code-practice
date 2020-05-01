using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingRoomsII
{
    internal class Program
    {
        private static void Main()
        {
        }
    }


    /*
    [
     [0, 30],
     [5, 10],
     [15,20]
    ]

    */

    public enum QueueType
    {
        Min = 0,
        Max = 1
    }

    public class PriorityQueue<T>
    {
        private readonly QueueType type;

        private int index;
        private readonly SortedSet<PQItem> set;

        private class PQItem
        {
            public T Value;
            public int Index;
        }

        public PriorityQueue(QueueType type = QueueType.Min, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            set = new SortedSet<PQItem>(Comparer<PQItem>.Create((x, y) =>
                comparer.Compare(x.Value, y.Value) == 0 ? x.Index - y.Index : comparer.Compare(x.Value, y.Value)));
            this.type = type;
        }

        public int Count => set.Count;

        public void Enqueue(T value)
        {
            set.Add(new PQItem { Value = value, Index = index++ });
        }

        public T Peek()
        {
            return PeekInternal().Value;
        }

        private PQItem PeekInternal()
        {
            if (Count == 0) throw new InvalidOperationException();

            var item = type == QueueType.Min ? set.Min : this.set.Max;
            return item;
        }

        public T Dequeue()
        {
            if (Count == 0) throw new InvalidOperationException();

            var item = PeekInternal();
            set.Remove(item);
            return item.Value;
        }
    }

    public class Solution
    {
        public int MinMeetingRooms(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0) return 0;

            var intervalCount = intervals.Length;

            // Sort meetings by start time

            Array.Sort(intervals, Comparer<int[]>.Create((x, y) => x[0] - y[0]));

            var queue = new PriorityQueue<int>();

            queue.Enqueue(intervals[0][1]);

            for (var i = 1; i < intervalCount; i++)
            {
                var start = intervals[i][0];
                var end = queue.Peek();

                /*
                      s1                  e1
                      |-------------------|
                s2            e2s3             e3
                |--------------||---------------|

                */

                if (start >= end) //^^^
                {
                    queue.Dequeue();
                }

                queue.Enqueue(intervals[i][1]);
            }

            return queue.Count;
        }
    }
}
