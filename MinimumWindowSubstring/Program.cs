using System.Collections.Generic;

namespace MinimumWindowSubstring
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var s = "ADOBECODEBANC";
            var t = "AABC";

            var solution = new SolutionN();

            Console.WriteLine(solution.MinWindow(s, t));

            Console.ReadKey();
        }
    }


    public class Solution
    {
        public string MinWindow(string input, string target)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(target))
                return string.Empty;

            var map = new Dictionary<char, int>();

            foreach (var ch in target)
            {
                if (map.ContainsKey(ch))
                    map[ch]++;
                else
                    map[ch] = 1;
            }


            var left = 0;
            var right = 0;

            while (right < input.Length)
            {
            }

            return string.Empty;
        }
    }

    public class SolutionN
    {
        public string MinWindow(string input, string target)
        {

            if (input.Length < target.Length)
                return "";

            var map = new Dictionary<char, int>();

            foreach (char c in target)
            {
                if (map.ContainsKey(c))
                    map[c]++;
                else
                    map.Add(c, 1);
            }

            int left = 0, right = 0, uniqueCount = map.Count;

            int minSize = int.MaxValue;
            string res = "";

            while (right < input.Length)
            {
                char curr = input[right];
                
                if (map.ContainsKey(curr))
                {
                    map[curr]--;
                    if (map[curr] == 0)
                        uniqueCount--;
                }

                right++;

                while (uniqueCount == 0)
                {
                    if (right - left < minSize)
                    {
                        minSize = right - left;
                        res = input.Substring(left, minSize);
                    }

                    char leftChar = input[left];

                    if (map.ContainsKey(leftChar))
                    {
                        map[leftChar]++;
                        if (map[leftChar] > 0)
                            uniqueCount++;
                    }

                    left++;
                }
            }

            return res;
        }
    }
}