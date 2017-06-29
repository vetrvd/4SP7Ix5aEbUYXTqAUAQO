using System;
using MathExpression.Contracts.Contract;

namespace MathExpression.Contracts.Service.Operation
{
    public sealed class MultiplicationOperation : IOperation
    {
        private readonly ILogger<MultiplicationOperation> _logger = null;
        public MultiplicationOperation(ILogger<MultiplicationOperation> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        char IOperation.Separator => '*';

        float IOperation.Priority => 3;

        double IOperation.Calculate(double args1, double args2)
        {
            return args1 * args2;
        }
    }
}
