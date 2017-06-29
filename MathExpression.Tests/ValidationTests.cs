using MathExpression.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using MathExpression.Contracts.Contract;
using MathExpression.Contracts.Model.Exceptions;
using MathExpression.Contracts;

namespace MathExpression.Tests
{
    public class ValidationTests
    {
        private IValidator validator = null;

        public ValidationTests()
        {
            var moqLog = new Mock<ILogger<Validator>>();

            var moqOperationProvider = new Mock<IOperationProvider>();
            moqOperationProvider.Setup(it => it.GetSeparators()).Returns(new[] { '*', '/', '-', '+' });

            validator = new Validator(moqLog.Object, moqOperationProvider.Object);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void ValidateInput_EmptyParams_ThrowException(string input)
        {
            Assert.Throws<ArgumentNullException>(() => validator.ValidateInput(input));
        }

        [Theory]
        [InlineData("$#@")]
        [InlineData("13,2")]
        [InlineData("//")]
        [InlineData("**")]
        [InlineData("+-1")]
        [InlineData("+     -1")]
        [InlineData("+1")]
        [InlineData("1+111111111111111111111111111111111111111111111111111111111111111")]
        public void ValidateInput_BadString_ThrowException(string input)
        {
            Assert.Throws<ValidateException>(() => validator.ValidateInput(input));
        }

        [Theory]
        [InlineData("1+1")]
        [InlineData("1")]
        [InlineData("1 * 1")]
        [InlineData("1 / 1")]
        [InlineData("1 / 1 + 1")]
        public void ValidateInput_CorrectString_CorrectWork(string input)
        {
            validator.ValidateInput(input);
        }
    }
}
