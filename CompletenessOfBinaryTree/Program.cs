using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletenessOfBinaryTree
{
    internal class Program
    {
        private static void Main()
        {
            var root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.right = new Node(5);
            root.left.left = new Node(4);
            //root.right.right = new Node(6);

            var s = new Solution();

            Console.WriteLine(s.IsCompleteTree(root));

            Console.ReadKey();
        }
    }

    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }

    public class Solution
    {
        public bool IsCompleteTree(Node root)
        {
            var count = CountNodes(root);
            return IsCompleteSubtree(root, 0, count);
        }

        private static bool IsCompleteSubtree(Node root, int index, int count)
        {
            if (root == null) return true;

            if (index >= count)
                return false;

            return IsCompleteSubtree(root.left, 2 * index + 1, count) && IsCompleteSubtree(root.right, 2 * index + 2, count);
        }

        private static int CountNodes(Node root)
        {
            if (root == null) return 0;

            return (1 + CountNodes(root.left) + CountNodes(root.right));
        }

    }


    public class Solution
    {
        public bool IsCompleteTree(Node root)
        {
            var count = CountNodes(root);
            
        }

        private static bool IsCompleteSubtree(Node root, int index, int count)
        {
            if (root == null) return true;

            return (IsCompleteSubtree(root.left, /*calc index*/, count) && IsCompleteSubtree(root.right, /*calc index*/, count))
        }

        private static int CountNodes(Node root)
        {
            if (root == null) return 0;

            return (1 + CountNodes(root.left) + CountNodes(root.right));
        }

    }


}
