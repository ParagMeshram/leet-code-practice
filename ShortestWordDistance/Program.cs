using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestWordDistance
{
    internal class Program
    {
        private static void Main()
        {
            var solution = new Solution();

            Console.WriteLine(solution.ShortestDistance("practice makes perfect coding makes".Split(), "coding", "practice"));
        }
    }

    public class Solution
    {
        public int ShortestDistanceBruteForce(string[] words, string word1, string word2)
        {
            if (words == null || words.Length == 0) return 0;

            var distance = -1;

            for (var first = 0; first < words.Length; first++)
            {
                if (words[first] == word1)
                {
                    for (var second = 0; second < words.Length; second++)
                    {
                        if (words[second] == word2)
                        {
                            distance = Math.Min(distance, Math.Abs(first - second));
                        }
                    }
                }
            }

            return distance;
        }

        public int ShortestDistanceOptimal(string[] words, string word1, string word2)
        {
            if (words == null || words.Length == 0) return 0;

            var first = -1;
            var second = -1;

            var distance = words.Length;

            for (var index = 0; index < words.Length; index++)
            {
                if (word1 == words[index])
                {
                    first = index;
                }

                if (word2 == words[index])
                {
                    second = index;
                }

                if (first != second)
                {
                    distance = Math.Min(distance, Math.Abs(first - second));
                }
            }

            return distance;
        }
    }
}
