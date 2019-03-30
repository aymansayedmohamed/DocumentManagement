using DocumentManagementLogger;
using IBusiness;
using IDataAccess;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using ViewModels;
namespace Business
{
    public class DocumentManager : IDocumentManager
    {

        private readonly ILogger logger;
        private IRepository<DomainModels.Document> repoDocuments;


        public DocumentManager(ILogger logger, IRepository<DomainModels.Document> repoDocuments)
        {
            this.logger = logger;
            this.repoDocuments = repoDocuments;
        }

        public IQueryable<Document> GetAllDocuments(string userId)
        {
            return
                 (
                 from doc in repoDocuments.GetAll()
                 .Where(O => O.UploadUserId == userId && O.IsDeleted == false)
                 .OrderByDescending(O => O.LastAccessedDate)
                 select new ViewModels.Document()
                 {
                     DocumentID = doc.DocumentID,
                     DocumentSize = doc.DocumentSize,
                     LastAccessedDate = doc.LastAccessedDate,
                     UploadDate = doc.UploadDate,
                     UploadUserId = doc.UploadUserId,
                     DocumentName = doc.DocumentName
                     
                 }).AsQueryable();
        }

        public Document GetDocument(string docId)
        {
            return
                 (
                 from doc in repoDocuments.GetAll()
                 .Where(O => O.DocumentID == new Guid(docId) && O.IsDeleted == false)
                 select new ViewModels.Document()
                 {
                     DocumentID = doc.DocumentID,
                     DocumentSize = doc.DocumentSize,
                     LastAccessedDate = doc.LastAccessedDate,
                     UploadDate = doc.UploadDate,
                     UploadUserId = doc.UploadUserId,
                     DocumentName = doc.DocumentName

                 }).FirstOrDefault();
        }

        public void UploadFiles(Document doc, HttpPostedFile httpPostedFile)
        {
            if (httpPostedFile != null)
            {
                string documentSaveDirectoryPath = GetDocumentSaveDirectoryPath(doc.UploadUserId);

                string documentSavePath = Path.Combine(documentSaveDirectoryPath, httpPostedFile?.FileName);

                // Save the uploaded file to "UploadedFiles" folder
                httpPostedFile.SaveAs(documentSavePath);

                //Save the Document to the database
                DateTime now = DateTime.Now;
                DomainModels.Document document = new DomainModels.Document()
                {
                    DocumentID = Guid.NewGuid(),
                    UploadUserId = doc.UploadUserId,
                    DocumentSize = doc.DocumentSize,
                    IsDeleted = false,
                    LastAccessedDate = now,
                    UploadDate = now,
                    DocumentName = httpPostedFile?.FileName
                };

                repoDocuments.Add(document);

                repoDocuments.SaveChanges();

                logger.AddInformationLog($"document :{document} saved to the database");

            }
        }

        private string GetDocumentSaveDirectoryPath(string userId)
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

            return documentSaveDirectoryPath;
        }
    }
}
