using System;

namespace ValidAnagram
{
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main()
        {
            var solution = new Solution();

            Console.WriteLine(solution.IsAnagram("PARAG", "garap"));
        }
    }

    public class Solution
    {
        public sealed class CharEqualityComparer : IEqualityComparer<char> //^^^
        {
            public bool Equals(char x, char y)
            {
                return char.ToLower(x) == char.ToLower(y);
            }

            public int GetHashCode(char ch)
            {
                return char.ToLower(ch).GetHashCode(); //^^^
            }
        }

        public bool IsAnagram(string s, string t)
        {
            if (s == null && t == null)
                return true;

            if (s == string.Empty && t == string.Empty)
                return true;

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
                return false;

            if (s.Length != t.Length)
                return false;

            var lookup = new Dictionary<char, int>(s.Length, new CharEqualityComparer()); //^^^

            foreach (var ch in s)
            {
                if (lookup.ContainsKey(ch))
                {
                    lookup[ch]++;
                }
                else
                {
                    lookup[ch] = 1;
                }
            }

            foreach (var ch in t)
            {
                if (!lookup.ContainsKey(ch))
                {
                    return false;
                }
                else
                {
                    lookup[ch]--;

                    if (lookup[ch] == 0)
                    {
                        lookup.Remove(ch);
                    }
                }
            }

            return true;
        }
    }
}