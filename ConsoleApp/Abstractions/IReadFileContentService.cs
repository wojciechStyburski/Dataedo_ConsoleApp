using System.Collections.Generic;

namespace ConsoleApp.Abstractions
{
    public interface IReadFileContentService
    {
        List<string> GetContentFileAsList(string fileName);
    }
}
