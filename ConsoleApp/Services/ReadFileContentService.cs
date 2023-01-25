using ConsoleApp.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp.Services
{
    public class ReadFileContentService : IReadFileContentService
    {
        public List<string> GetContentFileAsList(string fileName)
        {
            var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            var importedLines = new List<string>();

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    importedLines.Add(line);
                }
            }

            return importedLines;
        }
    }
}
