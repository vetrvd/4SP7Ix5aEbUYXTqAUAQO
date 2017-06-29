using MathExpression.Contracts.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using MathExpression.Contracts.Model;

namespace MathExpression.Contracts.Service
{
    public class Calculate: ICalculate
    {
        private readonly ILogger<Calculate> _logger = null;
        public Calculate(ILogger<Calculate> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        double ICalculate.Calculate(Expression expression)
        {
            return _Calculate(expression);
        }

        private double _Calculate(Expression expression)
        {
            if (expression?.Operation == null)
            {
                return expression?.Value ?? throw new Exception("Expect value");
            }
            else
            {
                return expression.Operation.Calculate(
                    _Calculate(expression.Left),
                    _Calculate(expression.Right));
            }
        }
    }
}
