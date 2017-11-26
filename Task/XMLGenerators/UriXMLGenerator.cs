using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Task.XMLGenerators
{
    /// <summary>
    /// Generates an XML document using the enumeration of URIs in specified way.
    /// </summary>
    public class UriXmlGenerator : IUriXmlGenerator
    {
        #region Interfaces implementations

        #region IUriXmlGenerator

        /// <inheritdoc />
        public string GenerateXml(IEnumerable<Uri> uris)
        {
            XDocument document = new XDocument(
                new XDeclaration("1.0", "utf-16", null),
                new XElement(
                    "urlAddresses",
                    uris.Select(uri =>
                        new XElement(
                            "urlAddress",
                            new XElement("host", new XAttribute("name", uri.Host)),
                            new XElement(
                                "uri",
                                GetTrimmedSegments(uri.Segments).Select(segment =>
                                    new XElement("segment", segment))),
                            new XElement(
                                "parameters",
                                ParseQueryString(uri.Query).Select(pair =>
                                    new XElement(
                                        "parameter",
                                        new XAttribute("value", pair.Value),
                                        new XAttribute("key", pair.Key))))))));

            document.Descendants().Where(element => element.Name == "parameters" && !element.HasElements).Remove();

            var stringBuilder = new StringBuilder();
            var stringWriter = new StringWriter(stringBuilder);

            document.Save(stringWriter);

            return stringBuilder.ToString();
        }

        #endregion

        #endregion

        #region Private methods

        private static Dictionary<string, string> ParseQueryString(string queryString)
        {
            var result = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(queryString))
            {
                return result;
            }

            var query = from parameter in queryString.Substring(1).Split('&')
                let splittedParameter = parameter.Split('=')
                select new { key = splittedParameter[0], value = splittedParameter[1] };

            foreach (var item in query)
            {
                result.Add(item.key, item.value);
            }

            return result;
        }

        private static IEnumerable<string> GetTrimmedSegments(string[] segments)
        {
            foreach (var segment in segments)
            {
                string trimmedSegment = segment;

                if (segment.EndsWith("/"))
                {
                    trimmedSegment = segment.Substring(0, segment.Length - 1);
                }

                if (trimmedSegment == string.Empty)
                {
                    continue;
                }

                yield return trimmedSegment;
            }
        }

        #endregion
    }
}
