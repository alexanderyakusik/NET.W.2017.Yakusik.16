using System.Collections.Generic;

namespace Task.Parsers.SourceProviders
{
    /// <summary>
    /// Interface providing enumeration of strings.
    /// </summary>
    public interface ISourceProvider
    {
        /// <summary>
        /// Generates an enumeration of strings.
        /// </summary>
        /// <returns>Enumeration of strings.</returns>
        IEnumerable<string> GetSource();
    }
}
