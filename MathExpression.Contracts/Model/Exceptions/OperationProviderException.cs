using System;

namespace MathExpression.Contracts.Model.Exceptions
{
    public class OperationProviderException : Exception
    {
        public OperationProviderException(string message) : base(message)
        {
        }
    }
}
