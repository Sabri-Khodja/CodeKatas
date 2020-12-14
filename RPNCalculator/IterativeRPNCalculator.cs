using System;
using System.Collections.Generic;
using System.Globalization;

namespace RPNCalculator
{
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
