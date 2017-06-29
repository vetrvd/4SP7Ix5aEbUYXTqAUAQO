using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpression.Contracts.Model.Exceptions
{
    public class ValidateException : Exception
    {
        public ValidateException(string message) : base(message)
        {
        }
    }
}
