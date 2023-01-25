using ConsoleApp.ImportModels;
using System.Collections.Generic;

namespace ConsoleApp.Abstractions
{
    public interface IPrinterService
    {
        void PrintData(IEnumerable<ImportedObject> importedObjects);
    }
}
