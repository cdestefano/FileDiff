using System;

namespace FileDiff.Application.Validation
{
    /// <summary>
    /// I'm not adding a logging class. If you want a real logger, import and implement <see cref="IErrorLogger" />.
    /// </summary>
    public class ErrorLogger : IErrorLogger
    {
        /// <inheritdoc cref="IErrorLogger.LogError(string)" />
        public void LogError(string error)
        {
            Console.WriteLine(error);
        }

        /// <inheritdoc cref="IErrorLogger.LogError(Exception)" />
        public void LogError(Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
}