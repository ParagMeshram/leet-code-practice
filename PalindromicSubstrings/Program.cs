using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromicSubstrings
{
    internal class Program
    {
        private static void Main()
        {
            var s = new SolutionBruteForce();

            Console.WriteLine(s.CountSubstrings("aaa"));
        }
    }

    public class SolutionBruteForce
    {
        public int CountSubstrings(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;
            if (input.Length == 1) return 1;

            var count = 0;

            for (var i = 0; i < input.Length; i++)
            {
                for (var j = i; j < input.Length; j++)
                {
                    if (IsPalindrome(input, i, j))
                        count++;
                }
            }

            return count;
        }

        private bool IsPalindrome(string input, int i, int j)
        {
            while (i < j)
            {
                if (input[i] != input[j])
                    return false;
                i++;
                j--;
            }

            return true;
        }
    }
}
