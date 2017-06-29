using MathExpression.Contracts.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathExpression.Contracts.Model.Exceptions;

namespace MathExpression.Contracts.Service
{
    public class Validator : IValidator
    {
        private readonly ILogger<Validator> _logger = null;
        private readonly IOperationProvider _operationProvider = null;

        public Validator(
            ILogger<Validator> logger,
            IOperationProvider operationProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _operationProvider = operationProvider ?? throw new ArgumentNullException(nameof(operationProvider));
        }

        void IValidator.ValidateInput(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException("Empty input string");
            }

            var chars = _operationProvider.GetSeparators();

            var unsupportedChars = input.Where(it =>
                !Char.IsDigit(it) && !chars.Contains(it) && it != '.' && it != ' ').Select(it => it.ToString()).ToArray();
            if (unsupportedChars.Any())
            {
                throw new ValidateException($"Input string contains unsupported char = '{String.Join(",", unsupportedChars)}'");
            }

            var items = input.Split(chars.ToArray());
            if (items.Any(it => String.IsNullOrWhiteSpace(it)))
            {
                throw new ValidateException($"Empty parameters on expression");
            }
            if (items.Any(it => it.Length > 20))
            {
                throw new ValidateException($"To long parameters");
            }
        }
    }
}
