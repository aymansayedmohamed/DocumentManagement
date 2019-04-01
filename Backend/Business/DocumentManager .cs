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
    public class DocumentManager : IDocumentManager
    {

        private readonly ILogger logger;
        private readonly IFileHelper fileHelper;
        private IRepository<DomainModels.Document> repoDocuments;


        public DocumentManager(ILogger logger, IRepository<DomainModels.Document> repoDocuments, IFileHelper fileHelper)
        {
            this.logger = logger;
            this.fileHelper = fileHelper;
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

        public void UpdateLastAccessDate(Guid docId)
        {
            DateTime now = DateTime.Now;

            DomainModels.Document DomainDoc = repoDocuments.Find(docId);
            DomainDoc.LastAccessedDate = now;

            repoDocuments.SaveChanges();

        }

        public Document GetDocument(string docId)
        {
            if (string.IsNullOrWhiteSpace(docId))
            {
                throw new ArgumentNullException("DocumentId sholdun't be null");
            }
            else
            {
                Document document = (
                                from doc in repoDocuments.GetAll()
                                .Where(O => O.DocumentID == new Guid(docId) && O.IsDeleted == false)
                                select new ViewModels.Document()
                                {
                                    DocumentID = doc.DocumentID,
                                    DocumentSize = doc.DocumentSize,
                                    LastAccessedDate = doc.LastAccessedDate,
                                    UploadDate = doc.UploadDate,
                                    UploadUserId = doc.UploadUserId,
                                    DocumentName = doc.DocumentName,
                                }).FirstOrDefault();

                if (document != null)
                {
                    document.FilePath = fileHelper.GetDocumentSavePath(document?.UploadUserId, document?.DocumentName);
                }

                return document;
            }

        }

        public void UploadFiles(Document doc, Stream stream)
        {
            if (stream != null)
            {
                string documentSavePath = fileHelper.GetDocumentSavePath(doc.UploadUserId, doc.DocumentName);

                // Save the uploaded file to "UploadedFiles" folder
                using (stream)
                {
                    using (FileStream fileStream = File.Create(documentSavePath))
                    {
                        stream.CopyTo(fileStream);
                    }
                }

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
                    DocumentName = doc.DocumentName
                };

                repoDocuments.Add(document);

                repoDocuments.SaveChanges();

                logger.AddInformationLog($"document :{document} saved to the database");

            }
        }

       

        


    }
}
