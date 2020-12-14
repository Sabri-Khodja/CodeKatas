using System.Collections.Generic;

namespace RPNCalculator
{
    abstract class BaseRPNCalculator : IRPNCalculator
    {
        protected const string SumSymbol = "+";
        protected const string SubstractSymbol = "-";
        protected const string MultiplySymbol = "*";
        protected const string DivideSymbol = "/";
        protected const string SqrtSymbol = "SQRT";
        protected const string MaxSymbol = "MAX";

        protected Stack<double> _stack = new Stack<double>();

        public double Pop()
        {
            return _stack.Pop();
        }

        public abstract bool Evaluate(string s);
    }
}
