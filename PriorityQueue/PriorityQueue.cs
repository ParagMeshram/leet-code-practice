namespace PriorityQueue
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;


    public class Program
    {
        public static void Main()
        {
            var queue = new PriorityQueue<int>(type: QueueType.Max);

            queue.Enqueue(5);
            queue.Enqueue(10);
            queue.Enqueue(10);
            queue.Enqueue(3);
            queue.Enqueue(10);
            queue.Enqueue(10);
            queue.Enqueue(3);
            queue.Enqueue(3);

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            Console.ReadKey();
        }
    }


    /*   0  1  2  3  4
        [2, 4, 7, 5, 3]


         2
       /  \
      4    7
    /  \
   5    3*


     */

    public enum QueueType
    {
        Min = 0,
        Max
    }

    public class PriorityQueue<T>
    {
        private readonly IComparer<T> comparer;
        private readonly int capacity;
        private T[] heap;


        public int Count { get; private set; }
        public QueueType Type { get; private set; }

        public PriorityQueue(IComparer<T> comparer = null, int capacity = 16, QueueType type = QueueType.Min)
        {

            this.comparer = comparer ?? Comparer<T>.Default;
            this.capacity = capacity;
            this.heap = new T[capacity];
            this.Type = type;
            this.Count = 0;
        }


        public void Enqueue(T value)
        {
            if (Count >= heap.Length)
            {
                Array.Resize(ref this.heap, Count * 2);
            }

            this.heap[Count] = value;
            this.ShiftUp(Count++);
        }

        public T Dequeue()
        {
            var value = this.heap[0];

            this.heap[0] = this.heap[--Count];

            if (Count > 0)
                ShiftDown(0);

            return value;
        }

        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException("Priority Queue Empty");

            return this.heap[0];
        }

        private void ShiftUp(int index)
        {
            var value = this.heap[index];

            while (HasParent(index) && Compare(value, Parent(index)) < 0)
            {
                heap[index] = Parent(index);
                index = ParentIndex(index);
            }

            heap[index] = value;
        }

        private int Compare(T a, T b)
        {
            var result = this.comparer.Compare(a, b);
            return Type == QueueType.Min ? result : result * -1;
        }

        private void ShiftDown(int index)
        {
            var value = this.heap[index];

            while (HasLeftChild(index))
            {
                var left = LeftChildIndex(index);

                if (HasRightChild(index) && Compare(RightChild(index), LeftChild(index)) < 0)
                {
                    left = RightChildIndex(index);
                }

                if (Compare(value, this.heap[left]) < 0)
                {
                    break;
                }

                heap[index] = heap[left];
                index = left;
            }

            heap[index] = value;
        }

        private static int ParentIndex(int index) => (index - 1) / 2;
        private static int LeftChildIndex(int index) => (index * 2) + 1;
        private static int RightChildIndex(int index) => (index * 2) + 2;

        private bool HasLeftChild(int index) => LeftChildIndex(index) <= Count;
        private bool HasRightChild(int index) => RightChildIndex(index) <= Count;
        private static bool HasParent(int index) => index > 0 && ParentIndex(index) >= 0; //^^^

        private T Parent(int index) => heap[ParentIndex(index)];
        private T LeftChild(int index) => heap[LeftChildIndex(index)];
        private T RightChild(int index) => heap[RightChildIndex(index)];
    }
}