using System;
using System.Collections.Generic;

namespace MergeKSorted
{
    internal class Program
    {
        private static void Main()
        {
            var lists = new ListNode[3];

            //lists[0] = new ListNode(1, new ListNode(4, new ListNode(5)));
            //lists[1] = new ListNode(1, new ListNode(3, new ListNode(4)));
            //lists[2] = new ListNode(2, new ListNode(6));

            //lists[0] = new ListNode(1, new ListNode(2, new ListNode(2)));
            //lists[1] = new ListNode(1, new ListNode(1, new ListNode(2)));


            lists[0] = new ListNode(-2, new ListNode(-1, new ListNode(-1)));
            lists[1] = null;

            var s = new Solution();

            var output = s.MergeKLists(lists);

            Console.ReadKey();
        }
    }


    // Definition for singly-linked list

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }

        public ListNode(int val, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }


    public class Solution
    {
        public class ListNodeComparer : IComparer<ListNode>
        {
            public int Compare(ListNode n1, ListNode n2)
            {
                return n1.val.CompareTo(n2.val);
            }
        }

        public class PriorityQueue<T>
        {
            private class PQItem
            {
                public T Item { get; set; }
                public int Index { get; set; }
            }

            private int index = 0;
            private readonly SortedSet<PQItem> set;

            public int Count => set.Count;

            public PriorityQueue(IComparer<T> comparer = null)
            {
                comparer = comparer ?? Comparer<T>.Default;
                set = new SortedSet<PQItem>(Comparer<PQItem>.Create((x, y) =>
                    comparer.Compare(x.Item, y.Item) == 0 ? x.Index - y.Index : comparer.Compare(x.Item, y.Item)));
            }

            public void Enqueue(T item)
            {
                set.Add(new PQItem { Item = item, Index = index++ });
            }

            public T Dequeue()
            {
                var min = set.Min;
                this.set.Remove(min);
                return min.Item;
            }
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            var queue = CreatePriorityQueue(lists);

            if (queue.Count == 0) return null;

            var head = queue.Dequeue();

            var current = head;

            while (queue.Count > 0)
            {
                current.next = queue.Dequeue();
                current = current.next;
            }

            return head;
        }

        private PriorityQueue<ListNode> CreatePriorityQueue(ListNode[] lists)
        {
            var queue = new PriorityQueue<ListNode>(new ListNodeComparer());

            foreach (var head in lists)
            {
                var current = head;

                while (current != null)
                {
                    queue.Enqueue(current);
                    current = current.next;
                }
            }

            return queue;
        }
    }
}