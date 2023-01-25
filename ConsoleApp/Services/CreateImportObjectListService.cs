using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Abstractions;
using ConsoleApp.ImportModels;

namespace ConsoleApp.Services
{
    public class CreateImportObjectListService : ICreateImportObjectListService
    {
        public IEnumerable<ImportedObject> CreateImportedObjectList(List<string> fileContent)
        {
            var importedObjects = 
            (
                from line in fileContent 
                select line.Split(';') 
                into values 
                where values.Length >= 7 
                select values.Select(c => c.Trim().Replace(" ", "").Replace(Environment.NewLine, "")).ToArray() 
                into values 
                select new ImportedObject
                (
                    values.ElementAtOrDefault(0) ?? string.Empty, 
                    values.ElementAtOrDefault(1) ?? string.Empty, 
                    values.ElementAtOrDefault(2) ?? string.Empty, 
                    values.ElementAtOrDefault(3) ?? string.Empty, 
                    values.ElementAtOrDefault(4) ?? string.Empty, 
                    values.ElementAtOrDefault(5) ?? string.Empty, 
                    values.ElementAtOrDefault(6) == "1"
                )
            ).ToList();

            foreach 
            (
                var importedObject in 
                from importedObject in importedObjects 
                from impObj 
                in importedObjects.Where(impObj => impObj.ParentType == importedObject.Type && impObj.ParentName == importedObject.Name) 
                select importedObject
            )
            {
                importedObject.SetNumberOfChildren();
            }

            return importedObjects.AsEnumerable();
        }
    }
}
