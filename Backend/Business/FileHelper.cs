using DocumentManagementLogger;
using IBusiness;
using IDataAccess;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using ViewModels;
namespace Business
{
    public class FileHelper : IFileHelper
    {
        private readonly ILogger logger;


        public FileHelper(ILogger logger)
        {
            this.logger = logger;
        }

        public string GetDocumentSavePath(string userId, string fileName)
        {
            // Get the complete file path
            string localDirectoryPath = ConfigurationManager.AppSettings["LocalDirectory"];
            logger.AddInformationLog($"LocalDirectory config value: {localDirectoryPath}");

            string documentSaveDirectoryPath = Path.Combine(localDirectoryPath, userId);

            DirectoryInfo documentSaveDirectory = new DirectoryInfo(documentSaveDirectoryPath);

            if (!documentSaveDirectory.Exists)
            {
                logger.AddInformationLog($"{documentSaveDirectory} :  not exists.");

                documentSaveDirectory.Create();

                logger.AddInformationLog($"{documentSaveDirectory} :  is created.");
            }

            return Path.Combine(documentSaveDirectoryPath, fileName);

        }

        public byte[] ReadFileContent(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Document not found at {filePath}");
            }

            //Read the File into a Byte Array.
            byte[] bytes = File.ReadAllBytes(filePath);
            return bytes;
        }

        public void SaveFile(Stream stream, string path)
        {
            logger.AddInformationLog($"File Path: {path}");

            using (stream)
            {
                using (FileStream fileStream = File.Create(path))
                {
                    stream.CopyTo(fileStream);
                    logger.AddInformationLog("File Saved Success");
                }
            }
        }


    }
}
