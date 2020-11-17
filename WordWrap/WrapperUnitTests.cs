using NUnit.Framework;

namespace WordWrap
{
    [TestFixture]
    public class WrapperUnitTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }
        
        //Iteration 1
        [Test]
        public void WrapReturnsSameTextWhenTextLenghtLowerThanColumn()
        {
            var text = "The quick brown fox jumps over a lazy dog.";
            var formattedText = Wrapper.Wrap(text, 80);

            Assert.AreEqual(text, formattedText);
        }

        //Iteration 2
        [Test]
        public void WrapReturns2LinesWhenTextLenghtSlightlyBiggerThanColumn()
        {
            var text = "The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog.";
            var formattedText = Wrapper.Wrap(text, 80);

            var lines = formattedText.Split(new []{ '\n' });

            Assert.AreEqual(2, lines.Length);
        }

        //Iteration 3
        [Test]
        public void WrapReturnsCorrectFormattedTextForMultilineInputText()
        {
            var text = "The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog.";
            var formattedText = Wrapper.Wrap(text, 80);
            
            Assert.AreEqual(@"The quick brown fox jumps over a lazy dog. The quick brown fox jumps over a
lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps
over a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox
jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick
brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The
quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy
dog. The quick brown fox jumps over a lazy dog. The quick brown fox jumps over
a lazy dog. The quick brown fox jumps over a lazy dog. The quick brown fox
jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The quick
brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy dog. The
quick brown fox jumps over a lazy dog. The quick brown fox jumps over a lazy
dog.", formattedText);
        }

    }
}
