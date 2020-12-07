using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DictionaryReplacer
{
    [TestFixture]
    public class DictionaryReplacerUnitTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }
        
        //First iteration
        [Test]
        public void ReturnsEmptyStringWhenEmptyInputString()
        {
            string input = string.Empty;
            string output = DictionaryReplacer.DecodeString(input, new Dictionary<string, string>());
            Assert.AreEqual(string.Empty, output);
        }

        //2nd iteration
        [Test]
        public void ReturnsInputStringWhenEmptyDictionary()
        {
            var input = "input";

            var output = DictionaryReplacer.DecodeString(input, new Dictionary<string, string>());
            Assert.AreEqual(input, output);
        }

        //3rd iteration
        [Test]
        public void ReturnsDecodedInputStringWhenDictionaryContainsKeys()
        {
            var input =  @"\$temp\$ here comes the name \$name\$";
            var decodingDictionary = new Dictionary<string, string>()
            {
                { "temp", "temporary" },
                { "name", "John Doe" },
            };

            var output = DictionaryReplacer.DecodeString(input, decodingDictionary);
            Assert.AreEqual("temporary here comes the name John Doe", output);
        }

        //4th iteration
        [Test]
        public void ReturnsDecodedInputStringWhenDictionaryDoesNotContainAllKeys()
        {
            var input = @"\$temp\$ here comes the name \$name\$";
            var decodingDictionary = new Dictionary<string, string>()
            {
                { "name", "John Doe" },
            };

            var output = DictionaryReplacer.DecodeString(input, decodingDictionary);
            Assert.AreEqual(@"\$temp\$ here comes the name John Doe", output);
        }

    }
}
