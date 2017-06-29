using System;
using System.Collections.Generic;
using System.Linq;
using MathExpression.Contracts.Contract;

namespace MathExpression.Contracts.Model
{
    public class Expression
    {
        public IOperation Operation { get; }
        public IEnumerable<Expression> Links { get; }
        public double Value { get; }

        public Expression(double value)
        {
            Value = value;
        }

        public Expression(
            IOperation operation, 
            IEnumerable<Expression> links )
        {
            this.Links = links;
            this.Operation = operation;
        }
    }
}
