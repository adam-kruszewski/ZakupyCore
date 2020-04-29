using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ZakupyAngularWebApp.Services.Impl
{
    public class UploadedFilesService : IUploadedFilesService
    {
        public byte[] GetFile(string key)
        {
            var tempPath = Path.GetTempPath();
            var filePath = Path.Combine(tempPath, key);

            return File.ReadAllBytes(filePath);
        }

        public string SaveFile(IFormFile file)
        {
            var tempPath = Path.GetTempPath();

            var fileID = "zakupyCore____" + Guid.NewGuid().ToString();

            var nazwa = Path.Combine(tempPath, fileID);

            using (FileStream fs = new FileStream(nazwa, FileMode.Create))
            {
                file.CopyTo(fs);
                fs.Flush();
            }

            return fileID;
        }
    }
}
