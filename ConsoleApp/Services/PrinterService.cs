using ConsoleApp.Abstractions;
using ConsoleApp.ImportModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Services
{
    public class PrinterService : IPrinterService
    {
        public void PrintData(IEnumerable<ImportedObject> importedObjects)
        {
            var importedObjectsTemp = importedObjects.ToList();

            foreach 
            (
                var database 
                in importedObjectsTemp.Where(database => database.Type == "DATABASE")
            )
            {
                Console.WriteLine($"Database '{database.Name}' ({database.NumberOfChildren} tables)");
                PrintTables(importedObjectsTemp, database);
            }
        }

        private void PrintTables(List<ImportedObject> importedObjects, ImportedObject database)
        {
            foreach 
            (
                var table in importedObjects
                    .Where(table => table.ParentType.ToUpper() == database.Type)
                        .Where(table => table.ParentName == database.Name)
            )
            {
                Console.WriteLine($"\tTable '{table.Schema}.{table.Name}' ({table.NumberOfChildren} columns)");
                PrintColumns(importedObjects, table);
            }
        }

        private void PrintColumns(List<ImportedObject> importedObjects, ImportedObject table)
        {
            foreach (var column in importedObjects)
            {
                if (column.ParentType.ToUpper() != table.Type) continue;

                if (column.ParentName == table.Name)
                {
                    Console.WriteLine($"\t\tColumn '{column.Name}' with {column.DataType} data type {(column.IsNullable ? "accepts nulls" : "with no nulls")}");
                }
            }
        }
    }
}
