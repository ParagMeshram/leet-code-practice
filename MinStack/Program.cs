using System;
using System.Collections.Generic;

namespace MinStack
{
    using PriorityQueue = System.Collections.Generic.SortedSet<int>;

    internal class Program
    {
        private static void Main()
        {
        }
    }

    public class MinStack
    {
        private Node head;

        public MinStack()
        {
        }

        public void Push(int x)
        {
            if (this.head == null)
            {
                this.head = new Node(x, null, x);
            }
            else
            {
                this.head = new Node(x, this.head, Math.Min(x, this.head.MinValue));
            }
        }

        public void Pop()
        {
            this.head = this.head.Next;
        }

        public int Top()
        {
            return this.head.Value;
        }

        public int GetMin()
        {
            return this.head.MinValue;
        }

        private class Node
        {
            public int Value { get; set; }
            public int MinValue { get; set; }
            public Node Next { get; set; }

            public Node(int value, Node next, int minValue)
            {
                this.Value = value;
                this.Next = next;
                this.MinValue = minValue;
            }
        }
    }

    public class MinStackLogN
    {
        private readonly Stack<int> stack;
        private readonly PriorityQueue heap;

        public MinStackLogN()
        {
            stack = new Stack<int>();
            heap = new PriorityQueue();
        }

        public void Push(int x)
        {
            this.stack.Push(x);
            this.heap.Add(x);
        }

        public void Pop()
        {
            this.stack.Pop();
            this.heap.Remove(this.heap.Min);
        }

        public int Top()
        {
            return this.stack.Peek();
        }

        public int GetMin()
        {
            return this.heap.Min;
        }
    }
}