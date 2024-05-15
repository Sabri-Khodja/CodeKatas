
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace GameOfLife
{
    [TestFixture]
    public class ExerciseUnitTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }
        
        private bool CompareGrid(int[][] grid1, int[][] grid2)
        {
            if (grid1.Length != grid2.Length)
            {
                return false;
            }

            for (int i = 0; i < grid1.Length; i++)
            {
                if (grid1[i].Length != grid2[i].Length)
                {
                    return false;
                }
            }
            
            for (int i = 0; i < grid1.Length; i++)
            {
                for (int j = 0; j < grid1.Length; j++)
                {
                    if (grid1[i][j] != grid2[i][j])
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }
        
        //1st iteration
        [Test]
        public void ReturnsAll0sWhenAll0sInInputGridTest()
        {
            var input = new int[][]
            {
                [0 , 0 , 0],
                [0 , 0 , 0],
                [0 , 0 , 0],
            };
            
            var expectedOutput = new int[][]
            {
                [0 , 0 , 0],
                [0 , 0 , 0],
                [0 , 0 , 0],
            };
            
            Exercise.GameOfLife(input);
            
            Assert.IsTrue(CompareGrid(input, expectedOutput));
        }
        
        //2nd iteration
        [Test]
        public void ReturnsSurvivingCellsWhen2Or3LivingNeighborsInInputGridTest()
        {
            var input = new int[][]
            {
                [1 , 0 , 0],
                [1 , 1 , 0],
                [1 , 1 , 1],
            };
            
            var expectedOutput = new int[][]
            {
                [1 , 0 , 0],
                [0 , 0 , 0],
                [1 , 0 , 1],
            };
            
            Exercise.GameOfLife(input);
            
            Assert.IsTrue(CompareGrid(input, expectedOutput));
        }
       
    }
}
