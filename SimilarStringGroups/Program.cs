using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimilarStringGroups
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    public class SolutionLeetCode
    {
        public int NumSimilarGroups(string[] A)
        {
            if (A.Length < 2) return A.Length;

            A = (new HashSet<string>(A)).ToArray();

            var graph = BuildGraph(A);

            var visited = new HashSet<string>();

            int groups = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (!visited.Contains(A[i]))
                {
                    DFS(A[i], graph, visited);
                    groups++;
                }
            }

            return groups;
        }

        private void DFS(string word, Dictionary<string, IList<string>> graph, HashSet<string> visited)
        {
            visited.Add(word);

            foreach (var next in graph[word])
            {
                if (visited.Contains(next)) continue;
                DFS(next, graph, visited);
            }
        }

        private Dictionary<string, IList<string>> BuildGraph(string[] words)
        {
            var graph = new Dictionary<string, IList<string>>();
            foreach (string word in words)
            {
                graph[word] = new List<string>();
            }

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (IsSimilar(words[i], words[j]))
                    {
                        graph[words[i]].Add(words[j]);
                        graph[words[j]].Add(words[i]);
                    }
                }
            }

            return graph;
        }

        private bool IsSimilar(string s1, string s2)
        {
            int diff = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    diff++;
                    if (diff > 2) return false;
                }
            }

            return true;
        }
    }
}
