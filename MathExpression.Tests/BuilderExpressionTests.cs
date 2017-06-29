using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Moq;
using MathExpression.Contracts.Service;
using MathExpression.Contracts;
using MathExpression.Contracts.Contract;

namespace MathExpression.Tests
{
    public class BuilderExpressionTest
    {
        private readonly IBuilderExpression builder = null;

        public BuilderExpressionTest()
        {
            var moqLog = new Mock<ILogger<BuilderExpression>>();
            var moqOperationProvider = new Mock<IOperationProvider>();
            var moqOperation = new Mock<IOperation>();
            moqOperation.Setup(it => it.Priority).Returns(0);
            moqOperation.Setup(it => it.Separator).Returns('+');
            moqOperationProvider.Setup(it => it.GetSeparators()).Returns(new[] { '*', '/', '-', '+' });
            moqOperationProvider.Setup(it => it.GetSortOperation()).Returns(new[] { moqOperation.Object });

            builder = new BuilderExpression(moqLog.Object, moqOperationProvider.Object);
        }

        [Fact]
        public void CreateExpression_EmptyWork_Create()
        {
            var result = builder.CreateExpression("1");
            Assert.Null(result.Links);
            Assert.Null(result.Operation);
            Assert.Equal(1.0, result.Value);
        }

        [Fact]
        public void CreateExpression_EmptyWork_Create2()
        {
            var result = builder.CreateExpression("1 + 1");
            Assert.NotNull(result.Links);
            Assert.Equal(2, result.Links.Count());
            Assert.NotNull(result.Operation);
        }

        [Fact]
        public void CreateExpression_EmptyWork_Create3()
        {
            var result = builder.CreateExpression("1 + 1 + 1 + 1.2 + 1 + 1");
            Assert.NotNull(result.Links);
            Assert.Equal(6, result.Links.Count());
            Assert.NotNull(result.Operation);
        }
    }
}
