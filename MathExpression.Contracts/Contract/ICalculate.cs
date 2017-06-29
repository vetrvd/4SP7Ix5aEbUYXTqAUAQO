using System;
using System.Collections.Generic;
using System.Text;
using MathExpression.Contracts.Model;

namespace MathExpression.Contracts.Contract
{
    /// <summary>
    /// Вычисление дерева разбора
    /// </summary>
    public interface ICalculate
    {
        double Calculate(Expression expression);
    }
}
