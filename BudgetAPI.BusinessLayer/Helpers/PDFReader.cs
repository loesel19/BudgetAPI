using Docnet.Core;

namespace PDFReaderLibrary
{
    public class PDFReader
    {
        public PDFReader()
        {

        }

        public void readFile(string filePath, string cardLast4)
        {
            var docReader = DocLib.Instance.GetDocReader(filePath, new Docnet.Core.Models.PageDimensions());
            for (int i = 0; i < docReader.GetPageCount(); i++)
            {
                using (var pageReader = docReader.GetPageReader(i))
                {
                    var text = pageReader.GetText();
                    text = text.Replace("\r", "");
                    string[] split = text.Split('\n');
                    foreach (string line in split)
                    {
                        if (line.Contains("**" + cardLast4))
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
        }
        
    }
}
