using System;

namespace RPNCalculator
{
    static class RPNCalculatorFactory
    {
        public enum RPNCalculatorMethod
        {
            Undefined,
            Recursive,
            Iterative
        }

        public static IRPNCalculator Create(RPNCalculatorMethod method)
        {
            switch (method)
            {
                case RPNCalculatorMethod.Recursive:
                    return new RecursiveRPNCalculator();
                    break;
                case RPNCalculatorMethod.Iterative:
                    return new IterativeRPNCalculator();
                    break;
            }
            throw new ArgumentException("Unsupported method");
        }
    }
}
