using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignTic_Tac_Toe
{
    internal class Program
    {
        private static void Main()
        {
        }
    }

    /*

    [1,1,1], = 3 or -3 0,2
    [0,0,0]            1,1
    [0,0,0]            2,0



    rows = [0,0,0]
    cols = [0,0,0]

    */

    public class TicTacToe
    {

        private readonly int[] rows;
        private readonly int[] cols;
        private readonly int n;

        private int diagonal1;
        private int diagonal2;

        /** Initialize your data structure here. */
        public TicTacToe(int n)
        {
            rows = new int[n];
            cols = new int[n];
            this.n = n;
        }

        /** Player {player} makes a move at ({row}, {col}).
            @param row The row of the board.
            @param col The column of the board.
            @param player The player, can be either 1 or 2.
            @return The current winning condition, can be either:
                    0: No one wins.
                    1: Player 1 wins.
                    2: Player 2 wins. */
        public int Move(int row, int col, int player)
        {
            var add = player == 1 ? 1 : -1;

            rows[row] += add;
            cols[col] += add;

            if (row == col)
            {
                diagonal1 += add;
            }

            if (row + col == n - 1)
            {
                diagonal2 += add;
            }

            if (Math.Abs(rows[row]) == n ||
                Math.Abs(cols[col]) == n ||
                Math.Abs(diagonal1) == n ||
                Math.Abs(diagonal2) == n)
            {
                return player;
            }

            return 0;
        }
    }
}
