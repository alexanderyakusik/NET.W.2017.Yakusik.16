using System;
using System.Collections.Generic;
using Task.Loggers;
using Task.Parsers.SourceProviders;

namespace Task.Parsers
{
    /// <summary>
    /// URI parsing utility.
    /// </summary>
    public class UriParser
    {
        #region Private fields

        private static ILogger logger;

        #endregion

        #region Static methods

        /// <summary>
        /// Sets the current logger of the class.
        /// </summary>
        /// <param name="logger">Logger to use.</param>
        public static void SetLogger(ILogger logger)
        {
            UriParser.logger = logger;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Parses the string <paramref name="uri"/> to URI object. Also logs the parsing error.
        /// </summary>
        /// <param name="uri">String to parse.</param>
        /// <returns>URI object if the parsing was successfull. Otherwise, returns null.</returns>
        public Uri Parse(string uri)
        {
            try
            {
                var result = new Uri(uri);

                return result;
            }
            catch (UriFormatException)
            {
                logger?.Error($"Unable to parse string '{uri}'. Invalid format.");
                return null;
            }
        }

        /// <summary>
        /// Parses the strings taken from the <paramref name="provider"/> to URI objects.
        /// </summary>
        /// <param name="provider">Source provider.</param>
        /// <returns>Enumeration of URIs.</returns>
        public IEnumerable<Uri> ParseSource(ISourceProvider provider)
        {
            var resultList = new List<Uri>();

            foreach (var item in provider.GetSource())
            {
                Uri uri = Parse(item);

                if (uri == null)
                {
                    continue;
                }

                resultList.Add(uri);
            }

            return resultList;
        }

        #endregion
    }
}
