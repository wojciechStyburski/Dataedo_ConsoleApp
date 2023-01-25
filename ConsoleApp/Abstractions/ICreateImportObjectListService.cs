using ConsoleApp.ImportModels;
using System.Collections.Generic;

namespace ConsoleApp.Abstractions
{
    public interface ICreateImportObjectListService
    {
        IEnumerable<ImportedObject> CreateImportedObjectList(List<string> fileContent);
    }
}
