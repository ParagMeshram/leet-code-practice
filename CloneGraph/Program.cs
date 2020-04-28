using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneGraph
{
    internal class Program
    {
        private static void Main()
        {
        }
    }

    // Definition for a Node.
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public class SolutionBFS
    {
        public Node CloneGraph(Node node)
        {
            if (node == null) return null;

            var queue = new Queue<Node>();
            var visited = new Dictionary<Node, Node>();

            queue.Enqueue(node);
            visited[node] = new Node(node.val);

            while (queue.Count > 0)
            {
                var old = queue.Dequeue();

                if (old.neighbors.Count > 0)
                {
                    foreach (var neighbor in old.neighbors)
                    {
                        if (!visited.ContainsKey(neighbor))
                        {
                            visited[neighbor] = new Node(neighbor.val);
                            queue.Enqueue(neighbor);
                        }

                        visited[old].neighbors.Add(visited[neighbor]);
                    }
                }
            }

            return visited[node];
        }
    }



    /*             
     *      A------R <--- node
     *      |      | \ 
     *      |      |  \
     *      P------Q---T
     *
     * Visited [R, A, ]
     *
     *
     */

    public class SolutionDFS
    {
        private readonly Dictionary<Node, Node> visited = new Dictionary<Node, Node>();

        public Node CloneGraph(Node node)
        {
            if (node == null) return null;

            // Visit the node

            if (this.visited.ContainsKey(node)) return this.visited[node];
            
            this.visited[node] = new Node(node.val);

            if (node.neighbors.Count > 0)
            {
                foreach (var neighbor in node.neighbors)
                {
                    this.visited[node].neighbors.Add(CloneGraph(neighbor));
                }
            }

            return this.visited[node];
        }
    }
}
