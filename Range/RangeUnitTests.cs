using System.Linq;
using NUnit.Framework;

namespace Range
{
    [TestFixture]
    public class RangeUnitTests
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
        public void GivenARangeThenContainReturnsFalseWhenProvidedValueIsLowerThanLowerEndOfTheRange()
        {
            var range = new Range(5,true,10,true);
            Assert.IsFalse(range.Contains(3));
        }

        //2nd iteration
        [Test]
        public void GivenARangeThenContainReturnsFalseWhenProvidedValueIsGreaterThanUpperEndOfTheRange()
        {
            var range = new Range(5, true, 10, true);
            Assert.IsFalse(range.Contains(12));
        }

        //3rd iteration
        [Test]
        public void GivenARangeThenContainReturnsTrueWhenProvidedValueIsBetweenBoundariesOfTheRange()
        {
            var range = new Range(5, true, 10, true);
            Assert.IsTrue(range.Contains(7));
        }

        //4th iteration
        [Test]
        public void GivenARangeThenContainReturnsTrueWhenProvidedValueIsThelowerIncludedBoundaryOfTheRange()
        {
            var range = new Range(5, true, 10, true);
            Assert.IsTrue(range.Contains(5));
        }

        //5th iteration
        [Test]
        public void GivenARangeThenContainReturnsTrueWhenProvidedValueIsTheUpperIncludedBoundaryOfTheRange()
        {
            var range = new Range(5, true, 10, true);
            Assert.IsTrue(range.Contains(10));
        }

        //6th iteration
        [Test]
        public void GivenARangeThenContainReturnsFalseWhenProvidedValueIsTheLowerNotIncludedBoundaryOfTheRange()
        {
            var range = new Range(5, false, 10, true);
            Assert.IsFalse(range.Contains(5));
        }

        //7th iteration
        [Test]
        public void GivenARangeThenContainReturnsFalseWhenProvidedValueIsTheUpperNotIncludedBoundaryOfTheRange()
        {
            var range = new Range(5, true, 10, false);
            Assert.IsFalse(range.Contains(10));
        }

        //8th iteration
        [Test]
        public void GivenARangeThenResultsOfGetAllPointsContainsLowerIncludedBoundary()
        {
            var range = new Range(5, true, 10, true);
            Assert.IsTrue(range.GetAllPoints().Contains(5));
        }

        //9th iteration
        [Test]
        public void GivenARangeThenResultsOfGetAllPointsContainsUpperIncludedBoundary()
        {
            var range = new Range(5, true, 10, true);
            Assert.IsTrue(range.GetAllPoints().Contains(10));
        }

        //10th iteration
        [Test]
        public void GivenARangeThenResultsOfGetAllPointsDoesntContainLowerNotIncludedBoundary()
        {
            var range = new Range(5, false, 10, true);
            Assert.IsFalse(range.GetAllPoints().Contains(5));
        }

        //11th iteration
        [Test]
        public void GivenARangeThenResultsOfGetAllPointsDoesntContainUpperNotIncludedBoundary()
        {
            var range = new Range(5, true, 10, false);
            Assert.IsFalse(range.GetAllPoints().Contains(10));
        }

        //12th iteration
        [Test]
        public void GivenARangeThenResultsOfGetAllPointsContainsValuesBetweenTheBoundaries()
        {
            var range = new Range(5, true, 10, false);
            Assert.IsTrue(range.GetAllPoints().Contains(6));
            Assert.IsTrue(range.GetAllPoints().Contains(7));
            Assert.IsTrue(range.GetAllPoints().Contains(8));
            Assert.IsTrue(range.GetAllPoints().Contains(9));
        }
        
        //13rd iteration
        [Test]
        public void GivenARangeContainsRangeReturnsFalseIfLowerValueOfProvidedRangeIsNotContainedInTheReferenceRange()
        {
            var range = new Range(5, true, 10, false);
            Assert.IsFalse(range.ContainsRange(new Range(10,true,15,true)));
        }

        //14th iteration
        [Test]
        public void GivenARangeContainsRangeReturnsFalseIfUpperValueOfProvidedRangeIsNotContainedInTheReferenceRange()
        {
            var range = new Range(5, true, 10, false);
            Assert.IsFalse(range.ContainsRange(new Range(10, true, 15, true)));
        }

        //15th iteration
        [Test]
        public void GivenARangeEndPointsReturnsTheLowerAndTheUpperValues()
        {
            var range = new Range(5, false, 10, false);
            Assert.AreEqual(2, range.EndPoints().Length);
            Assert.AreEqual(6, range.EndPoints()[0]);
            Assert.AreEqual(9, range.EndPoints()[1]);
        }
        
        //16th iteration
        [Test]
        public void GivenARangeOverlapsRangeReturnsTrueIfEitherTheLowerValueOrTheUpperValueOfTheProvidedRangeIsContainedInTheReferenceRange()
        {
            var range = new Range(5, true, 10, false);
            Assert.IsTrue(range.OverlapsRange(new Range(8, true, 15, true)));
            Assert.IsTrue(range.OverlapsRange(new Range(2, true, 7, true)));
        }

        //17th iteration
        [Test]
        public void GivenARangeEqualsReturnsTrueIfUpperAndLowerValuesAreEqualsToTheUpperAndLowerValuesOfTheReferenceRange()
        {
            var range = new Range(5, true, 10, false);
            Assert.IsTrue(range.Equals(new Range(5, true, 10, false)));
        }
        
        [Test]
        public void UserAcceptanceTests()
        {
            // Contains
            // [2,6) contains {2,4}
            // [2,6) doesn’t contain {-1,1,6,10}
            var range = new Range(2, true, 6, false);
            Assert.IsTrue(range.Contains(2));
            Assert.IsTrue(range.Contains(4));
            Assert.IsFalse(range.Contains(-1));
            Assert.IsFalse(range.Contains(1));
            Assert.IsFalse(range.Contains(6));
            Assert.IsFalse(range.Contains(10));

            //getAllPoints
            //[2, 6) allPoints = { 2,3,4,5}
            var allPoints = range.GetAllPoints();
            Assert.IsTrue(allPoints.Contains(2));
            Assert.IsTrue(allPoints.Contains(3));
            Assert.IsTrue(allPoints.Contains(4));
            Assert.IsTrue(allPoints.Contains(5));

            //ContainsRange
            //[2, 5) doesn’t contain[7, 10)
            //[2,5) doesn’t contain [3,10)
            //[3,5) doesn’t contain [2,10)
            //[2,10) contains [3,5]
            //[3,5] contains[3, 5)
            Assert.IsFalse(new Range(2, true, 5, false).ContainsRange(new Range(7, true, 10, false)));
            Assert.IsFalse(new Range(2, true, 5, false).ContainsRange(new Range(3, true, 10, false)));
            Assert.IsFalse(new Range(3, true, 5, false).ContainsRange(new Range(2, true, 10, false)));
            Assert.IsTrue(new Range(2, true, 10, false).ContainsRange(new Range(3, true, 5, true)));
            Assert.IsTrue(new Range(3, true, 5, true).ContainsRange(new Range(3, true, 5, false)));

            //endPoints
            //[2, 6) endPoints = { 2,5}
            //[2,6] endPoints = { 2,6}
            //(2, 6) endPoints = { 3,5}
            //(2, 6] endPoints = { 3,6}
            Assert.AreEqual(new int[] { 2, 5 }, new Range(2, true, 6, false).EndPoints());
            Assert.AreEqual(new int[] { 2, 6 }, new Range(2, true, 6, true).EndPoints());
            Assert.AreEqual(new int[] { 3, 5 }, new Range(2, false, 6, false).EndPoints());
            Assert.AreEqual(new int[] { 3, 6 }, new Range(2, false, 6, true).EndPoints());

            //overlapsRange
            //[2, 5) doesn’t overlap with [7,10)
            //[2,10) overlaps with [3,5)
            //[3,5) overlaps with [3,5)
            //[2,5) overlaps with [3,10)
            //[3,5) overlaps with [2,10)
            Assert.IsFalse(new Range(2, true, 5, false).OverlapsRange(new Range(7, true, 10, false)));
            Assert.IsTrue(new Range(2, true, 10, false).OverlapsRange(new Range(3, true, 5, false)));
            Assert.IsTrue(new Range(3, true, 5, false).OverlapsRange(new Range(3, true, 5, false)));
            Assert.IsTrue(new Range(2, true, 5, false).OverlapsRange(new Range(3, true, 10, false)));
            Assert.IsTrue(new Range(3, true, 5, false).OverlapsRange(new Range(2, true, 10, false)));
            
            //Equals
            //[3,5) equals [3,5)
            //[2,10) neq [3,5)
            //[2,5) neq [3,10)
            //[3,5) neq [2,10)
            Assert.IsTrue(new Range(3, true, 5, false).Equals(new Range(3, true, 5, false)) );
            Assert.IsFalse(new Range(2, true, 10, false).Equals(new Range(3, true, 5, false)));
            Assert.IsFalse(new Range(2, true, 5, false).Equals(new Range(3, true, 10, false)));
            Assert.IsFalse(new Range(3, true, 5, false).Equals(new Range(2, true, 10, false)));
        }

    }
}
