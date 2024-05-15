using System;
using System.Linq;

namespace GameOfLife
{
    public static class Exercise
    {
        public static void GameOfLife(int[][] board)
        {
            var allZeros = board.Select(e => e).SelectMany(e => e).All(i => i == 0);

            if (allZeros)
            {
                return;
            }

            var outputBoard = new int[board.Length, board[0].Length];
            
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == 1)
                    {
                        var numberOfLivingNeighbors = ComputeNumberOfLivingNeighbors(board, i, j);
                        if (numberOfLivingNeighbors is 2 or 3)
                        {
                            outputBoard[i, j] = 1;
                        }
                    }
                }
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    board[i][j] = outputBoard[i, j];
                }
            }
        }
        
        private static int ComputeNumberOfLivingNeighbors(int[][] board, int row, int column)
        {
            int lowerRow = Math.Max(row - 1, 0);
            int higherRow = Math.Min(row + 1, board.Length - 1);
            int lowerColumn = Math.Max(column - 1, 0);
            int higherColumn = Math.Min(column + 1, board[0].Length - 1);

            var count = 0;
            for (int i = lowerRow; i <= higherRow; i++)
            {
                for (int j = lowerColumn; j <= higherColumn; j++)
                {
                    count += board[i][j];
                }
            }
            
            return count - board[row][column];
        }
        
    }
}
