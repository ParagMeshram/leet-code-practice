using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int x)
        {
            Value = x;
        }
    }


    /*

            1
           / \
          2   5
         / \
        3   4

        // Pre-order DFS =>     1, 2, 3, None, None, 4, None, None, 5, None, None
        // Level Order BFS =>   1, 2, 5, 3, 4, None, None, None, None, None, None
                            Root  = Index
                            Left  = 2 * index + 1
                            Right = 2 * index + 2

            1
           /
          2
         / \
        3   4


*/

    public class Codec
    {
        // Encodes a tree to a single string.
        // DFS => Preorder Traversal => root, left, right
        public string serialize(TreeNode root)
        {
            var builder = new StringBuilder();
            SerializeRecursive(root, builder);
            return builder.ToString(0, builder.Length - 1);
        }

        private void SerializeRecursive(TreeNode root, StringBuilder builder)
        {
            if (root == null)
            {
                builder.Append("null,");
                return;
            }

            builder.Append(root.Value);
            builder.Append(',');

            SerializeRecursive(root.Left, builder);
            SerializeRecursive(root.Right, builder);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data))
                return null;

            var queue = new Queue<string>(data.Split(','));


            return DeserializeRecursive(queue);
        }

        private TreeNode DeserializeRecursive(Queue<string> queue)
        {
            if (queue.Count == 0) return null;

            var current = queue.Dequeue();

            if (current == "null") //^^^
            {
                return null;
            }

            Console.WriteLine(current);

            var value = int.Parse(current);

            var root = new TreeNode(value)
            {
                Left = this.DeserializeRecursive(queue),
                Right = this.DeserializeRecursive(queue)
            };


            return root;
        }
    }
}