using System;
using System.Diagnostics;
using NUnit.Framework;

namespace MatrixMultiplication
{
    [TestFixture]
    public class ExerciseUnitTests
    {
        [SetUp]
        public void SetUp()
        {
            GC.Collect();
        }

        [TearDown]
        public void TearDown()
        {
            
        }


        [Test]
        public void AssessInitialCodeTest()
        {
            var matrix1 = new Matrix(new int[2,3] { { 1, 2, 3 },  { 4, 5, 6 } });
            var matrix2 = new Matrix(new int[3,2] { { 7, 8 }, { 9, 10 }, { 11, 12 } });

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Matrix res = null;

            for (int i = 0; i < 50000000; i++)
            {
                res = Exercise.Multiply(matrix1, matrix2);
            }

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Assert.AreEqual(58, res[0, 0]);
            Assert.AreEqual(64, res[0, 1]);
            Assert.AreEqual(139, res[1, 0]);
            Assert.AreEqual(154, res[1, 1]);
        }


        [Test]
        public void AcceptanceTestImplementation1()
        {
            var matrix1 = new MatrixOptimized1(new int[2][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } } );
            var matrix2 = new MatrixOptimized1(new int[3][] { new int[] { 7, 8 }, new int[] { 9, 10 }, new int[] { 11, 12 } });

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            MatrixOptimized1 res = null;

            for (int i = 0; i < 50000000; i++)
            {
                res = Exercise.Multiply(matrix1, matrix2);
            }

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Assert.AreEqual(58, res[0, 0]);
            Assert.AreEqual(64, res[0, 1]);
            Assert.AreEqual(139, res[1, 0]);
            Assert.AreEqual(154, res[1, 1]);
        }

        [Test]
        public void AcceptanceTestImplementation2()
        {
            var matrix1 = new MatrixOptimized2(new int[] { 1, 2, 3, 4, 5, 6 }, 2, 3);
            var matrix2 = new MatrixOptimized2(new int[] { 7, 8,  9, 10, 11, 12 }, 3, 2);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            MatrixOptimized2 res = null;

            for (int i = 0; i < 50000000; i++)
            {
                res = Exercise.Multiply(matrix1, matrix2);
            }

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Assert.AreEqual(58, res[0, 0]);
            Assert.AreEqual(64, res[0, 1]);
            Assert.AreEqual(139, res[1, 0]);
            Assert.AreEqual(154, res[1, 1]);
        }
    }
}
