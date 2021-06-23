using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreePaths
{
    internal class Program
    {
        private static void Main()
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
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            var list = new List<string>();

            DepthFirstTraversal(list, string.Empty, root);

            return list;
        }

        private void DepthFirstTraversal(IList<string> list, string path, TreeNode root)
        {
            if (root == null) return;

            path = string.Concat(path, root.val);

            var hasChildren = root.left != null || root.right != null;

            if (!hasChildren)
            {
                list.Add(path);
                return;
            }

            path = string.Concat(path, "->");

            DepthFirstTraversal(list, path, root.left);
            DepthFirstTraversal(list, path, root.right);
        }
    }
}
