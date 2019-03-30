using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ViewModels;

namespace IBusiness
{
    public interface IAccountManager
    {
        string GetUserId(string email);
    }
}
