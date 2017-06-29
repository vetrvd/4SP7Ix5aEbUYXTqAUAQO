using System;
using MathExpression.Contracts.Contract;

namespace MathExpression.Contracts.Service.Operation
{
    public sealed class DivisionOperation : IOperation
    {
        private readonly ILogger<DivisionOperation> _logger = null;
        public DivisionOperation(ILogger<DivisionOperation> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        char IOperation.Separator => '/';

        float IOperation.Priority => 2;

        double IOperation.Calculate(double args1, double args2)
        {
            if (args2 == 0)
            {
                throw new Exception("Division by zero");
            }
            return args1 / args2;
        }
    }
}
