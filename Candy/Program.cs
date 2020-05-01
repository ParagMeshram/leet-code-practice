using System;
using System.Linq;

namespace Candy
{
    internal class Program
    {
        private static void Main()
        {
            var ratings = new[] { 1, 1, 1, 1, 2, 2, 2, 2, 3, 4, 5, 6, 6, 6, 6, 9 };

            var solution = new Solution();

            var output = solution.Candy(ratings);

            Console.WriteLine(output);


            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int Candy(int[] ratings)
        {
            if (ratings == null || ratings.Length == 0) return 0;

            var candies = Enumerable.Repeat(1, ratings.Length).ToArray();

            for (var index = 1; index < candies.Length; index++)
            {
                if (candies[index] > candies[index - 1])
                {
                    candies[index] = candies[index - 1] + 1;
                }
            }

            var sum = candies[candies.Length - 1];

            for (var index = candies.Length - 2; index >= 0; index--)
            {
                if (candies[index] > candies[index + 1])
                {
                    candies[index] = Math.Max(candies[index], candies[index + 1] + 1);
                }

                sum += candies[index];
            }

            return sum;
        }

        /*
        
            [1,3,0,2,4,0]
        
          6 |
          5 |
          4 |                  *
          3 |      *
          2 |              *
          1 |   *
             ----------*-----------
                1  2   3   4   5   
        */
    }
}