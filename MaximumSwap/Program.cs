using System;
using System.Text;

namespace MaximumSwap
{
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            var s = new Solution();
            s.MaximumSwap(3287);
            Console.ReadKey();
        }
    }

    public class SolutionBruteForce
    {
        public int MaximumSwap(int num)
        {
            if (num < 10) return num;

            var max = num;
            var number = num.ToString();
            var builder = new StringBuilder(number);

            for (var i = 0; i < number.Length - 1; i++)
            {
                for (var j = i + 1; j < number.Length; j++)
                {
                    Swap(builder, i, j);
                    max = Math.Max(max, int.Parse(builder.ToString()));
                    Swap(builder, j, i);
                }
            }

            return max;
        }

        public void Swap(StringBuilder builder, int from, int to)
        {
            var tmp = builder[from];
            builder[from] = builder[to];
            builder[to] = tmp;
        }
    }

    public class Solution
    {
        public int MaximumSwap(int num)
        {
            var sb = new StringBuilder(num.ToString());
            var last = Enumerable.Repeat(-1, 10).ToArray();

            for (var i = 0; i < sb.Length; i++)
                last[sb[i] - '0'] = i;

            for (var i = 0; i < sb.Length; i++)
            {
                var digit = sb[i] - '0';

                for (var d = 9; d > digit; d--)
                {
                    if (last[d] > i)
                    {
                        Swap(sb, i, last[d]);
                        return int.Parse(sb.ToString());
                    }
                }
            }
            return num;
        }

        public void Swap(StringBuilder sb, int i, int j)
        {
            char temp = sb[i];
            sb[i] = sb[j];
            sb[j] = temp;
        }
    }
}