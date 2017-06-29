using MathExpression.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpression.Contracts.Contract
{
    public interface ICalculate
    {
        double Calculate(Expression expression);
    }
}
