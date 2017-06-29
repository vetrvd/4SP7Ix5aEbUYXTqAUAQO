using System;
using MathExpression.Contracts.Contract;

namespace MathExpression.Contracts.Service.Operation
{
    public sealed class MinusOperation : IOperation
    {
        private readonly ILogger<MinusOperation> _logger = null;
        public MinusOperation(ILogger<MinusOperation> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        char IOperation.Separator => '-';

        float IOperation.Priority => 1;

        double IOperation.Calculate(double args1, double args2)
        {
            return args1 - args2;
        }
    }
}
