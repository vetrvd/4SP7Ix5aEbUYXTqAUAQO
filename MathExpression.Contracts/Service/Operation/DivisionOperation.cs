using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpression.Contracts.Service
{
    public sealed class DivisionOperation : IOperation
    {
        private readonly ILogger<DivisionOperation> _logger = null;
        public DivisionOperation(ILogger<DivisionOperation> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        char IOperation.Separator => '/';

        float IOperation.Priority => 1;

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
