namespace RangeSumQuery2DImmutable
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    /*
[
  [3, 0, 1, 4, 2],
  [5, 6, 3, 2, 1],
  [1, 2, 0, 1, 5],
  [4, 1, 0, 1, 7],
  [1, 0, 3, 0, 5]
]

  [0, 5, 11, 14, 16],

*/

    public class NumMatrix
    {
        private readonly int[][] prefix;

        public NumMatrix(int[][] matrix)
        {
            var m = matrix.Length; // rows

            if (m == 0) return;

            var n = matrix[0].Length; // columns

            prefix = new int[m][];

            for (var i = 0; i < m; i++)
            {
                prefix[i] = new int[n + 1];

                for (var j = 1; j < n + 1; j++)
                {
                    prefix[i][j] = prefix[i][j - 1] + matrix[i][j - 1];
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            var sum = 0;

            for (var i = row1; i <= row2; i++)
            {
                sum += prefix[i][col2 + 1] - prefix[i][col1];
            }

            return sum;
        }
    }
}