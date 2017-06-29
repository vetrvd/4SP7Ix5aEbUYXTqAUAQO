using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MathExpression.Contracts.Contract;

namespace MathExpression.Contracts.Model
{
    public class ValueExpression : IExpression
    {
        private readonly double _value;

        public ValueExpression(double value)
        {
            _value = value;
        }

        double IExpression.GetValue()
        {
            return _value;
        }
    }
}
