using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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


    interface IRPNCalculator
    {
        bool Evaluate(string s);
        double Pop();
    }

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

    class RecursiveRPNCalculator : BaseRPNCalculator
    {

        public override bool Evaluate(string s)
        {
            _stack.Clear();
            var tokens = s.Split(' ', StringSplitOptions.None);
            return Evaluate(new LinkedList<string>(tokens.Reverse())) == EvaluationStatusEnum.Completed;
        }

        enum EvaluationStatusEnum
        {
            Undefined,
            PartiallyCompleted,
            Completed,
            Failed
        }

        private EvaluationStatusEnum Evaluate(LinkedList<string> tokens, bool stopOnNewOperation = false)
        {
            if (tokens.Count == 0)
            {
                return EvaluationStatusEnum.Completed;
            }

            EvaluationStatusEnum status;

            if (double.TryParse(tokens.First?.Value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double value))
            {
                tokens.RemoveFirst();
                status = Evaluate(tokens, stopOnNewOperation);
                if (status != EvaluationStatusEnum.Failed)
                {
                    _stack.Push(value);
                    return status;
                }
                return EvaluationStatusEnum.Failed;
            }
            else
            {
                if (stopOnNewOperation)
                {
                    return EvaluationStatusEnum.PartiallyCompleted;
                }
                
                switch (tokens.First?.Value)
                {
                    case SumSymbol:
                        tokens.RemoveFirst();
                        status = Evaluate(tokens);
                        if (status != EvaluationStatusEnum.Failed && _stack.Count > 1)
                        {
                            _stack.Push(_stack.Pop() + _stack.Pop());
                            return status;
                        }
                        break;
                    case SubstractSymbol:
                        tokens.RemoveFirst();
                        status = Evaluate(tokens);
                        if (status != EvaluationStatusEnum.Failed && _stack.Count > 1)
                        {
                            var val1 = _stack.Pop();
                            var val2 = _stack.Pop();
                            _stack.Push(val2 - val1);
                            return status;
                        }
                        break;
                    case MultiplySymbol:
                        tokens.RemoveFirst();
                        status = Evaluate(tokens);
                        if (status != EvaluationStatusEnum.Failed && _stack.Count > 1)
                        {
                            _stack.Push(_stack.Pop() * _stack.Pop());
                            return status;
                        }
                        break;
                    case DivideSymbol:
                        tokens.RemoveFirst();
                        status = Evaluate(tokens);
                        if (status != EvaluationStatusEnum.Failed && _stack.Count > 1)
                        {
                            var val1 = _stack.Pop();
                            var val2 = _stack.Pop();
                            _stack.Push(val2 / val1);
                            return status;
                        }
                        break;
                    case SqrtSymbol:
                        tokens.RemoveFirst();
                        status = Evaluate(tokens);
                        if (status != EvaluationStatusEnum.Failed && _stack.Count > 0)
                        {
                            _stack.Push(Math.Sqrt(_stack.Pop()));
                            return status;
                        }
                        break;
                    case MaxSymbol:
                        tokens.RemoveFirst();
                        status = Evaluate(tokens, true);
                        if (status != EvaluationStatusEnum.Failed && _stack.Count > 1)
                        {
                            double? max = null;
                            while (_stack.Count > 0)
                            {
                                var val = _stack.Pop();
                                if (!max.HasValue || val > max)
                                {
                                    max = val;
                                }
                            }
                            
                            if (status == EvaluationStatusEnum.PartiallyCompleted)
                            {
                                status = Evaluate(tokens);
                            }

                            if (max.HasValue)
                            {
                                _stack.Push(max.Value);
                            }

                            return status;
                        }
                        break;
                }
                return EvaluationStatusEnum.Failed;
            }
        }
        
    }

    class IterativeRPNCalculator : BaseRPNCalculator
    {

        public override bool Evaluate(string s)
        {
            _stack.Clear();
            var tokens = s.Split(' ', StringSplitOptions.None);
            return Evaluate(new LinkedList<string>(tokens));
        }

        private bool Evaluate(LinkedList<string> tokens)
        {
            int lastStackCount = 0;
            while (tokens.Count > 0)
            {
                var token = tokens.First?.Value;
                tokens.RemoveFirst();
                if (double.TryParse(token, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture,
                    out double value))
                {
                    _stack.Push(value);
                }
                else
                {
                    switch (token)
                    {
                        case SumSymbol:
                            if (_stack.Count > 1)
                            {
                                _stack.Push(_stack.Pop() + _stack.Pop());
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        case SubstractSymbol:
                            if (_stack.Count > 1)
                            {
                                var val1 = _stack.Pop();
                                var val2 = _stack.Pop();
                                _stack.Push(val2 - val1);
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        case MultiplySymbol:
                            if (_stack.Count > 1)
                            {
                                _stack.Push(_stack.Pop() * _stack.Pop());
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        case DivideSymbol:
                            if (_stack.Count > 1)
                            {
                                var val1 = _stack.Pop();
                                var val2 = _stack.Pop();
                                _stack.Push(val2 / val1);
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        case SqrtSymbol:
                            if (_stack.Count > 0)
                            {
                                _stack.Push(Math.Sqrt(_stack.Pop()));
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        case MaxSymbol:
                            double? max = null;
                            while (_stack.Count > lastStackCount)
                            {
                                var val = _stack.Pop();
                                if (!max.HasValue || val > max)
                                {
                                    max = val;
                                }
                            }

                            if (max.HasValue)
                            {
                                _stack.Push(max.Value);
                            }

                            lastStackCount = _stack.Count;
                            break;
                        default:
                            return false;
                    }
                }
            }

            return true;
        }

    }


}
