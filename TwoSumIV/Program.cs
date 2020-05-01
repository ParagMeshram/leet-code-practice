using System.Collections.Generic;

namespace TwoSumIV
{
    public class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int value)
        {
            this.Value = value;
        }
    }

    internal class Program
    {
        private static void Main()
        {
        }
    }

    public class Solution
    {
        public bool FindTarget(TreeNode root, int target)
        {
            var lookup = new HashSet<int>();
            return Find(root, target, lookup);
        }

        private bool Find(TreeNode root, int target, HashSet<int> lookup)
        {
            if (root == null) return false;

            var expected = target - root.Value;

            if (lookup.Contains(expected))
                return true;

            lookup.Add(root.Value);

            return Find(root.Left, target, lookup) || Find(root.Right, target, lookup);
        }

        public bool FindTarget2(TreeNode root, int target)
        {
            var lookup = new HashSet<int>();
            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                var expected = target - node.Value;

                if (lookup.Contains(expected))
                    return true;
                else
                    lookup.Add(node.Value);

                if (node.Left != null)
                    queue.Enqueue(node.Left);

                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }

            return false;
        }


        public bool FindTarget3(TreeNode root, int target)
        {
            var list = new List<int>();

            Inorder(root, list);

            var forward = 0;
            var backward = list.Count - 1;

            while (forward < backward)
            {
                var sum = list[forward] + list[backward];
                if (sum == target)
                    return true;

                if (sum < target)
                    forward++;
                else
                    backward--;
            }

            return false;
        }

        private void Inorder(TreeNode node, ICollection<int> list)
        {
            if (node == null) return;
            Inorder(node.Left, list);
            list.Add(node.Value);
            Inorder(node.Right, list);
        }
    }
}