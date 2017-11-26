using System;
using System.Collections.Generic;
using System.IO;

namespace Task.Parsers.SourceProviders
{
    /// <summary>
    /// Class that provides enumeration of strings from the file.
    /// </summary>
    public class FileSourceProvider : ISourceProvider
    {
        #region Private fields

        private readonly string filepath;

        #endregion

        #region Ctors

        /// <summary>
        /// Instaniates a new file source by the specified <paramref name="filepath"/>.
        /// </summary>
        /// <param name="filepath">Source file path.</param>
        /// <exception cref="ArgumentException">File with specified <paramref name="filepath"/> does not exist.</exception>
        public FileSourceProvider(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new ArgumentException($"File with specified {nameof(filepath)} does not exist.");
            }

            this.filepath = filepath;
        }

        #endregion

        #region Interfaces implementation

        #region ISourceProvider

        /// <inheritdoc />
        public IEnumerable<string> GetSource()
        {
            using (var streamReader = new StreamReader(new FileStream(filepath, FileMode.Open)))
            {
                while (!streamReader.EndOfStream)
                {
                    yield return streamReader.ReadLine();
                }
            }
        }

        #endregion

        #endregion
    }
}
