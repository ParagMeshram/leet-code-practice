using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxDifferenceNodeAndAncestor
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
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public int MaxAncestorDiff(TreeNode root)
        {

            var lmin = int.MaxValue;
            var lmax = int.MinValue;

            var rmin = int.MaxValue;
            var rmax = int.MinValue;

            if (root == null) return 0;

            if (root.left != null)
                (lmin, lmax) = getMinMax(root.left, root.val, root.val);

            if (root.right != null)
                (rmin, rmax) = getMinMax(root.right, root.val, root.val);


            return Math.Max(lmax - lmin, rmax - rmin);
        }

        private (int, int) getMinMax(TreeNode n, int min, int max)
        {
            min = Math.Min(min, n.val);
            max = Math.Max(max, n.val);

            var lmin = min;
            var lmax = max;

            var rmin = min;
            var rmax = max;



            if (n.left != null)
                (lmin, lmax) = getMinMax(n.left, min, max);

            if (n.right != null)
                (rmin, rmax) = getMinMax(n.right, min, max);

            return (lmax - lmin > rmax - rmin ? (lmin, lmax) : (rmin, rmax));
        }
    }

    public class SolutionSimple
    {
        public int MaxAncestorDiff(TreeNode root)
        {
            return Helper(root, root.val, root.val);
        }

        private static int Helper(TreeNode node, int min, int max)
        {
            if (node == null) return 0;

            var res = Math.Max(node.val - min, max - node.val);

            min = Math.Min(min, node.val);
            max = Math.Max(max, node.val);

            return Math.Max(res, Math.Max(Helper(node.left, min, max), Helper(node.right, min, max)));
        }
    }
}
