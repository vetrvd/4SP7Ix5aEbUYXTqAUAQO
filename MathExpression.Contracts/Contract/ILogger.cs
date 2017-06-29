using System;

namespace MathExpression.Contracts.Contract
{ 
    /// <summary>
    /// Логгер
    /// </summary>
    public interface ILogger<T>
        where T: class
    {
        void Trace(string message, Exception ex = null);
        void Info(string message, Exception ex = null);
        void Warning(string message, Exception ex = null);
        void Alert(string message, Exception ex = null);
    }
}
