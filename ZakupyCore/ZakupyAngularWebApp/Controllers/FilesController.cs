using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using ZakupyAngularWebApp.Services;

namespace ZakupyAngularWebApp.Controllers
{
    [Route("api/[controller]")]
    public class FilesController : Controller
    {
        private readonly IUploadedFilesService uploadedFilesService;

        public FilesController(
            IUploadedFilesService uploadedFilesService)
        {
            this.uploadedFilesService = uploadedFilesService;
        }

        public FileResult[] Upload()
        {
            var httpRequest = HttpContext.Request;

            var files = httpRequest.Form.Files;

            var resultFiles = new List<FileResult>();

            foreach (var file in files)
            {
                var fileID = uploadedFilesService.SaveFile(file);

                resultFiles.Add(new FileResult(fileID, file.FileName));
            }

            return resultFiles.ToArray();
        }
    }

    public class FileResult
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public FileResult(string id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}