using DocumentManagementLogger;
using DomainModels;
using IBusiness;
using IDataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Business.Tests
{
    [TestClass]
    public class DocumentManagerTests
    {
        private IDocumentManager documentManager;
        private DateTime yesterday;
        private DateTime today;
        private Document docYesterday;
        private Document docToday;
        private List<Document> documents;
        private Guid userId;

        Mock<ILogger> logger ;
        Mock<IRepository<Document>> repoDocument ;
        Mock<IFileHelper> fileHelper ;

        [TestInitialize]
        public void TestInitialize()
        {
            today = new DateTime(2019, 4, 4, 4, 4, 4);
            yesterday = new DateTime(2019, 4, 3, 4, 4, 4);
            userId = Guid.NewGuid();

            docYesterday = new Document()
            {
                DocumentID = new Guid("e30cf1bb-1781-4252-ac1d-2115a79a3fa3"),
                DocumentName = "  DOC1",
                DocumentSize = 5,
                IsDeleted = false,
                UploadUserId = userId.ToString(),
                LastAccessedDate = yesterday,
                UploadDate = yesterday
            };

            docToday = new Document()
            {
                DocumentID = new Guid("e30cf1bb-1781-4252-ac1d-2115a79a3fa4"),
                DocumentName = "  DOC2",
                DocumentSize = 6,
                IsDeleted = false,
                UploadUserId = userId.ToString(),
                LastAccessedDate = today,
                UploadDate = today
            };

            documents = new List<Document>() { docYesterday, docToday };

            logger = new Mock<ILogger>();

            repoDocument = new Mock<IRepository<Document>>();
            repoDocument.Setup(x => x.GetAll()).Returns(documents.AsQueryable());

            fileHelper = new Mock<IFileHelper>();


            documentManager = new DocumentManager(logger.Object, repoDocument.Object,fileHelper.Object);
        }



        #region GetAllDocuments
        [TestMethod]
        public void GetAllDocuments_PassNullUserId_ReturnZeroDocs()
        {
            //arrange
            string userId = null;
            int expectedDocsCount = 0;

            //act
            var docs = documentManager.GetAllDocuments(userId);

            //assert
            Assert.AreEqual(expectedDocsCount, docs.Count());
        }


        [TestMethod]
        public void GetAllDocuments_PassValidUserId_ReturnVaildDocumentsCounts()
        {
            //arrange
            string tempuserId = userId.ToString();
            int expectedUsersCount = 2;

            //act
            var docs = documentManager.GetAllDocuments(tempuserId);

            //assert
            Assert.AreEqual(expectedUsersCount, docs.Count());
        }

        [TestMethod]
        public void GetAllDocuments_PassValidUserId_ReturnVaildDocumentsOrder()
        {
            //arrange
            string tempuserId = userId.ToString();
            Guid expectedFirstDocId = docToday.DocumentID ;

            //act
            var firstDoc = documentManager.GetAllDocuments(tempuserId).FirstOrDefault();

            //assert
            Assert.AreEqual(expectedFirstDocId, firstDoc.DocumentID);
        }
        #endregion

        #region GetDocument
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetDocument_PassNullDocId_ThrowNullArgException()
        {
            //arrange
            string docId = null;

            //act
            var doc = documentManager.GetDocument(docId);

        }


        [TestMethod]
        public void GetDocument_PassValidDocId_ReturnVaildDocument()
        {
            //arrange
            string tempDocId = docToday.DocumentID.ToString();

            fileHelper.Setup(O => O.GetDocumentSavePath(docToday.UploadUserId, docToday.DocumentName)).Returns("PATH//path");
            documentManager = new DocumentManager(logger.Object, repoDocument.Object, fileHelper.Object);

            //act
            var doc = documentManager.GetDocument(tempDocId);

            //assert
            Assert.AreEqual(tempDocId, doc.DocumentID.ToString());
        }

        #endregion
        #region ReadFileContent
       

        #endregion
    }
}
