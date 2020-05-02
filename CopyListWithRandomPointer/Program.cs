using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyListWithRandomPointer
{
    internal class Program
    {
        private static void Main()
        {
        }
    }
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }

    public class Solution
    {
        private readonly Dictionary<Node, Node> visited = new Dictionary<Node, Node>();

        public Node CopyRandomList(Node head)
        {
            if (head == null) return null;

            if (visited.ContainsKey(head))
            {
                return visited[head];
            }

            var copy = new Node(head.val);

            visited.Add(head, copy);

            copy.next = CopyRandomList(head.next);
            copy.random = CopyRandomList(head.random);

            return copy;
        }
    }
}
