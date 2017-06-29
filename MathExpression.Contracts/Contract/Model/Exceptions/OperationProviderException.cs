using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpression.Contracts.Model.Exceptions
{
    public class OperationProviderException : Exception
    {
        public OperationProviderException(string message) : base(message)
        {
        }
    }
}
