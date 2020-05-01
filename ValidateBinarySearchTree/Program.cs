namespace ValidateBinarySearchTree
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

        public TreeNode(int x)
        {
            val = x;
        }
    }

    public class Solution
    {
        public bool IsValidBST(TreeNode root)
        {
            return DFS(root, long.MinValue, long.MaxValue);
        }

        private bool DFS(TreeNode root, long min, long max)
        {
            if (root == null) return true;

            if (min < root.val && root.val < max)
            {
                return DFS(root.left, min, root.val) && DFS(root.right, root.val, max);
            }

            return false;
        }
    }
}