using System;
using System.Collections.Generic;

namespace KthLargest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var s = new Solution();

            Console.WriteLine(s.FindKthLargest(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4));
        }
    }

    public enum QueueType
    {
        Min = 0,
        Max = 1
    }

    public class PriorityQueue<T>
    {
        private readonly QueueType type;

        private int index = 0;
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
        public int FindKthLargest(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0) throw new ArgumentException("nums cannot be null or empty");

            var queue = new PriorityQueue<int>(QueueType.Max);

            foreach (var num in nums)
            {
                queue.Enqueue(num);
            }

            for (var index = 0; index < k - 1; index++)
            {
                queue.Dequeue();
            }

            return queue.Dequeue();
        }
    }


    public class SolutionOptimal
    {
        public int FindKthLargest(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0) throw new ArgumentException("nums cannot be null or empty");

            var queue = new PriorityQueue<int>(QueueType.Min);

            foreach (var num in nums)
            {
                queue.Enqueue(num);

                if (queue.Count > k)
                {
                    queue.Dequeue();
                }
            }

            return queue.Dequeue();
        }
    }
}