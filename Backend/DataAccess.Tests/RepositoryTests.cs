using System;
using DomainModels;
using IDataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private Document document;
        IRepository<Document> repo;

        [TestInitialize]
        public void TestInitialize()
        {
            repo = new Repository<Document>(new UnitOfWork());
            // insert test data
            document = new Document
            {
                DocumentID = Guid.NewGuid(),
                DocumentName = "DocumentName",
                IsDeleted = false,
                UploadDate = DateTime.Now,
                UploadUserId = "e30cf1bb-1781-4252-ac1d-2115a79a3fa3",
                DocumentSize = 55,
                LastAccessedDate = DateTime.Now
            };

        }

        [TestCleanup]
        public void TestCleanUp()
        {
            repo.Delete(document);
            repo.Dispose();
        }


        [TestMethod]
        public void Add_ValidEntity_SaveSucess()
        {
            //arrange

            //act
            repo.Add(document);
            repo.SaveChanges();

            //assert

        }

        [TestMethod]
        public void Find_SearchForEntity_ReturnedSucess()
        {
            //arrange
            repo.Add(document);
            repo.SaveChanges();

            //act
            var result = repo.Find(document.DocumentID);

            //assert
            Assert.AreEqual(document.DocumentID, result.DocumentID);

        }

        [TestMethod]
        public void Update_UpdateDocumentName_UpdateSucess()
        {
            //arrange
            repo.Add(document);
            repo.SaveChanges();

            //act
            var newDocName = "NewName";

            var TempDoc = repo.Find(document.DocumentID);
            TempDoc.DocumentName = newDocName;

            repo.Update(TempDoc);

            //assert
            Assert.AreEqual(document.DocumentName, newDocName);

        }


    }
}
