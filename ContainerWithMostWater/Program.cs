using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerWithMostWater
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int MaxArea(int[] height)
        {
            if (height == null || height.Length <= 1) return 0;

            var max = 0;

            for (var i = 0; i < height.Length - 1; i++)
            {
                for (var j = i + 1; j < height.Length; j++)
                {
                    max = Math.Max(max, Math.Min(height[i], height[j]) * (j - i));
                }
            }

            return max;
        }


        public int MaxArea2(int[] height)
        {
            if (height == null || height.Length <= 1) return 0;

            var max = 0;
            var forward = 0;
            var backward = height.Length;

            while (forward < backward)
            {
                max = Math.Max(max, Math.Min(height[forward], height[backward]) * (backward - forward));

                if (height[forward] < height[backward])
                {
                    forward++;
                }
                else
                {
                    backward--;
                }
            }

            return max;
        }
    }
}
