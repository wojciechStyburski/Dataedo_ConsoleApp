using ConsoleApp.Commands;
using System;
using log4net;
using log4net.Config;
using System.IO;
using System.Reflection;

namespace ConsoleApp
{
    internal class Program
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            const string IMPORT_FILE_NAME = "data.csv";
            try
            {
                var fileCommand = new FileCommand(IMPORT_FILE_NAME);
                var fileCommandHandler = new FileCommandHandler();

                fileCommandHandler.Handle(command: fileCommand);

                
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                log.Error($"Error type: {ex.GetType()} during handling file {IMPORT_FILE_NAME}. Please, contact your system administrator.");
                log.Error(ex.Message);
            }
        }
    }
}
