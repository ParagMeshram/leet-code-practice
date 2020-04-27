using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumWindowSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>(); 
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
}
