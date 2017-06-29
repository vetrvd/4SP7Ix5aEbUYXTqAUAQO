using MathExpression.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpression.Contracts.Contract
{
    public interface IOperationProvider
    {
        void RegisterOperation(IOperation operation);
        IEnumerable<IOperation> GetSortOperation();
        IEnumerable<char> GetSeparators();
    }
}
