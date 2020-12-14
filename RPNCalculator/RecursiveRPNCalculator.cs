using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RPNCalculator
{
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
                            double max = _stack.Max();

                            if (status == EvaluationStatusEnum.PartiallyCompleted)
                            {
                                status = Evaluate(tokens);
                            }

                            _stack.Push(max);
                            
                            return status;
                        }
                        break;
                }
                return EvaluationStatusEnum.Failed;
            }
        }
    }
}
