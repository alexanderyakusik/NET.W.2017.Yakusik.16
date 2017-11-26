using NLog;

namespace Task.Example
{
    /// <summary>
    /// NUnit logger adapter class for ILogger interface.
    /// </summary>
    public class NLogAdapter : Loggers.ILogger
    {
        #region Private fields

        private readonly Logger logger;

        #endregion

        #region Ctors

        /// <summary>
        /// Instaniates a new adapter with NUnit logger with name equal to <paramref name="className"/>.
        /// </summary>
        /// <param name="className">Name to be used in logger.</param>
        public NLogAdapter(string className)
        {
            this.logger = LogManager.GetLogger(className);
        }

        #endregion

        #region Interfaces implementations

        #region ILogger

        /// <inheritdoc />
        public void Info(string message)
        {
            this.logger.Info(message);
        }

        /// <inheritdoc />
        public void Error(string message)
        {
            this.logger.Error(message);
        }

        #endregion

        #endregion
    }
}
