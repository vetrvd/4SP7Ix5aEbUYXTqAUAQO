using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpression.Contracts
{
    /// <summary>
    /// Валидация входного выражения
    /// </summary>
    public interface IValidator
    {
        void ValidateInput(string input);
    }
}
