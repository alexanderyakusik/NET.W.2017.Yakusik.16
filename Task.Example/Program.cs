using Task.Parsers;
using Task.Parsers.SourceProviders;
using Task.XMLGenerators;

namespace Task.Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UriParser.SetLogger(new NLogAdapter(nameof(UriParser)));

            var uriParser = new UriParser();
            var sourceProvider = new FileSourceProvider(@"source.txt");

            var uris = uriParser.ParseSource(sourceProvider);

            IUriXmlGenerator uriXmlGenerator = new UriXmlGenerator();
            System.Console.WriteLine(uriXmlGenerator.GenerateXml(uris));

            System.Console.ReadKey();
        }
    }
}
