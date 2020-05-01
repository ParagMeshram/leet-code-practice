using System;
using System.Collections.Generic;

namespace LongestSubstringWithoutRepeatingChars
{
    internal class Program
    {
        internal static void Main()
        {
            //var input = "parag";

            //for (var i = 0; i < input.Length; i++)
            //{
            //    for (var j = i + 1; j <= input.Length; j++)
            //    {
            //        var sub = input.Substring(i, j - i);
            //        Console.WriteLine(sub);
            //    }
            //}


            var bf = new SolutionBruteForce();
            Console.WriteLine(bf.LengthOfLongestSubstring("abcabcbb"));

            var sw = new SolutionSlidingWindow();
            Console.WriteLine(sw.LengthOfLongestSubstring("dvvdf"));


            var so = new SolutionOptimal();
            Console.WriteLine(sw.LengthOfLongestSubstring("dvvdf"));

            Console.ReadKey();
        }
    }

    public class SolutionBruteForce
    {
        public int LengthOfLongestSubstring(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;

            if (input.Length == 1) return 1;

            var max = 0;

            for (var i = 0; i < input.Length; i++)
            {
                for (var j = i + 1; j <= input.Length; j++)
                {
                    var sub = input.Substring(i, j - i);

                    if (HasUniqueCharacters(sub))
                    {
                        max = Math.Max(max, sub.Length);
                    }
                }
            }

            return max;
        }


        private bool HasUniqueCharacters(string input)
        {
            var hasSet = new HashSet<char>();

            foreach (var ch in input)
            {
                if (hasSet.Contains(ch))
                    return false;

                hasSet.Add(ch);
            }

            return true;
        }
    }

    public class SolutionSlidingWindow
    {
        public int LengthOfLongestSubstring(string input)
        {
            var set = new HashSet<int>();

            var max = 0;
            var start = 0;
            var end = 0;
            var length = input.Length;

            while (start < length && end < length)
            {
                if (!set.Contains(input[end]))
                {
                    set.Add(input[end++]);
                    max = Math.Max(max, end - start);
                }
                else
                {
                    set.Remove(input[start++]);
                }

                Console.WriteLine(input.Substring(start, end - start));
            }

            return max;
        }
    }

    public class SolutionOptimal
    {
        public int LengthOfLongestSubstring(string input)
        {
            var max = 0;
            var length = input.Length;
            var map = new Dictionary<int, int>();

            // try to extend the range [i, j]
            for (int start = 0, end = 0; end < length; end++)
            {
                if (map.ContainsKey(input[end]))
                {
                    start = Math.Max(map[input[end]], start);
                }


                Console.WriteLine(input.Substring(start, end - start));

                max = Math.Max(max, end - start + 1);
                map[input[end]] = end + 1;
            }

            return max;
        }
    }
}