using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ViewModels
{
    public class Document
    {
        public System.Guid DocumentID { get; set; }
        public string DocumentName { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public Nullable<System.DateTime> LastAccessedDate { get; set; }
        public string UploadUserId { get; set; }
        public Nullable<int> DocumentSize { get; set; }
        public string FilePath { get; set; }
    }
}
