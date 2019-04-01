using DocumentManagementLogger;
using DomainModels;
using IBusiness;
using IDataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Business.Tests
{
    [TestClass]
    public class AccountManagerTests
    {
        private IAccountManager accountManager;
        private List<AspNetUser> users = new List<AspNetUser>()
        {
            new AspNetUser(){Id = "e30cf1bb-1781-4252-ac1d-2115a79a3fa3", Email = "test@test.test", UserName = "test"},
            new AspNetUser(){Id = "e30cf1bb-1781-4252-ac1d-2115a79a3fa4", Email = "test1@test1.test1", UserName = "test1"},
        };

        [TestInitialize]
        public void TestInitialize()
        {
            Mock<ILogger> logger = new Mock<ILogger>();

            Mock<IRepository<AspNetUser>> repoAspNetUser = new Mock<IRepository<AspNetUser>>();
            repoAspNetUser.Setup(x => x.GetAll()).Returns(users.AsQueryable());


            accountManager = new AccountManager(logger.Object, repoAspNetUser.Object);
        }

        [TestMethod]
        public void GetUserId_PassNull_ReturnNull()
        {
            //arrange
            string email = null;

            //act
            string userId = accountManager.GetUserId(email);

            //assert
            Assert.AreEqual(null, userId);
        }

        [TestMethod]
        public void GetUserId_PassValidEmail_ReturnVaildUser()
        {
            //arrange
            string email = "test@test.test";
            string ExpectedUserId = "e30cf1bb-1781-4252-ac1d-2115a79a3fa3";

            //act
            string userId = accountManager.GetUserId(email);

            //assert
            Assert.AreEqual(ExpectedUserId, userId);
        }
    }
}
