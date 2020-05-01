using System;
using System.Collections.Generic;

namespace PalindromePairs
{
    internal class Program
    {
        private static void Main()
        {
            var words = new[] { "abcd", "dcba", "lls", "s", "sssll" };
            var solution = new Solution();
            var result = solution.PalindromePairs(words);

            Console.ReadKey();
        }
    }


    public class Solution
    {
        public IList<IList<int>> PalindromePairs(string[] words)
        {
            IList<IList<int>> result = new List<IList<int>>();

            for (var i = 0; i < words.Length - 1; i++)
            {
                var word1 = words[i];

                for (var j = i + 1; j < words.Length; j++)
                {
                    var word2 = words[j];

                    if (IsPalindrome(word1, word2))
                    {
                        result.Add(new List<int> { i, j });
                    }
                }
            }

            return result;
        }

        private bool IsPalindrome(string word1, string word2)
        {
            var word = string.Concat(word1, word2);
            var forward = 0;
            var backward = word.Length - 1;

            while (forward < backward)
            {
                if (word[forward] != word[backward])
                    return false;

                forward++;
                backward--;
            }

            return true;
        }
    }
}