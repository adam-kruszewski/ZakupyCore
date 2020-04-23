using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace ZakupyAngularWebApp.Controllers
{
    [Route("api/[controller]")]
    public class FilesController : Controller
    {
        public FileResult[] Upload()
        {
            var httpRequest = HttpContext.Request;

            var files = httpRequest.Form.Files;

            var resultFiles = new List<FileResult>();

            foreach (var file in files)
            {
                var tempPath = Path.GetTempPath();

                var fileID = "zakupyCore____" + Guid.NewGuid().ToString();

                var nazwa = Path.Combine(tempPath, fileID);

                using (FileStream fs = new FileStream(nazwa, FileMode.Create))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

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