
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
        public void Returns0AndEmptyStringWhenEmptyStringTest()
        {
            var input = new char[] {};

            var count = Exercise.Compress(input);

            Assert.AreEqual(0, count);
            Assert.AreEqual(0, input.Length);
        }
        
        //2nd iteration
        [Test]
        public void ReturnsStringLengthAndInputStringWhenNoSameConsecutiveCharsTest()
        {
            var input = new char[] { 'a', 'b', 'c', 'd', 'a', 'd'};
            var inputAsString = new string(input); 

            var count = Exercise.Compress(input);

            Assert.AreEqual(6, count);
            Assert.AreEqual(6, input.Length);
            Assert.AreEqual(inputAsString, new string(input));
        }
    }
}
