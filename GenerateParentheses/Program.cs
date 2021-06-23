using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var ans = new List<string>();
            var sb = new StringBuilder();

            dfs(0, 0);

            return ans;

            void dfs(int open, int close)
            {
                if (open > n || close > n || close > open)
                    return;

                if (close == n && open == n)
                {
                    ans.Add(sb.ToString());
                    return;
                }

                sb.Append("(");
                dfs(open + 1, close);
                sb.Length--;

                sb.Append(")");
                dfs(open, close + 1);
                sb.Length--;
            }
        }
    }
}
