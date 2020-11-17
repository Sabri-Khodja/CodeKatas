using System;
using System.Diagnostics;
using NUnit.Framework;

namespace ReplaceDigits
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
        
        private string PrintRunningTime(Func<string, string> functionToTime, string input)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var res = functionToTime(input);

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            return res;
        }
        
        [Test]
        public void AssesInitialCodeTest()
        {
            string res = PrintRunningTime((str) =>
            {
                var output = String.Empty;
                for (int i = 0; i < 1000000; i++)
                    output = Exercise.ReplaceDigits(str);
                return output;
            }, "4 score and 7 years ago, 8 men had the same PIN code: 6571");

            Console.WriteLine(res);

            //Following Assert proves the original implementation is defective
            Assert.AreNotEqual("four score and seven years ago, eight men had the same PIN code: six five seven one", res);
        }

        //Iteration 1
        [Test]
        public void ReplaceDigitsWhenTheyAreNotAdjacent()
        {
            var input = "4 score and 7 years ago, 8 men had the same PIN code";
            string res = Exercise.ReplaceDigitsFixed(input);

            Assert.AreEqual("four score and seven years ago, eight men had the same PIN code", res);
        }

        //Iteration 2
        [Test]
        public void ReplaceDigitsWhenTheyAreAdjacent()
        {
            var input = "Address: 21 Highstreet 92310 Greenvalley";
            string res = Exercise.ReplaceDigitsFixed(input);

            Assert.AreEqual("Address: two one Highstreet nine two three one zero Greenvalley", res);
        }

        //Iteration 3
        [Test]
        public void ReplaceDigitsWhenTheyAreAtTheEnd()
        {
            var input = "Agent 007";
            string res = Exercise.ReplaceDigitsFixed(input);

            Assert.AreEqual("Agent zero zero seven", res);
        }

        [Test]
        public void AcceptanceTest()
        {
            string res = PrintRunningTime((str) =>
           {
               var output = String.Empty;
               for (int i = 0; i < 1000000; i++)
                   output = Exercise.ReplaceDigitsFixed(str);
               return output;
           }, "4 score and 7 years ago, 8 men had the same PIN code: 6571");

            Console.WriteLine(res);

            Assert.AreEqual("four score and seven years ago, eight men had the same PIN code: six five seven one", res);
        }

    }
}
