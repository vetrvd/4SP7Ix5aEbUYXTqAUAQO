using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpression.Contracts.Service
{
    public sealed class MultiplicationOperation : IOperation
    {
        private readonly ILogger<MultiplicationOperation> _logger = null;
        public MultiplicationOperation(ILogger<MultiplicationOperation> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        char IOperation.Separator => '*';

        float IOperation.Priority => 2;

        double IOperation.Calculate(double args1, double args2)
        {
            return args1 * args2;
        }
    }
}
