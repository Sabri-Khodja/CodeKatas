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
            
            
        }
    }
}
