using System.Collections.Generic;

namespace BinarySearchTreeToDoublyList
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;

        public Node()
        {
        }

        public Node(int _val)
        {
            val = _val;
            left = null;
            right = null;
        }

        public Node(int _val, Node _left, Node _right)
        {
            val = _val;
            left = _left;
            right = _right;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public Node TreeToDoublyList(Node root)
        {
            if (root == null) return null;

            var queue = new Queue<Node>();

            InOrderTraversal(root, queue);

            var head = queue.Dequeue();

            var prev = head;
            var current = head;

            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                prev.right = current;
                current.left = prev;
                prev = current;
            }

            current.right = head;
            head.left = current;

            return head;
        }

        public void InOrderTraversal(Node root, Queue<Node> queue)
        {
            if (root == null) return;
            InOrderTraversal(root.left, queue);
            queue.Enqueue(root);
            InOrderTraversal(root.right, queue);
        }
    }

    public class SolutionOptimized
    {
        private Node head;
        private Node tail;

        public Node TreeToDoublyList(Node root)
        {
            if (root == null) return null;

            Traversal(root);

            return head;
        }

        public void Traversal(Node root)
        {
            if (root == null) return;

            Traversal(root.left);

            if (this.head == null)
            {
                this.head = root;
            }

            this.tail = root;

            Traversal(root.right);
        }
    }
}