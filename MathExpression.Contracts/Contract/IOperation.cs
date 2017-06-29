using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpression.Contracts
{
    public interface IOperation
    {
        char Separator { get; }
        float Priority { get; }
        double Calculate(double args1, double args2);
    }
}
