using System;
using System.Linq;

namespace GameOfLife
{
    public static class Exercise
    {
        public static void GameOfLife(int[][] board)
        {
            var numberOfRows = board.Length;
            var numberOfColumns = board[0].Length;
            
            var outputBoard = new int[numberOfRows, numberOfColumns];
            
            for (var i = 0; i < numberOfRows; i++)
            {
                for (var j = 0; j < numberOfColumns; j++)
                {
                    var numberOfLivingNeighbors = ComputeNumberOfLivingNeighbors(board, i, j, numberOfRows, numberOfColumns);
                    if (board[i][j] == 1)
                    {
                        if (numberOfLivingNeighbors is 2 or 3)
                        {
                            outputBoard[i, j] = 1;
                        }
                    }
                    else
                    {
                        if (numberOfLivingNeighbors == 3)
                        {
                            outputBoard[i, j] = 1;
                        }
                    }
                }
            }

            for (var i = 0; i < numberOfRows; i++)
            {
                for (var j = 0; j < numberOfColumns; j++)
                {
                    board[i][j] = outputBoard[i, j];
                }
            }
        }
        
        private static int ComputeNumberOfLivingNeighbors(int[][] board, int row, int column, int numberOfRows, int numberOfColumns)
        {
            int lowerRow = Math.Max(row - 1, 0);
            int higherRow = Math.Min(row + 1, numberOfRows - 1);
            int lowerColumn = Math.Max(column - 1, 0);
            int higherColumn = Math.Min(column + 1, numberOfColumns - 1);

            var count = 0;
            for (var i = lowerRow; i <= higherRow; i++)
            {
                for (var j = lowerColumn; j <= higherColumn; j++)
                {
                    count += board[i][j];
                }
            }
            
            return count - board[row][column];
        }
        
    }
}
