using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler
{
    using System.Runtime.CompilerServices;

    internal class Program
    {
        private static void Main()
        {
            var s = new SolutionUsingSortingInComplete();

            s.LeastInterval(new[] { 'A', 'B', 'A', 'A', 'C', 'B' }, 2);
        }
    }

    public class SolutionUsingSortingInComplete
    {
        public int LeastInterval(char[] tasks, int n)
        {
            if (tasks == null || tasks.Length == 0) return 0;

            const int TOTAL_CHARS = 26;

            var map = new int[TOTAL_CHARS];

            foreach (var ch in tasks)
            {
                map[ch - 'A']++;
            }

            Array.Sort(map);

            var time = 0;

            while (map[TOTAL_CHARS - 1] > 0)
            {
                var index = 0;

                while (index <= n)
                {
                    if (map[TOTAL_CHARS - 1] == 0)
                        break;

                    if (index < TOTAL_CHARS && map[TOTAL_CHARS - index - 1] > 0)
                    {
                        Console.WriteLine((char)(TOTAL_CHARS - index - 1 + 'A'));
                        map[TOTAL_CHARS - index - 1]--;
                    }


                    time++;
                    index++;
                }

                Array.Sort(map);
            }


            return time;
        }
    }

    public class PriorityQueue<T>
    {
        private int index;
        private readonly SortedSet<PQItem> items;
        private class PQItem
        {
            public T Value { get; set; }
            public int Index { get; set; }
        }

        public PriorityQueue(Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;

            this.items = new SortedSet<PQItem>(Comparer<PQItem>.Create((x, y) => comparer.Compare(x.Value, y.Value) == 0 ? x.Index - y.Index : comparer.Compare(x.Value, y.Value)));
        }

        public void Enqueue(T value)
        {
            this.items.Add(new PQItem() { Value = value, Index = this.index++ });
        }

        public T Dequeue()
        {
            var max = this.items.Max;
            this.items.Remove(max);
            return max.Value;
        }

        public T Peek()
        {
            var max = this.items.Max;
            return max.Value;
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }


    }

    public class SolutionUsingPriorityQueue
    {
        public int LeastInterval(char[] tasks, int n)
        {
            if (tasks == null || tasks.Length == 0) return 0;

            var map = new int[26];
            var queue = new PriorityQueue<int>();

            foreach (var task in tasks)
            {
                map[task - 'A']++;
            }

            foreach (var item in map)
            {
                if (item > 0) queue.Enqueue(item);
            }

            var time = 0;

            while (queue.Count > 0)
            {
                var i = 0;
                var temp = new List<int>();

                while (i <= n)
                {
                    if (queue.Count > 0)
                    {
                        if (queue.Peek() > 1)
                            temp.Add(queue.Dequeue() - 1);
                        else
                            queue.Dequeue();
                    }
                    time++;
                    if (queue.Count > 0 && temp.Count == 0)
                        break;
                    i++;
                }

                foreach (var l in temp)
                    queue.Enqueue(l);
            }

            return time;
        }
    }
}
