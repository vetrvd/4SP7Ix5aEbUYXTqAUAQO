using System;
using System.Collections.Generic;
using System.Text;
using MathExpression.Contracts.Model;

namespace MathExpression.Contracts.Contract
{
    /// <summary>
    /// Построение дерева разбора, для выполнения операций
    /// </summary>
    public interface IBuilderExpression
    {
        IExpression CreateExpression(string input);
    }
}
