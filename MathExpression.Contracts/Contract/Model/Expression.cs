using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpression.Contracts.Model
{
    public class Expression
    {
        public IOperation Operation { get; }
        public Expression Left { get; }
        public Expression Right { get; }

        public double Value { get; }

        public Expression(double value)
        {
            Value = value;
        }

        public Expression(
            IOperation operation, 
            Expression left,
            Expression right)
        {
            this.Left = left;
            this.Right = right;
            this.Operation = operation;
        }
    }
}
