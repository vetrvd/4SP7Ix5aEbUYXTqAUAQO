using MathExpression.Contracts.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MathExpression.Contracts.Model;

namespace MathExpression.Contracts.Service
{
    public class BuilderExpression : IBuilderExpression
    {
        private readonly ILogger<BuilderExpression> _logger;
        private readonly IOperationProvider _operationProvider;

        public BuilderExpression(
            ILogger<BuilderExpression> logger,
            IOperationProvider operationProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _operationProvider = operationProvider ?? throw new ArgumentNullException(nameof(operationProvider));
        }

        Expression IBuilderExpression.CreateExpression(string input)
        {
            var operations = _operationProvider.GetSortOperation().ToArray();
            return _CreateExpression(input, operations);
        }

        private Expression _CreateExpression(string input, IEnumerable<IOperation> operations)
        {
            var op = operations.FirstOrDefault(it => input.IndexOf(it.Separator) != -1);
            if (op == null)
            {
                return new Expression(double.Parse(input));
            }

            var index = input.IndexOf(op.Separator);

            return new Expression(op,
                _CreateExpression(input.Substring(0, index).Trim(), operations), 
                _CreateExpression(input.Substring(index + 1, input.Length - index - 1).Trim(), operations));
        }
    }
}
