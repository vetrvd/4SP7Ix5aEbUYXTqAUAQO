using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace MathExpression.Contracts.Service
{
    public class Logger<T> : ILogger<T>
        where T: class
    {
        private Logger _logger; 
        public Logger()
        {
            _logger = LogManager.GetLogger(typeof(T).FullName);
        }

        void ILogger<T>.Alert(string message, Exception ex)
        {
            _logger.Fatal(ex, message);
        }

        void ILogger<T>.Info(string message, Exception ex)
        {
            _logger.Info(ex, message);
        }

        void ILogger<T>.Trace(string message, Exception ex)
        {
            _logger.Trace(ex, message);
        }

        void ILogger<T>.Warning(string message, Exception ex)
        {
            _logger.Warn(ex, message);
        }
    }
}
