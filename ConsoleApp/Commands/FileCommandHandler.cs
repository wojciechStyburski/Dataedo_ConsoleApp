using ConsoleApp.Abstractions;
using ConsoleApp.Services;

namespace ConsoleApp.Commands
{
    public class FileCommandHandler : ICommandHandler<FileCommand>
    {
        private readonly IReadFileContentService _readFileContentService;
        private readonly ICreateImportObjectListService _createImportObjectListService;
        private readonly IPrinterService _printerService;

        public FileCommandHandler()
        {
            _readFileContentService = new ReadFileContentService();
            _createImportObjectListService = new CreateImportObjectListService();
            _printerService = new PrinterService();
        }
        public void Handle(FileCommand command)
        {
            var fileContent = _readFileContentService.GetContentFileAsList(command.FileName);
            var importObjectList = _createImportObjectListService.CreateImportedObjectList(fileContent);
            _printerService.PrintData(importObjectList);
        }
    }
}
