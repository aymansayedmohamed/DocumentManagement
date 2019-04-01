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
    public interface IFileHelper
    {
         string GetDocumentSavePath(string userId, string fileName);
        byte[] ReadFileContent(string filePath);

    }
}
