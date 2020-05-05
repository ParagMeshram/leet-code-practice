using System;
using System.Linq;
using System.Text;

namespace MinWindowSubstring
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var s = new Solution();

            Console.WriteLine(s.MinWindow("ADOBECODEBANC", "ABCC"));
        }
    }

    public class Solution
    {
        public string MinWindow(string s, string t)
        {
            var lookup = t.GroupBy(ch => ch)
                .ToLookup(g => g.Key, g => g.Count());

            var window = new StringBuilder(s.Length);


            var leftIndex = 0;
            var rightIndex = 0;
            var matchCount = 0;

            while (rightIndex < s.Length)
            {
                var right = s[rightIndex];

                if (lookup.Contains(right))
                {
                    matchCount++;

                    if (matchCount == lookup.Count)
                    {
                        while (leftIndex < rightIndex)
                        {
                            var left = s[leftIndex];
                        }
                    }
                }


                rightIndex++;
            }

            return window.ToString();
        }
    }
}