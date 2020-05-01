using System;

namespace ValidPalindrome
{
    internal class Program
    {
        private static void Main()
        {
            var o = new Solution();
            Console.WriteLine(o.IsPalindrome("```````"));

            Console.WriteLine(o.IsPalindrome("A man, a plan, a canal: Panama"));
        }
    }

    public class SolutionLeetCode
    {
        public bool IsPalindrome(string s)
        {
            var n = s.Length;
            var left = 0;
            var right = n - 1;

            while (left < right)
            {
                if (!char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                else if (!char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }
                else
                {
                    if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    {
                        return false;
                    }

                    left++;
                    right--;
                }
            }

            return true;
        }
    }

    public class Solution
    {
        public bool IsPalindrome(string input)
        {
            if (string.IsNullOrEmpty(input)) return true;

            var forward = 0;
            var backward = input.Length - 1;

            while (forward < backward)
            {
                if (!char.IsLetterOrDigit(input[forward]))
                {
                    forward++;
                    continue;
                }

                if (!char.IsLetterOrDigit(input[backward]))
                {
                    backward--;
                    continue;
                }

                if (char.ToLower(input[forward]) != char.ToLower(input[backward]))
                {
                    return false;
                }

                forward++;
                backward--;
            }

            return true;
        }
    }
}