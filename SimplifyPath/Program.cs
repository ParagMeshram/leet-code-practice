using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyPath
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var solution = new Solution();

            solution.SimplifyPath("/home/");

            solution.SimplifyPath("/../");

            solution.SimplifyPath("/home//foo/");

            solution.SimplifyPath("/a/./b/../../c/");
        }
    }

    public class Solution
    {
        public string SimplifyPath(string path)
        {
            var directories = new Stack<string>();

            foreach (var part in path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Where(x => x != "."))
            {
                if (part == ".." && directories.Any())
                {
                    directories.Pop();
                }
                else if (part != "..")
                {
                    directories.Push(part);
                }
            }
            return "/" + string.Join("/", directories.Reverse());
        }
    }
}
