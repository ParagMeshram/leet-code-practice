using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedArrayToBinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {

        public TreeNode SortedArrayToBST(int[] nums)
        {
            return BuildRecursive(nums, 0, nums.Length - 1);
        }

        public TreeNode BuildRecursive(int[] nums, int left, int right)
        {
            if (right < left) return null;

            int mid = (left + right) / 2;

            var node = new TreeNode(nums[mid]);

            node.left = BuildRecursive(nums, left, mid - 1);
            node.right = BuildRecursive(nums, mid + 1, right);

            return node;
        }
    }


}
