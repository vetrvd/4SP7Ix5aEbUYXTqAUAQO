using System;
using MathExpression.Contracts.Contract;

namespace MathExpression.Contracts.Service.Operation
{
    public sealed class SumOperator : IOperation
    {
        private readonly ILogger<SumOperator> _logger = null;
        public SumOperator(ILogger<SumOperator> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        char IOperation.Separator => '+';

        float IOperation.Priority => 0;

        double IOperation.Calculate(double args1, double args2)
        {
            return args1 + args2;
        }
    }
}
