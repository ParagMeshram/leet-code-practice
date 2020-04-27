using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeIterator
{
    using System.Collections;

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

    public class SolutionInOrderTraversal
    {
        public class BSTIterator
        {
            private readonly Queue<int> queue;

            public BSTIterator(TreeNode root)
            {
                queue = new Queue<int>();
                InOrderTraversal(root);
            }

            public void InOrderTraversal(TreeNode root)
            {
                if (root == null) return;

                InOrderTraversal(root.left);
                queue.Enqueue(root.val);
                InOrderTraversal(root.right);
            }

            /** @return the next smallest number */
            public int Next()
            {
                return queue.Dequeue();
            }

            /** @return whether we have a next smallest number */
            public bool HasNext()
            {
                return this.queue.Count > 0;
            }
        }
    }

    public class SolutionOptimalPartialTraversal
    {
        public class BSTIterator
        {
            private readonly Stack<TreeNode> stack;

            public BSTIterator(TreeNode root)
            {
                this.stack = new Stack<TreeNode>();
                TraverseTillLeftIsNull(root);
            }

            public void TraverseTillLeftIsNull(TreeNode root)
            {
                if (root == null) return;

                var trav = root;

                while (trav != null)
                {
                    this.stack.Push(trav);
                    trav = trav.left;
                }
            }

            /** @return the next smallest number */
            public int Next()
            {
                var item = this.stack.Pop();

                if (item.right != null)
                {
                    TraverseTillLeftIsNull(item.right);
                }

                return item.val;
            }

            /** @return whether we have a next smallest number */
            public bool HasNext()
            {
                return this.stack.Count > 0;
            }
        }
    }
}