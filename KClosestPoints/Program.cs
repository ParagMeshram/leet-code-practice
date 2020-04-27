using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClosestPoints
{
    using System.Data;
    using System.Runtime.Remoting.Messaging;
    using System.Security.Cryptography.X509Certificates;

    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Point : IComparable<Point>
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        protected double Distance { get; private set; }


        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Distance = GetDistance();
        }

        protected double GetDistance()
        {
            return Math.Sqrt((this.X * this.X) + (this.Y + this.Y));
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
            var heap = new SortedSet<Point>();

            foreach (var point in points)
            {
                heap.Add(new Point(point[0], point[1]));
            }

            var answer = new int[K][];

            for (var index = 0; index < K; index++)
            {
                answer[index] = heap.Min.ToArray();
                heap.Remove(heap.Min);
            }

            return answer.ToArray();
        }
    }
}
