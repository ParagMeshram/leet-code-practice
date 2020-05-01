using System;

namespace SmallestSubtreeDeepestNodes
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        public TreeNode SubtreeWithAllDeepest(TreeNode root)
        {
            if (root == null) return null;

            var left = Depth(root.left);
            var right = Depth(root.right);

            if (left == right) return root;

            return SubtreeWithAllDeepest(left > right ? root.left : root.right);
        }

        public int Depth(TreeNode root)
        {
            if (root == null) return 0;

            var left = Depth(root.left);
            var right = Depth(root.right);

            return Math.Max(left, right) + 1;
        }
    }
}