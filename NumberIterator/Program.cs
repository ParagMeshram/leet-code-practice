using System;

namespace NumberIterator
{
    internal class Program
    {
        private static void Main()
        {
            var input = new[] { new[] { 1, 3, 5, 7 }, new[] { 2, 4, 6, 8 }, new[] { 12, 24, 33, 55, 99 } };
            var iterator = new NumberIterator(input);

            while (iterator.HasNext())
                Console.WriteLine(iterator.Next());

            Console.ReadKey();
        }
    }

    public class NumberIterator
    {
        private readonly int[][] input;
        private readonly int[] indexes;

        public NumberIterator(int[][] input)
        {
            this.input = input;
            this.indexes = new int[input.Length];
        }

        public int Next()
        {
            if (!HasNext())
                throw new InvalidOperationException();

            var min = int.MaxValue;
            var minAt = 0;

            for (var index = 0; index < this.indexes.Length; index++)
            {
                if (this.indexes[index] == this.input[index].Length)
                    continue;

                var current = this.input[index][this.indexes[index]];

                if (current >= min) continue;

                min = current;
                minAt = index;
            }

            if (this.indexes[minAt] < this.input[minAt].Length)
                this.indexes[minAt]++;

            return min;
        }

        public bool HasNext()
        {
            var hasNext = false;

            for (var index = 0; index < this.indexes.Length; index++)
            {
                hasNext = hasNext || this.indexes[index] < this.input[index].Length;
            }

            return hasNext;
        }
    }
}