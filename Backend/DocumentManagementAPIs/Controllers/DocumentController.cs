using DocumentManagementLogger;
using IBusiness;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using ViewModels;
namespace DocumentManagementAPIs.Controllers
{
    [RoutePrefix("api/Documents")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DocumentController : ApiController
    {

        private readonly IDocumentManager documentManager;
        private readonly IAccountManager accountManager;
        private readonly ILogger logger;
        private readonly IFileHelper fileHelper;
        public DocumentController(IDocumentManager documentManager, IAccountManager accountManager, ILogger logger, IFileHelper fileHelper)
        {
            this.documentManager = documentManager;
            this.accountManager = accountManager;
            this.logger = logger;
            this.fileHelper = fileHelper;
        }


        [HttpGet]
        [Route("DownloadDocument/{Id}")]
        [Authorize]
        public HttpResponseMessage DownloadDocument(string Id)
        {
            try
            {
                string userId = accountManager.GetUserId(User.Identity.Name);
                Document document = documentManager.GetDocument(Id);

                if (userId == document.UploadUserId)
                {

                    byte[] bytes = fileHelper.ReadFileContent(document.FilePath);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

                    response.Content = new ByteArrayContent(bytes);

                    response.Content.Headers.ContentLength = bytes.LongLength;

                    response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(document.DocumentName));

                    documentManager.UpdateLastAccessDate(document.DocumentID);

                    return response;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Unatherized to download this file");
                }
            }
            catch(ArgumentNullException argNullEx)
            {
                logger.AddErrorLog(argNullEx.Message, argNullEx);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, argNullEx.Message);
            }
            catch (FileNotFoundException fileNotFoundEx)
            {
                logger.AddErrorLog(fileNotFoundEx.Message, fileNotFoundEx);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, fileNotFoundEx.Message);
            }
            catch (Exception ex)
            {
                logger.AddErrorLog(ex);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }


        [HttpGet]
        [Route("GetAllDocuments")]
        [Authorize]
        public HttpResponseMessage GetAllDocuments()
        {
            try
            {
                string userId = accountManager.GetUserId(User.Identity.Name);

                List<Document> documents = documentManager.GetAllDocuments(userId).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, documents);
            }
            catch (Exception ex)
            {
                logger.AddErrorLog(ex);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [Route("UploadDocument")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage UploadDocument()
        {
            try
            {
                Document document = null;
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    // Get the uploaded image from the Files collection
                    HttpPostedFile httpPostedFile = HttpContext.Current.Request.Files["UploadedDocument"];
                    string userId = accountManager.GetUserId(User.Identity.Name);

                     document = new Document()
                    {
                        UploadUserId = userId,
                        DocumentSize = httpPostedFile.ContentLength,
                        DocumentName = httpPostedFile.FileName
                    };

                    documentManager.UploadFiles(document, httpPostedFile.InputStream);
                }

                return Request.CreateResponse(HttpStatusCode.OK, document);
            }

            catch (Exception ex)
            {
                //log exception details
                logger.AddErrorLog(ex);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}
