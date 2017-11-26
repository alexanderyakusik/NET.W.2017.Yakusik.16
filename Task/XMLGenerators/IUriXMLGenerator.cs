using System;
using System.Collections.Generic;

namespace Task.XMLGenerators
{
    /// <summary>
    /// Interface providing XML documents generation by specified enumeration of URIs.
    /// </summary>
    public interface IUriXmlGenerator
    {
        /// <summary>
        /// Generates an XML document using the <paramref name="uris"/>.
        /// </summary>
        /// <param name="uris">Enumeration of URIs to be used.</param>
        /// <returns>XML document written in the string.</returns>
        string GenerateXml(IEnumerable<Uri> uris);
    }
}
