using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandPerimeter
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int IslandPerimeter(int[][] grid)
        {
            var rowCount = grid.Length;
            var colCount = grid[0].Length;

            var directions = new[] { new[] { -1, 0 }, new[] { 0, 1 }, new[] { 1, 0 }, new[] { 0, -1 } }; //^^^
            var parameter = 0;

            for (var row = 0; row < rowCount; row++)
            {
                for (var col = 0; col < colCount; col++)
                {
                    if (grid[row][col] == 0) continue;

                    foreach (var dir in directions) // check every direction
                    {
                        var x = row + dir[0];
                        var y = col + dir[1];

                        if (x < 0 || y < 0 || x == rowCount || y == colCount || grid[x][y] == 0)
                            parameter++;
                    }
                }
            }

            return parameter;
        }
    }
}
