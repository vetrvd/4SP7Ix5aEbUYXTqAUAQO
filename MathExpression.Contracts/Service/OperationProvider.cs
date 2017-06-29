using MathExpression.Contracts.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using MathExpression.Contracts.Model;
using MathExpression.Contracts.Model.Exceptions;
using System.Linq;

namespace MathExpression.Contracts.Service
{
    public sealed class OperationProvider :
        IOperationProvider
    {
        private readonly ILogger<OperationProvider> _logger = null;
        private readonly Dictionary<char, IOperation> _operations = new Dictionary<char, IOperation>();
        public OperationProvider(
            ILogger<OperationProvider> logger,
            IEnumerable<IOperation> operations)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            foreach (var op in operations?? new IOperation[] { })
                ((IOperationProvider)this).RegisterOperation(op);
        }

        IEnumerable<char> IOperationProvider.GetSeparators()
        {
            return _operations.Keys;
        }

        void IOperationProvider.RegisterOperation(IOperation operation)
        {
            if (_operations.ContainsKey(operation.Separator))
            {
                throw new OperationProviderException($"Separator = '{operation.Separator}' is already registered");
            }

            _operations.Add(operation.Separator, operation);
        }

        IEnumerable<IOperation> IOperationProvider.GetSortOperation()
        {
            return _operations.Values.OrderBy(it => it.Priority);
        }
    }
}
