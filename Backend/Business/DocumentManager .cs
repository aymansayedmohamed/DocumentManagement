using DocumentManagementLogger;
using IBusiness;
using IDataAccess;
using System;
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
            logger.AddInformationLog($"UserId: {userId}");

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
            logger.AddInformationLog($"DocId : {docId}");

            DateTime now = DateTime.Now;

            DomainModels.Document DomainDoc = repoDocuments.Find(docId);
            logger.AddInformationLog($"Document before update: {DomainDoc}");

            DomainDoc.LastAccessedDate = now;

            repoDocuments.SaveChanges();
            logger.AddInformationLog($"Document after update: {DomainDoc}");

        }

        public Document GetDocument(string docId)
        {
            logger.AddInformationLog($"DocId: {docId}");

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

                logger.AddInformationLog($"Document for Id: {docId} is : {document}");

                return document;
            }

        }

        public void UploadFiles(Document doc, Stream stream)
        {
            if (stream != null)
            {
                string documentSavePath = fileHelper.GetDocumentSavePath(doc.UploadUserId, doc.DocumentName);
                logger.AddInformationLog($"document Save Path: {documentSavePath}");

                fileHelper.SaveFile(stream, documentSavePath);
                logger.AddInformationLog("Document Saved Success");

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
                logger.AddInformationLog($"Document Meta Data: {document}");

                repoDocuments.SaveChanges();

                logger.AddInformationLog("Document meta data saved to the database");


            }
        }






    }
}
