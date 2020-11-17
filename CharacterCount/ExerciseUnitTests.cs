
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CharacterCount
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

        private string _acceptanceTestString = "John Doe";

        private Dictionary<char, int> _acceptanceTestResult = new Dictionary<char, int>()
        {
            {'j', 1},
            {'o', 2},
            {'h', 1},
            {'n', 1},
            {'d', 1},
            {'e', 1},
        };


        [Test]
        public void AssessInitialImplementationTest()
        {
            var resultAsObject = Exercise.GetCharacterCount(_acceptanceTestString);

            var countPerCharacter = resultAsObject as Dictionary<object, object>;

            //The following assert proves that the initial implementation is defective
            Assert.AreNotEqual(_acceptanceTestResult.Keys.Count, countPerCharacter.Keys.Count);
        }

        //1st iteration
        [Test]
        public void ReturnsEmptyDictionaryWhenEmptyStringTest()
        {
            var countPerCharacter = Exercise.GetCharacterCountFixed(String.Empty);

            Assert.AreEqual(0, countPerCharacter.Keys.Count);
        }

        //2nd iteration
        [Test]
        public void Returns1ForAOneCharStringTest()
        {
            var countPerCharacter = Exercise.GetCharacterCountFixed("A");

            Assert.AreEqual(1, countPerCharacter.Keys.Count);
            Assert.AreEqual(1, countPerCharacter['a']);
        }

        //3rd iteration
        [Test]
        public void AcceptanceTest()
        {
            var countPerCharacter = Exercise.GetCharacterCountFixed(_acceptanceTestString);

            Assert.AreEqual(_acceptanceTestResult.Keys.Count, countPerCharacter.Keys.Count);

            Assert.AreEqual(_acceptanceTestResult['j'], countPerCharacter['j']);
            Assert.AreEqual(_acceptanceTestResult['o'], countPerCharacter['o']);
            Assert.AreEqual(_acceptanceTestResult['h'], countPerCharacter['h']);
            Assert.AreEqual(_acceptanceTestResult['n'], countPerCharacter['n']);
            Assert.AreEqual(_acceptanceTestResult['d'], countPerCharacter['d']);
            Assert.AreEqual(_acceptanceTestResult['e'], countPerCharacter['e']);
        }

    }
}
