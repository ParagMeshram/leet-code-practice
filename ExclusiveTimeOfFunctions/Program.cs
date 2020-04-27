using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExclusiveTimeOfFunctions
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Solution
    {
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            var ans = new int[n];
            var stack = new Stack<int>();

            foreach (var log in logs)
            {
                var (id, type, ts) = Parse(log);

                switch (type)
                {
                    case "start":
                        if (stack.Count > 0) ans[stack.Peek()] += ts;
                        ans[id] -= ts;
                        stack.Push(id);
                        break;

                    case "end":
                        ans[id] += (ts + 1);
                        stack.Pop();
                        if (stack.Count > 0) ans[stack.Peek()] -= (ts + 1);
                        break;
                }
            }

            return ans;
        }

        private static (int id, string type, int ts) Parse(string log)
        {
            var parts = log.Split(':');

            var id = int.Parse(parts[0]);
            var type = parts[1];
            var ts = int.Parse(parts[2]);

            return (id, type, ts);
        }
    }
}
