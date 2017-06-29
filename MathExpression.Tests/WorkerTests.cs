using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Xunit;
using Moq;
using MathExpression.Contracts.Contract;
using MathExpression.Contracts.Model.Exceptions;
using MathExpression.Contracts;
using MathExpression.Contracts.Service;
using MathExpression.Contracts.Service.Operation;

namespace MathExpression.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkerTests
    {
        private readonly Worker _worker = null;

        public WorkerTests()
        {
            var operationProvider = new OperationProvider(
                        new Logger<OperationProvider>(),
                        new IOperation[]
                        {
                            new DivisionOperation(new Logger<DivisionOperation>()),
                            new SumOperator(new Logger<SumOperator>()),
                            new MultiplicationOperation(new Logger<MultiplicationOperation>()),
                            new MinusOperation(new Logger<MinusOperation>())
                        });

            _worker = new Worker(
                new Logger<Worker>(), 
                new Validator(
                    new Logger<Validator>(),
                    operationProvider),
                new BuilderExpression(new Logger<BuilderExpression>(), operationProvider));
        }

        [Theory]
        [InlineData("1 + 1", 2)]
        [InlineData("23*2 + 45 - 24/5", 86.2)]
        [InlineData("1 - 2*3 - 1", -6)]
        public void IntegrationTest_CalculateExpression(string input, double result)
        {
            Assert.Equal(result, _worker.Work(input));
        }
    }
}
