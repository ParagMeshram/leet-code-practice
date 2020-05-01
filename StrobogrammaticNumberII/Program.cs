using System.Collections.Generic;

namespace StrobogrammaticNumberII
{
    using System.CodeDom;

    internal class Program
    {
        private static void Main()
        {
            var s = new Solution();

            s.FindStrobogrammatic(3);
        }
    }

    public class Solution
    {
        public List<string> FindStrobogrammatic(int n)
        {
            var map = new Dictionary<char, char>
            {
                {'1', '1'},
                {'6', '6'},
                {'8', '8'},
                {'9', '9'},
                {'0', '0'}
            };

            var list = n % 2 == 0 ? new List<string> { "" } : new List<string> { "1", "8", "0" };

            for (var i = n % 2 == 0 ? 1 : 2; i < n; i += 2)
            {
                var cur = new List<string>();

                foreach (var key in map.Keys)
                {
                    foreach (var s in list)
                    {
                        // don't add leading 0s!
                        if (i != n - 1 || key != '0')
                            cur.Add(key + s + map[key]);
                    }
                }

                list = cur;
            }

            return list;
        }
    }
}