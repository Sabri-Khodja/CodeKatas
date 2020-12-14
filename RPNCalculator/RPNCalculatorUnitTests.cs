using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace RPNCalculator
{
    [TestFixture]
    public class RPNCalculatorUnitTests
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
        public void SingleValueExpressionEvaluatesAsTheValueWhenUsingRecursiveMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Recursive);
            Assert.IsTrue(calculator.Evaluate("10"));
            Assert.AreEqual(10, calculator.Pop());
        }

        //2nd iteration
        [Test]
        public void SumExpressionEvaluatesAsTheSumOfTwoProvidedValuesWhenUsingRecursiveMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Recursive);
            Assert.IsTrue(calculator.Evaluate("9.6 10.4 +"));
            Assert.AreEqual(20.0, calculator.Pop());
        }
        
        //3rd iteration
        [Test]
        public void SubstractExpressionEvaluatesAsTheSubstractionOfTwoProvidedValuesWhenUsingRecursiveMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Recursive);
            Assert.IsTrue(calculator.Evaluate("9.6 5.6 -"));
            Assert.AreEqual(4.0, calculator.Pop());
        }

        //4th iteration
        [Test]
        public void MultiplyExpressionEvaluatesAsTheMultiplicationOfTwoProvidedValuesWhenUsingRecursiveMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Recursive);
            Assert.IsTrue(calculator.Evaluate("3 3 *"));
            Assert.AreEqual(9, calculator.Pop());
        }

        //5th iteration
        [Test]
        public void DivideExpressionEvaluatesAsTheDivisionOfTwoProvidedValuesWhenUsingRecursiveMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Recursive);
            Assert.IsTrue(calculator.Evaluate("12 4 /"));
            Assert.AreEqual(3.0, calculator.Pop());
        }

        //6th iteration
        [Test]
        public void EvaluateReturnsFalseWhenExpressionIsWrongWhenUsingRecursiveMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Recursive);
            Assert.IsFalse(calculator.Evaluate("4 /"));
        }

        //7th iteration
        [Test]
        public void SqrtExpressionEvaluatesAsTheSqrtOfTheProvidedValueWhenUsingRecursiveMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Recursive);
            Assert.IsTrue(calculator.Evaluate("9 SQRT"));
            Assert.AreEqual(3.0, calculator.Pop());
        }

        //8th iteration
        [Test]
        public void MaxExpressionEvaluatesAsTheMaxOfTheProvidedValuesWhenUsingRecursiveMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Recursive);
            Assert.IsTrue(calculator.Evaluate("5 3 4 2 9 1 MAX"));
            Assert.AreEqual(9, calculator.Pop());
        }
        
        //9th iteration
        [Test]
        public void MaxExpressionsEvaluatesAsTheMaxOfTheProvidedValuesWhenUsingRecursiveMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Recursive);
            Assert.IsTrue(calculator.Evaluate("4 5 MAX 1 2 MAX *"));
            Assert.AreEqual(10, calculator.Pop());
        }

        //10th iteration
        [Test]
        public void ReturnsCorrectResultsOfCombinedOperationsWhenUsingRecursiveMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Recursive);
            Assert.IsTrue(calculator.Evaluate("3 5 8 * 7 + *"));
            Assert.AreEqual(141, calculator.Pop());
        }
        
        //11th iteration
        [Test]
        public void SingleValueExpressionEvaluatesAsTheValueWhenUsingIterativeMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Iterative);
            Assert.IsTrue(calculator.Evaluate("10"));
            Assert.AreEqual(10, calculator.Pop());
        }

        //12th iteration
        [Test]
        public void SumExpressionEvaluatesAsTheSumOfTwoProvidedValuesWhenUsingIterativeMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Iterative);
            Assert.IsTrue(calculator.Evaluate("9.6 10.4 +"));
            Assert.AreEqual(20.0, calculator.Pop());
        }

        //3rd iteration
        [Test]
        public void SubstractExpressionEvaluatesAsTheSubstractionOfTwoProvidedValuesWhenUsingIterativeMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Iterative);
            Assert.IsTrue(calculator.Evaluate("9.6 5.6 -"));
            Assert.AreEqual(4.0, calculator.Pop());
        }

        //4th iteration
        [Test]
        public void MultiplyExpressionEvaluatesAsTheMultiplicationOfTwoProvidedValuesWhenUsingIterativeMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Iterative);
            Assert.IsTrue(calculator.Evaluate("3 3 *"));
            Assert.AreEqual(9, calculator.Pop());
        }

        //5th iteration
        [Test]
        public void DivideExpressionEvaluatesAsTheDivisionOfTwoProvidedValuesWhenUsingIterativeMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Iterative);
            Assert.IsTrue(calculator.Evaluate("12 4 /"));
            Assert.AreEqual(3.0, calculator.Pop());
        }

        //6th iteration
        [Test]
        public void EvaluateReturnsFalseWhenExpressionIsWrongWhenUsingIterativeMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Iterative);
            Assert.IsFalse(calculator.Evaluate("4 /"));
        }

        //7th iteration
        [Test]
        public void SqrtExpressionEvaluatesAsTheSqrtOfTheProvidedValueWhenUsingIterativeMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Iterative);
            Assert.IsTrue(calculator.Evaluate("9 SQRT"));
            Assert.AreEqual(3.0, calculator.Pop());
        }

        //8th iteration
        [Test]
        public void MaxExpressionEvaluatesAsTheMaxOfTheProvidedValuesWhenUsingIterativeMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Iterative);
            Assert.IsTrue(calculator.Evaluate("5 3 4 2 9 1 MAX"));
            Assert.AreEqual(9, calculator.Pop());
        }

        //9th iteration
        [Test]
        public void MaxExpressionsEvaluatesAsTheMaxOfTheProvidedValuesWhenUsingIterativeMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Iterative);
            Assert.IsTrue(calculator.Evaluate("4 5 MAX 1 2 MAX *"));
            Assert.AreEqual(10, calculator.Pop());
        }

        //10th iteration
        [Test]
        public void ReturnsCorrectResultsOfCombinedOperationsWhenUsingIterativeMethodTest()
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Iterative);
            Assert.IsTrue(calculator.Evaluate("3 5 8 * 7 + *"));
            Assert.AreEqual(141, calculator.Pop());
        }
        
    }
}
