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

        IExpression IBuilderExpression.CreateExpression(string input)
        {
            var operations = _operationProvider.GetSortOperation().ToArray();
            return _CreateExpression(input, operations);
        }

        private IExpression _CreateExpression(string input, IEnumerable<IOperation> operations)
        {
            var op = operations.FirstOrDefault(it => input.Contains(it.Separator));
            if (op == null)
            {
                return new ValueExpression(double.Parse(input));
            }

            return new OperationExpression(op,
                input.Split(op.Separator).Select(at => _CreateExpression(at.Trim(), operations)));
        }
    }
}
