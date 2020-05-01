using System;
using System.Text;

namespace MaximumSwap
{
    internal class Program
    {
        private static void Main()
        {
            var s = new Solution();
            s.MaximumSwap(2736);
            Console.ReadKey();
        }
    }

    public class Solution
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
}