
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace StringCompression
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
      

        //1st iteration
        [Test]
        public void Returns0AndEmptyStringyWhenEmptyStringTest()
        {
            var input = new char[] {};

            var count = Exercise.Compress(input);

            Assert.AreEqual(0, count);
            Assert.AreEqual(0, input.Length);
        }
    }
}
