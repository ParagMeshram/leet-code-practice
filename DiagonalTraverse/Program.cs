using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalTraverse
{
    using System.Data.Common;
    using System.Runtime.InteropServices;

    internal class Program
    {
        private static void Main()
        {
            var array = new[]
            {
                new[] {1, 2, 3},
                new[] {4, 5, 6},
                new[] {7, 8, 9}
            };

            var o = new Solution();

            var output = o.FindDiagonalOrder(array);

            Array.ForEach(output, Console.WriteLine);

            Console.ReadKey();
        }
    }

    /*
    
        [0,0], [0,1], [0,2], [0,3]
        [1,0], [1,1], [1,2], [1,3]
        [2,0], [2,1], [2,2], [2,3]
        [3,0], [3,1], [3,2], [3,3]

        rowCount = 4
        columnCount = 4
     
    */

    public class Solution
    {
        public int[] FindDiagonalOrder(int[][] matrix)
        {
            if (matrix == null) return null;
            if (matrix.Length == 0 || matrix[0].Length == 0) return new int[] { };

            var rowCount = matrix.Length;
            var columnCount = matrix[0].Length;
            var cellCount = rowCount * columnCount;

            var index = 0;
            var row = 0;
            var column = 0;
            var path = new List<int>();

            while (index < cellCount)
            {
                path.Add(matrix[row][column]);

                index++;

                if (IsMovingUp(row, column))
                {
                    if (column == columnCount - 1) row++;
                    else if (row == 0) column++;
                    else
                    {
                        row--;
                        column++;
                    }
                }
                else
                {
                    if (row == rowCount - 1) column++;
                    else if (column == 0) row++;
                    else
                    {
                        row++;
                        column--;
                    }
                }
            }

            return path.ToArray();
        }

        private bool IsMovingUp(int row, int column)
        {
            return (row + column) % 2 == 0;
        }
    }
}
