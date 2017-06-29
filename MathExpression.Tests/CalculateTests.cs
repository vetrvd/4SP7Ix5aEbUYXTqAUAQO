using Moq;
using System;
using MathExpression.Contracts.Model;
using MathExpression.Contracts.Contract;
using MathExpression.Contracts.Service;
using MathExpression.Contracts.Service.Operation;
using Xunit;

namespace MathExpression.Tests
{
    public class CalculateTests
    {
        private readonly ICalculate _calculate = null;
        private readonly ILogger<SumOperator> _loggerOperation = null;
        public CalculateTests()
        {
            var moq = new Mock<ILogger<Calculate>>();
            _loggerOperation = new Mock<ILogger<SumOperator>>().Object;
            _calculate = new Calculate(moq.Object);
        }

        [Fact]
        public void Calculate_NullParams_ThrowExpection()
        {
            Assert.Throws<Exception>(() => _calculate.Calculate(null));
        }

        [Fact]
        public void Calculate_Emptry_CorrectWork()
        {
            Assert.Equal(3,
                _calculate.Calculate(new Expression(new SumOperator(_loggerOperation), new [] { new Expression(1), new Expression(2)})));
        }
    }
}
