using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MathExpression.Contracts.Contract;

namespace MathExpression.Contracts.Model
{
    public class OperationExpression : IExpression
    {
        private readonly IOperation _operation = null;
        private readonly IEnumerable<IExpression> _links = null;

        public OperationExpression(
            IOperation operation,
            IEnumerable<IExpression> links)
        {
            this._links = links ?? throw new ArgumentNullException(nameof(links));
            this._operation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        double IExpression.GetValue()
        {
            var items = _links.Select(it => it.GetValue()).ToList();
            var result = items.First();
            foreach (var it in items.GetRange(1, items.Count - 1))
            {
                result = _operation.Calculate(result, it);
            }

            return result;
        }
    }
}
