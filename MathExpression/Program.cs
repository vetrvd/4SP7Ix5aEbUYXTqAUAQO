using MathExpression.Contracts;
using MathExpression.Contracts.Contract;
using MathExpression.Contracts.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using MathExpression.Contracts.Service.Operation;

namespace MathExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            serviceCollection.AddSingleton<IValidator, Validator>();
            serviceCollection.AddTransient<IOperation, SumOperator>();
            serviceCollection.AddTransient<IOperation, MinusOperation>();
            serviceCollection.AddTransient<IOperation, MultiplicationOperation>();
            serviceCollection.AddTransient<IOperation, DivisionOperation>();
            serviceCollection.AddSingleton<IOperationProvider>(it =>
                new OperationProvider(
                    it.GetService<ILogger<OperationProvider>>(),
                    it.GetServices<IOperation>())
            );
            serviceCollection.AddSingleton<IBuilderExpression, BuilderExpression>();
            serviceCollection.AddTransient<Worker>();


            IServiceProvider provider = serviceCollection.BuildServiceProvider();
            var worker = provider.GetService<Worker>();

            Console.WriteLine("Input expression");
            var input = Console.ReadLine();

            try
            {
                Console.WriteLine($"result = {worker.Work(input)}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}