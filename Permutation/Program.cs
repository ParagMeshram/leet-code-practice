using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutation
{
    using System.ComponentModel.Design;

    internal class Program
    {
        private static void Main()
        {
            var s = new Solution2();
            
            var list = s.Permutation("abc");

            Console.ReadKey();
        }
    }

    public class Solution1
    {
        public List<string> Permutation(string input)
        {
            var list = new List<string>();
            Permutation(list, string.Empty, input);
            return list;
        }

        private void Permutation(List<string> perms, string prefix, string suffix)
        {
            if (suffix.Length == 0)
            {
                perms.Add(prefix);
                return;
            }

            for (var index = 0; index < suffix.Length; index++)
            {
                Permutation(perms, string.Concat(prefix, suffix[index]),
                    string.Concat(suffix.Substring(0, index), suffix.Substring(index + 1)));
            }
        }
    }

    public class Solution
    {
        public List<string> Permutation(string input)
        {
            var list = new List<string>();

            var sb = new StringBuilder(input);

            Permute(0, input.Length);
            
            return list;

            void Permute(int i, int j)
            {
                if (i == j - 1)
                {
                    list.Add(sb.ToString());
                    return;
                }

                for (var k = i; k < j; k++)
                {
                    Swap(i, k);
                    Permute(i + 1, k);
                    Swap(i, k);
                }
            }

            void Swap(int i, int j)
            {
                var ch = sb[i];
                sb[i] = sb[j];
                sb[j] = ch;
            }
        }
    }

    public class Solution2
    {
        private void Permutations(List<string> list, StringBuilder sb, int i, int n)
        {
            // base condition
            if (i == n - 1)
            {
                list.Add(sb.ToString());
                return;
            }

            // process each character of the remaining string
            for (var j = i; j < n; j++)
            {
                Swap(sb, i, j); 

                // recur for string [i+1, n-1]
                Permutations(list, sb, i + 1, n); 

                // backtrack (restore the string to its original state)
                Swap(sb, i, j);
            }
        }

        private void Swap(StringBuilder sb, int i, int j)
        {
            var ch = sb[i];
            sb[i] = sb[j];
            sb[j] = ch;
        }

        public List<string> Permutation(string input)
        {
            var list = new List<string>();

            Permutations(list,new StringBuilder(input), 0, input.Length);

            return list;
        }
    }
}
