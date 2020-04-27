using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestRectangleInHistogram
{
    internal class Program
    {
        public static void Main()
        {
            var solution = new Solution();
            var area = solution.LargestRectangleArea(new[] { 0, 2, 3, 4, 2, 3, 2 });
            Console.WriteLine(area);
        }
    }

    public class Solution
    {
        public int LargestRectangleArea(int[] heights)
        {
            if (heights == null || heights.Length == 0) return 0;

            if (heights.Length == 1) return heights[0];

            var stack = new Stack<int>();

            stack.Push(-1);

            var maxArea = 0;

            for (var index = 0; index < heights.Length; index++)
            {
                while (stack.Peek() != -1 && heights[stack.Peek()] >= heights[index])
                {
                    maxArea = Math.Max(maxArea, heights[stack.Pop()] * (index - stack.Peek() - 1));
                }

                stack.Push(index);
            }

            while (stack.Peek() != -1)
            {
                maxArea = Math.Max(maxArea, heights[stack.Pop()] * (heights.Length - stack.Peek() - 1));
            }

            return maxArea;
        }
    }
}
