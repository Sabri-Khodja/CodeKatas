using System;

namespace RPNCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            IRPNCalculator calculator = RPNCalculatorFactory.Create(RPNCalculatorFactory.RPNCalculatorMethod.Iterative);
            Console.WriteLine(calculator.Evaluate("3 5 8 * 7 + *"));
        }
    }
}
