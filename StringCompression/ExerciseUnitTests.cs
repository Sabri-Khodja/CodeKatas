﻿
using System;
using System.Collections.Generic;
using System.Linq;
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
        
        //3rd iteration
        [Test]
        public void ReturnsCompressedStringLengthAndCompressedStringWhenConsecutiveCharsInInputStringTest()
        {
            var input = new char[] { 'a', 'a', 'b', 'b', 'c', 'c', 'c' };
            
            var count = Exercise.Compress(input);

            Assert.AreEqual(6, count);
            var compressedChars = input.Take(count).ToArray();
            Assert.AreEqual("a2b2c3", new string(compressedChars));
        }
        
        //4th iteration
        [Test]
        public void ReturnsCompressedStringLengthAndCompressedStringWhenMoreThan10ConsecutiveCharsInInputStringTest()
        {
            var input = new char[] { 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'c', 'c'  };
            
            var count = Exercise.Compress(input);

            Assert.AreEqual(6, count);
            var compressedChars = input.Take(count).ToArray();
            Assert.AreEqual("ab12c2", new string(compressedChars));
        }
    }
}
