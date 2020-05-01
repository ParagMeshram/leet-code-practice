using System;

namespace DiameterOfBinaryTree
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
        private int max;

        public int DiameterOfBinaryTree(TreeNode root)
        {
            max = 0;
            DepthFirstTraversal(root);
            return max;
        }

        public int DepthFirstTraversal(TreeNode root)
        {
            if (root == null) return 0;

            var left = DepthFirstTraversal(root.left);
            var right = DepthFirstTraversal(root.right);

            var diameter = left + right;

            this.max = Math.Max(this.max, diameter);

            return Math.Max(left, right) + 1;
        }
    }
}