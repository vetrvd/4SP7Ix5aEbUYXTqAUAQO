﻿using MathExpression.Contracts.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpression.Contracts
{
    public class Worker
    {
        readonly ILogger<Worker> _logger = null;
        readonly IValidator _validator = null;
        readonly IBuilderExpression _builder = null;

        public Worker(
            ILogger<Worker> logger,
            IValidator validator,
            IBuilderExpression builder)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public double Work(string input)
        {
            ///костыль, jon skeet не одобряет
            if (input?.Trim()?.StartsWith("-") ?? false)
            {
                input = $"0{input}";
            }

            _validator.ValidateInput(input);
            var expression = _builder.CreateExpression(input);
            return expression.GetValue();
        }
    }
}
