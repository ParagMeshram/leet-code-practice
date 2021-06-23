using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch
{
    internal class Program
    {
        private static void Main()
        {
            //var board = new[]
            //{
            //    new []{'A', 'B', 'C', 'E'},
            //    new []{'S', 'F', 'C', 'S'},
            //    new []{'A', 'D', 'E', 'E'}
            //};

            var board = new[]
            {
                new []{'a', 'b'},
                new []{'c', 'd'}
            };


            Console.WriteLine(new Solution().Exist(board, "acdb"));
        }
    }

    public class Solution
    {
        public bool Exist(char[][] board, string word)
        {
            var rowCount = board.Length;
            var colCount = board[0].Length;

            var directions = new[,] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };

            var start = word[0];

            for (var row = 0; row < rowCount; row++)
            {
                for (var col = 0; col < colCount; col++)
                {
                    if (char.ToLower(board[row][col]) != start) continue;

                    var index = 0;
                    var stack = new Stack<(int, int)>();
                    var visited = new HashSet<(int, int)>();

                    stack.Push((row, col));

                    while (stack.Count > 0)
                    {
                        var (r, c) = stack.Pop();

                        visited.Add((r, c));

                        if (char.ToLower(board[r][c]) != char.ToLower(word[index])) continue;

                        for (var k = 0; k < directions.GetLength(0); k++)
                        {
                            var i = r - directions[k, 0];
                            var j = c - directions[k, 1];

                            if (i < 0 || j < 0 || i >= rowCount || j >= colCount || visited.Contains((i, j))) continue;

                            stack.Push((i, j));
                        }

                        index++;
                    }
                }
            }

            return false;
        }
    }
}
