using System;
using ConsoleApp.Abstractions;

namespace ConsoleApp.Commands
{
    public class FileCommand : ICommand
    {
        public string FileName { get; private set; }

        public FileCommand(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("File name is invalid.");

            FileName = fileName;
        }
    }
}
