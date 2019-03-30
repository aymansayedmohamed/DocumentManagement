﻿using DocumentManagementLogger;
using IBusiness;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using ViewModels;

namespace DocumentManagementAPIs.Controllers
{
    [RoutePrefix("api/Documents")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DocumentController : ApiController
    {

        private readonly IDocumentManager documentManager;
        private readonly ILogger logger;
        public DocumentController(IDocumentManager documentManager, ILogger logger)
        {
            this.documentManager = documentManager;
            this.logger = logger;
        }


        [HttpGet]
        [Route("DownloadFiles/{Id}")]
        [Authorize]
        public HttpResponseMessage GetFile(string Id)
        {
            //Create HTTP Response.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            //Set the File Path.
            string filePath = @"D:\UploadedFiles\e30cf1bb-1781-4252-ac1d-2115a79a3fa3\RSP1437267_2_RSP.pdf";

            //Check whether File exists.
            if (!File.Exists(filePath))
            {
                //Throw 404 (Not Found) exception if File not found.
                response.StatusCode = HttpStatusCode.NotFound;
                response.ReasonPhrase = string.Format("File not found: {0} .", Id);
                throw new HttpResponseException(response);
            }

            //Read the File into a Byte Array.
            byte[] bytes = File.ReadAllBytes(filePath);

            //Set the Response Content.
            response.Content = new ByteArrayContent(bytes);

            //Set the Response Content Length.
            response.Content.Headers.ContentLength = bytes.LongLength;

            //Set the File Content Type.
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping("RSP1437267_2_RSP.pdf"));
            return response;

         
        }


        [HttpGet]
        [Route("GetAllDocuments")]
        [Authorize]
        public HttpResponseMessage GetAllDocuments()
        {
            try
            {
                var documents = documentManager.GetAllDocuments().ToList();

                return Request.CreateResponse(HttpStatusCode.OK, documents);
            }
            catch (Exception ex)
            {
                //handle exception
                logger.AddErrorLog(ex);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        //[Route("UploadFiles")]
        //[HttpPost]
        //public async Task<HttpResponseMessage> ReadStream()
        //{
        //    using (var stream = await Request.Content.ReadAsStreamAsync())
        //    {
        //        var fileStream = File.OpenWrite(@"D:\CV\Interviews\FRISS\2nd phase Assesment task\DocumentManagement\Backend\DocumentManagementAPIs\UploadedFiles");

        //        stream.CopyTo(fileStream);

        //        fileStream.Close();
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}



        [Route("UploadFiles")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage UploadFiles()
        {
            try
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    // Get the uploaded image from the Files collection
                    var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                    var document = new Document()
                    {
                        UploadUserId = "e30cf1bb-1781-4252-ac1d-2115a79a3fa3" //this.User.Identity.Name
                       ,
                        DocumentSize = 5 //todo
                    };

                    this.documentManager.UploadFiles(document, httpPostedFile);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }

            catch(Exception ex)
            {
                //log exception details
                logger.AddErrorLog(ex);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        /*
        [Route("UploadFiles")]
        [HttpPost]
        public async Task<HttpResponseMessage> UploadFilesAsync()
        {
            var provider = new MultipartFormDataStreamProvider(@"D:\CV\Interviews\FRISS\2nd phase Assesment task\DocumentManagement\Backend\DocumentManagementAPIs\UploadedFiles");
            var content = new StreamContent(HttpContext.Current.Request.GetBufferlessInputStream(true));
            foreach (var header in Request.Content.Headers)
            {
                content.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            await content.ReadAsMultipartAsync(provider);

            return Request.CreateResponse(HttpStatusCode.OK, 10);
        }*/




        /*
        // generic file post method - use in MVC or WebAPI
        [Route("UploadFiles")]
        [HttpPost]
        public HttpResponseMessage UploadFile()
        {
            foreach (string file in HttpContext.Current.Request.Files)
            {
                var FileDataContent = HttpContext.Current.Request.Files[file];
                if (FileDataContent != null && FileDataContent.ContentLength > 0)
                {
                    // take the input stream, and save it to a temp folder using the original file.part name posted
                    var stream = FileDataContent.InputStream;
                    var fileName = Path.GetFileName(FileDataContent.FileName);
                    var UploadPath = @"D:\CV\Interviews\FRISS\2nd phase Assesment task\DocumentManagement\Backend\DocumentManagementAPIs\UploadedFiles";
                    //var UploadPath = Server.MapPath("~/App_Data/uploads");
                    Directory.CreateDirectory(UploadPath);
                    string path = Path.Combine(UploadPath, fileName);
                    try
                    {
                        if (System.IO.File.Exists(path))
                            System.IO.File.Delete(path);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                        // Once the file part is saved, see if we have enough to merge it
                        Shared.Utils UT = new Shared.Utils();
                        UT.MergeFile(path);
                    }
                    catch (IOException ex)
                    {
                        // handle
                    }
                }
            }
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent("File uploaded.")
            };
        }

        */


        /*

        [Route("UploadFiles")]
        [HttpPost]
        public async Task<HttpResponseMessage> UploadFile()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }

            var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();

            foreach (var stream in filesReadToProvider.Contents)
            {
                var fileBytes = await stream.ReadAsByteArrayAsync();
            }
            return Request.CreateErrorResponse(HttpStatusCode.OK, "h");
        }
        */

        //[Route("UploadFiles")]
        //[HttpPost]
        ////[ValidateMimeMultipartContentFilter]
        //public async Task<IHttpActionResult> UploadDocument()
        //{
        //    var uploadFileService = new UploadFileService();
        //    UploadProcessingResult uploadResult = await uploadFileService.HandleRequest(Request);

        //    if (uploadResult.IsComplete)
        //    {
        //        // do other stuff here after file upload complete    
        //        return Ok();
        //    }

        //    return Ok(HttpStatusCode.Continue);

        //}

    }


    //public class UploadFileService
    //{
    //    private readonly string _uploadPath;
    //    private readonly MultipartFormDataStreamProvider _streamProvider;

    //    public UploadFileService()
    //    {
    //        _uploadPath = UserLocalPath;
    //        _streamProvider = new MultipartFormDataStreamProvider(_uploadPath);
    //    }

    //    #region Interface

    //    public async Task<UploadProcessingResult> HandleRequest(HttpRequestMessage request)
    //    {
    //        await request.Content.ReadAsMultipartAsync(_streamProvider);
    //        return await ProcessFile(request);
    //    }

    //    #endregion    

    //    #region Private implementation

    //    private async Task<UploadProcessingResult> ProcessFile(HttpRequestMessage request)
    //    {
    //        if (request.IsChunkUpload())
    //        {
    //            return await ProcessChunk(request);
    //        }

    //        return new UploadProcessingResult()
    //        {
    //            IsComplete = true,
    //            FileName = OriginalFileName,
    //            LocalFilePath = LocalFileName,
    //            FileMetadata = _streamProvider.FormData
    //        };
    //    }

    //    private async Task<UploadProcessingResult> ProcessChunk(HttpRequestMessage request)
    //    {
    //        //use the unique identifier sent from client to identify the file
    //        FileChunkMetaData chunkMetaData = request.GetChunkMetaData();
    //        string filePath = Path.Combine(_uploadPath, string.Format("{0}.temp", chunkMetaData.ChunkIdentifier));

    //        //append chunks to construct original file
    //        using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate | FileMode.Append))
    //        {
    //            var localFileInfo = new FileInfo(LocalFileName);
    //            var localFileStream = localFileInfo.OpenRead();

    //            await localFileStream.CopyToAsync(fileStream);
    //            await fileStream.FlushAsync();

    //            fileStream.Close();
    //            localFileStream.Close();

    //            //delete chunk
    //            localFileInfo.Delete();
    //        }

    //        return new UploadProcessingResult()
    //        {
    //            IsComplete = chunkMetaData.IsLastChunk,
    //            FileName = OriginalFileName,
    //            LocalFilePath = chunkMetaData.IsLastChunk ? filePath : null,
    //            FileMetadata = _streamProvider.FormData
    //        };

    //    }

    //    #endregion    

    //    #region Properties

    //    private string LocalFileName
    //    {
    //        get
    //        {
    //            MultipartFileData fileData = _streamProvider.FileData.FirstOrDefault();
    //            return fileData.LocalFileName;
    //        }
    //    }

    //    private string OriginalFileName
    //    {
    //        get
    //        {
    //            MultipartFileData fileData = _streamProvider.FileData.FirstOrDefault();
    //            return fileData.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
    //        }
    //    }

    //    private string UserLocalPath
    //    {
    //        get
    //        {
    //            //return the path where you want to upload the file    
    //            return @"D:\CV\Interviews\FRISS\2nd phase Assesment task\DocumentManagement\Backend\DocumentManagementAPIs\UploadedFiles";
    //        }
    //    }

    //    #endregion    
    //}

    //public static class HttpRequestMessageExtensions
    //{
    //    public static bool IsChunkUpload(this HttpRequestMessage request)
    //    {
    //        return request.Content.Headers.ContentRange != null;
    //    }

    //    public static FileChunkMetaData GetChunkMetaData(this HttpRequestMessage request)
    //    {
    //        return new FileChunkMetaData()
    //        {
    //            ChunkIdentifier = request.Headers.Contains("X-DS-Identifier") ? request.Headers.GetValues("X-File-Identifier").FirstOrDefault() : null,
    //            ChunkStart = request.Content.Headers.ContentRange.From,
    //            ChunkEnd = request.Content.Headers.ContentRange.To,
    //            TotalLength = request.Content.Headers.ContentRange.Length
    //        };
    //    }
    //}

    //public class FileChunkMetaData
    //{
    //    public string ChunkIdentifier { get; set; }

    //    public long? ChunkStart { get; set; }

    //    public long? ChunkEnd { get; set; }

    //    public long? TotalLength { get; set; }

    //    public bool IsLastChunk
    //    {
    //        get { return ChunkEnd + 1 >= TotalLength; }
    //    }
    //}

    //public class UploadProcessingResult
    //{
    //    public bool IsComplete { get; set; }

    //    public string FileName { get; set; }

    //    public string LocalFilePath { get; set; }

    //    public NameValueCollection FileMetadata { get; set; }
    //}

}