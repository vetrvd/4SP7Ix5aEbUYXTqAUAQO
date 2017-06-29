using MathExpression.Contracts.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                var items = expression.Links.Select(it => _Calculate(it)).ToList();
                var result = items.First();
                foreach (var it  in items.GetRange(1, items.Count - 1))
                {
                    result = expression.Operation.Calculate(result, it);
                }

                return result;
            }
        }
    }
}
