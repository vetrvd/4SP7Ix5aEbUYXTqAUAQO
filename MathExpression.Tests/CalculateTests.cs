using MathExpression.Contracts;
using MathExpression.Contracts.Contract;
using MathExpression.Contracts.Model;
using MathExpression.Contracts.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MathExpression.Tests
{
    public class CalculateTests
    {
        private readonly ICalculate calculate = null;
        private readonly ILogger<SumOperator> _loggerOperation = null;
        public CalculateTests()
        {
            var moq = new Mock<ILogger<Calculate>>();
            _loggerOperation = new Mock<ILogger<SumOperator>>().Object;
            calculate = new Calculate(moq.Object);
        }

        [Fact]
        public void Calculate_NullParams_ThrowExpection()
        {
            Assert.Throws<Exception>(() => calculate.Calculate(null));
        }

        [Fact]
        public void Calculate_Emptry_CorrectWork()
        {
            Assert.Equal(2,
                calculate.Calculate(new Expression(new SumOperator(_loggerOperation), new Expression(1), new Expression(2))));
        }
    }
}
