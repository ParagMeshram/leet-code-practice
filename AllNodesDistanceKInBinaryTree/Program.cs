using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllNodesDistanceKInBinaryTree
{
    internal class Program
    {
        private static void Main()
        {
            var array = new object[]{3, 5, 1, 6, 2, 0, 8, null, null, 7, 4};

            var root = InsertLevelOrder(array, null, 0);

            var s = new Solution();

            s.DistanceK(root, root.left, 2);

        }

        private static TreeNode InsertLevelOrder(object[] array, TreeNode root, int index)
        {
            // Base case for recursion 
            if (index >= array.Length) return root;
            if (array[index] == null) return root;

            var node = new TreeNode((int)array[index]);

            // insert left child 
            node.left = InsertLevelOrder(array, node.left, 2 * index + 1);

            // insert right child 
            node.right = InsertLevelOrder(array, node.right, 2 * index + 2);

            return node;
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
        private Dictionary<TreeNode, TreeNode> parents;

        public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {
            if (root == null || target == null) return new List<int>();

            if (K == 0) return new List<int> { target.val };

            parents = new Dictionary<TreeNode, TreeNode>();

            DFS(root, null);

            var queue = new Queue<TreeNode>();
            var visited = new HashSet<TreeNode>();

            queue.Enqueue(target);
            visited.Add(target);

            var distance = -1;

            while (queue.Count > 0)
            {
                var count = queue.Count;

                distance++;

                if (distance == K)
                {
                    break;
                }

                while (count-- > 0)
                {
                    var current = queue.Dequeue();

                    if (current.left != null && !visited.Contains(current.left))
                    {
                        queue.Enqueue(current.left);
                        visited.Add(current.left);
                    }

                    if (current.right != null && !visited.Contains(current.right))
                    {
                        queue.Enqueue(current.right);
                        visited.Add(current.right);
                    }

                    if (parents.ContainsKey(current) && parents[current] != null && !visited.Contains(parents[current]))
                    {
                        queue.Enqueue(parents[current]);
                        visited.Add(parents[current]);
                    }
                }
            }

            return queue.Select(x => x.val).ToList();
        }

        private void DFS(TreeNode node, TreeNode parent)
        {
            if (node == null) return;

            parents.Add(node, parent);

            DFS(node.left, node);
            DFS(node.right, node);
        }
    }
}
