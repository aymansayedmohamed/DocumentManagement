﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ViewModels;

namespace IBusiness
{
    public interface IDocumentManager
    {
        void UploadFiles(Document doc, HttpPostedFile httpPostedFile);
        IQueryable<Document> GetAllDocuments(string userId);
        Document GetDocument(string docId);
        byte[] ReadFileContent(string filePath);
        void UpdateLastAccessDate(Guid docId);

    }
}
