using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeRightSideView
{
    using System.Collections.ObjectModel;

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
        public TreeNode(int x) { val = x; }
    }


    public class Solution
    {
        public IList<int> RightSideView(TreeNode root)
        {
            if (root == null) return Array.Empty<int>();

            var list = new List<int>();

            DepthFirstSearch(root, 0, list);

            return list;
        }

        private void DepthFirstSearch(TreeNode node, int level, IList<int> list)
        {
            if (node == null) return;

            if (list.Count == level) list.Add(node.val);

            DepthFirstSearch(node.right, level + 1, list);
            DepthFirstSearch(node.left, level + 1, list);
        }
    }
}
