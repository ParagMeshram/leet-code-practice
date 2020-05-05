using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchA2DMatrixII
{
    internal class Program
    {
        private static void Main()
        {

        }
    }

    public class Solution
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            var rowCount = matrix.GetLength(0);
            var colCount = matrix.GetLength(1);

            var row = rowCount - 1;
            var col = 0;

            while (row >= 0 && col < colCount)
            {
                if (matrix[row, col] == target)
                    return true;

                if (target < matrix[row, col])
                    row--;
                else
                    col++;
            }

            return false;
        }
    }
}
