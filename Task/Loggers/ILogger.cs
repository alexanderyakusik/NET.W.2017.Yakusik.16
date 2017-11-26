namespace Task.Loggers
{
    /// <summary>
    /// Interface providing logging utilities.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Write info message to the log.
        /// </summary>
        /// <param name="message">Message to write.</param>
        void Info(string message);

        /// <summary>
        /// Write error message to the log.
        /// </summary>
        /// <param name="message">Message to write.</param>
        void Error(string message);
    }
}
