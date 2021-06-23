using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrixMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = new[]
            {
                new []{  1, 0, 0},
                new []{ -1, 0, 3}
            };

            var B = new int[][]
            {
                new []{7, 0, 0},
                new []{0, 0, 0},
                new []{0, 0, 1}
            };

            var solution = new Solution();
            var C = solution.Multiply(A, B);
        }
    }

    public class Solution
    {
        public int[][] Multiply(int[][] A, int[][] B)
        {
            var rowA = A.Length;
            if (rowA == 0) return new int[0][];
            var rowB = B.Length;
            var colB = B[0].Length;

            var result = new int[rowA][];

            for (int i = 0; i < rowA; i++)
            {
                result[i] = new int[colB];
            }

            for (int i = 0; i < rowA; i++)
            {
                for (int j = 0; j < rowB; j++)
                {
                    if (A[i][j] == 0) continue;
                    for (int k = 0; k < colB; k++)
                    {
                        result[i][k] += A[i][j] * B[j][k];
                    }
                }
            }

            return result;
        }
    }
}
