using System;
using System.Collections.Generic;

namespace TrappingRainWater
{
    internal class Program
    {
        private static void Main()
        {
            var stack = new Stack<int>();
        }
    }


    /*
        |
        |
        |
        |
        |
        |
        |
        |
        |
        |
        +--------------------------------
          0  1  2  3 
     */

    public class SolutionOptimal
    {
        public int Trap(int[] height)
        {
            if (height.Length <= 2) return 0;

            var water = 0;
            var left = 1;
            var right = height.Length - 2;

            var maxLeft = height[0];
            var maxRight = height[height.Length - 1];


            while (left <= right)
            {
                maxLeft = Math.Max(maxLeft, height[left]);
                maxRight = Math.Max(maxRight, height[right]);

                if (maxLeft < maxRight)
                {
                    water += maxLeft - height[left++];
                }
                else
                {
                    water += maxRight - height[right--];
                }
            }

            return water;
        }
    }

    public class SolutionStack
    {
        public int Trap(int[] height)
        {
            if (height.Length <= 2) return 0;

            var water = 0;
            var current = 0;

            var stack = new Stack<int>();

            while (current < height.Length)
            {
                while (stack.Count > 0 && height[current] > height[stack.Peek()])
                {
                    var top = stack.Pop();

                    if (stack.Count == 0)
                        break;

                    var distance = current - stack.Peek() - 1;

                    var boundedHeight = Math.Min(height[current], height[stack.Peek()]) - height[top];

                    water += distance * boundedHeight;
                }

                stack.Push(current++);
            }

            return water;
        }
    }
}