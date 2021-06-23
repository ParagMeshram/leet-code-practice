using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienDictionary
{
    using System.Collections;
    using System.Runtime.InteropServices;


    /*
    
    [
        "wrt",
        "wrf",
        "er",
        "ett",
        "rftt",
        "xy"
    ]

    */

    public class Program
    {
        public static void Main()
        {
            var solution = new Solution();
            var output = solution.AlienOrder(new[]
                                        {
                                            "wrt",
                                            "wrf",
                                            "er",
                                            "ett",
                                            "rftt",
                                            "te"
                                        });
            Console.WriteLine(output);
            Console.ReadKey();

        }
    }


    public class Solution
    {
        public string AlienOrder(string[] words)
        {
            var graph = new Dictionary<char, HashSet<char>>();
            var indegree = new Dictionary<char, int>();

            // Step 1. Initialize Graph & Indegree maps
            foreach (var word in words)
            {
                foreach (var ch in word)
                {
                    if (!graph.ContainsKey(ch))
                        graph[ch] = new HashSet<char>();

                    if (!indegree.ContainsKey(ch))
                        indegree[ch] = 0;
                }
            }

            // Step 2. Build Adjacency Matrix & Indegree

            for (var i = 0; i < words.Length - 1; i++)
            {
                var word1 = words[i];
                var word2 = words[i + 1];

                if (word1.Length > word2.Length && word1.StartsWith(word2))
                {
                    return string.Empty;
                }

                for (var j = 0; j < Math.Min(word1.Length, word2.Length); j++)
                {
                    var ch1 = word1[j];
                    var ch2 = word2[j];

                    if (ch1 == ch2) continue; // skip the matching chars

                    if (!graph[ch1].Contains(ch2))
                    {
                        graph[ch1].Add(ch2);
                        indegree[ch2]++;
                    }

                    break;
                }
            }

            // Step 3. BFS

            var sb = new StringBuilder();
            var queue = new Queue<char>();

            foreach (var ch in graph.Keys)
            {
                if (indegree[ch] == 0)
                {
                    queue.Enqueue(ch);
                }
            }

            while (queue.Count > 0)
            {
                var ch = queue.Dequeue();
                sb.Append(ch);

                foreach (var next in graph[ch])
                {
                    indegree[next]--;
                    if (indegree[next] == 0)
                    {
                        queue.Enqueue(next);
                    }
                }
            }

            if (sb.Length != indegree.Count)
            {
                return string.Empty;
            }

            return sb.ToString();
        }
    }

    public class Solution2
    {
        public string AlienOrder(string[] words)
        {
            //build graph  and relative order. I kept order as a class property that could be access and updated by the class function
            var graph = BuildGraph(words);

            //once we have the graph traverse according to graph and relative order
            return bfs(graph);
        }

        private string bfs(Dictionary<char, HashSet<char>> graph)
        {
            var sb = new StringBuilder();
            var queue = new Queue<char>();
            foreach (var c in graph.Keys)
            {
                if (orders[c - 'a'] == 0)
                {
                    queue.Enqueue(c);
                }
            }

            while (queue.Count > 0)
            {
                var c = queue.Dequeue();
                sb.Append(c);
                foreach (var letter in graph[c])
                {
                    orders[letter - 'a']--;
                    if (orders[letter - 'a'] == 0)
                    {
                        queue.Enqueue(letter);
                    }
                }
            }
            var ans = sb.ToString();
            //if some letter is not in our answer there are nodes that couldn't be visited 
            return ans.Length == graph.Count ? ans : "";
        }

        //less is closer to front. By having this we can determine the relative position between unvisited node. 
        private int[] orders = new int[26];

        private Dictionary<char, HashSet<char>> BuildGraph(string[] words)
        {
            var graph = new Dictionary<char, HashSet<char>>();
            //create key
            foreach (var word in words)
            {
                foreach (var l in word)
                {
                    if (!graph.ContainsKey(l))
                        graph[l] = new HashSet<char>();
                }
            }
            //fill up graph
            for (var i = 1; i < words.Length; i++)
            {
                var word1 = words[i - 1];
                var word2 = words[i];
                var wordlen = Math.Min(word1.Length, word2.Length);
                for (var j = 0; j < wordlen; j++)
                {
                    char l1 = word1[j];
                    char l2 = word2[j];
                    //the diff tells us l1 should be sorted before l2
                    if (l1 != l2)
                    {
                        if (!graph[l1].Contains(l2))
                        {
                            graph[l1].Add(l2);

                            //this provides us information about relative position between unvisited nodes
                            orders[l2 - 'a'] += 1;
                        }
                        break;
                    }
                }
            }
            return graph;
        }
    }


    public class SolutionJ
    {

        public string AlienOrder(string[] words)
        {
            //  Step 0: Create data structures and find all unique letters.
            var adjList = new Dictionary<char, HashSet<char>>();
            var counts = new Dictionary<char, int>();

            foreach (var word in words)
            {
                foreach (char c in word)
                {
                    counts[c] = 0;
                    adjList[c] = new HashSet<char>();
                }

            }

            //  Step 1: Find all edges.
            for (int i = 0; (i < (words.Length - 1)); i++)
            {
                String word1 = words[i];
                String word2 = words[(i + 1)];
                //  Check that word2 is not a prefix of word1.
                if (((word1.Length > word2.Length) && word1.StartsWith(word2)))
                {
                    return "";
                }

                //  Find the first non match and insert the corresponding relation.
                for (int j = 0; (j < Math.Min(word1.Length, word2.Length)); j++)
                {
                    if ((word1[j] != word2[j]))
                    {
                        adjList[word1[j]].Add(word2[j]);
                        counts[word2[j]]++;
                        break;
                    }
                }

            }

            //  Step 2: Breadth-first search.
            StringBuilder sb = new StringBuilder();
            Queue<char> queue = new Queue<char>();

            foreach (char c in counts.Keys)
            {
                if (counts[c] == 0)
                {
                    queue.Enqueue(c);
                }

            }

            while (queue.Count > 0)
            {
                char c = queue.Dequeue();
                sb.Append(c);
                foreach (char next in adjList[c])
                {
                    counts[next]--;
                    if (counts[next] == 0)
                    {
                        queue.Enqueue(next);
                    }

                }

            }

            if ((sb.Length < counts.Count))
            {
                return "";
            }

            return sb.ToString();
        }
    }
}