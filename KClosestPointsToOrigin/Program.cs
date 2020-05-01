using System;
using System.Collections.Generic;
using System.Linq;

namespace KClosestPointsToOrigin
{
    internal class Program
    {
        private static void Main()
        {
            // [[3,3],[5,-1],[-2,4]], 2
            var solution = new Solution();

            //var output = solution.KClosest(new[]
            //{
            //    new[] {3, 3},
            //    new[] {5, -1},
            //    new[] {-2, 4}
            //}, 2);


            // [[1,3],[-2,2]], 1

            var output = solution.KClosest(new[]
            {
                new[] {1, 3},
                new[] {-2, 2}
            }, 1);

            Console.ReadKey();
        }
    }

    public class PriorityQueue<T>
    {
        private class PQItem
        {
            public T Item { get; set; }
            public int Index { get; set; }
        }

        private int index = 0;
        private readonly SortedSet<PQItem> set;

        public int Count => set.Count;

        public PriorityQueue(IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            set = new SortedSet<PQItem>(Comparer<PQItem>.Create((x, y) =>
                comparer.Compare(x.Item, y.Item) == 0 ? x.Index - y.Index : comparer.Compare(x.Item, y.Item)));
        }

        public void Enqueue(T item)
        {
            set.Add(new PQItem { Item = item, Index = index++ });
        }

        public T Dequeue()
        {
            var min = set.Min;
            this.set.Remove(min);
            return min.Item;
        }
    }

    public class Point : IComparable<Point>
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public double Distance { get; private set; }


        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Distance = GetDistance();
        }

        protected double GetDistance()
        {
            return Math.Sqrt((this.X * this.X) + (this.Y * this.Y));
        }

        public int CompareTo(Point other)
        {
            return this.Distance.CompareTo(other.Distance);
        }

        public int[] ToArray()
        {
            return new[] { this.X, this.Y };
        }
    }

    public class Solution
    {
        public int[][] KClosest(int[][] points, int K)
        {
            var queue = new PriorityQueue<Point>(Comparer<Point>.Create((x, y) => x.Distance.CompareTo(y.Distance)));

            foreach (var point in points)
            {
                queue.Enqueue(new Point(point[0], point[1]));
            }

            var answer = new int[K][];

            for (var index = 0; index < K; index++)
            {
                answer[index] = queue.Dequeue().ToArray();
            }

            return answer.ToArray();
        }
    }
}