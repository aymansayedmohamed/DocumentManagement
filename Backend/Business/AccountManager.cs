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
    public class AccountManager : IAccountManager
    {

        private readonly ILogger logger;
        private IRepository<DomainModels.AspNetUser> repoUser;


        public AccountManager(ILogger logger, IRepository<DomainModels.AspNetUser> repoUser)
        {
            this.logger = logger;
            this.repoUser = repoUser;
        }

        public string GetUserId(string email)
        {
            return
                 repoUser.GetAll()
                 .Where(O => O.Email == email)
                 .FirstOrDefault()?.Id;
        }
    }
}
