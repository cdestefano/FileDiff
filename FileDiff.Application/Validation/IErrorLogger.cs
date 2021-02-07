using System;

namespace FileDiff.Application.Validation
{
    /// <summary>
    /// A simple logging class.
    /// </summary>
    public interface IErrorLogger
    {
        /// <summary>
        /// Logs the given error from a string.
        /// </summary>
        /// <param name="error">The error message.</param>
        void LogError(string error);

        /// <summary>
        /// Logs the given error from an actual exception.
        /// </summary>
        /// <param name="exception">The exception that was thrown.</param>
        void LogError(Exception exception);
    }
}