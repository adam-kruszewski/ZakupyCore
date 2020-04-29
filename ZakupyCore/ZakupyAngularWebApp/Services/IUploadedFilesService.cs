using Microsoft.AspNetCore.Http;

namespace ZakupyAngularWebApp.Services
{
    public interface IUploadedFilesService
    {
        string SaveFile(IFormFile file);

        byte[] GetFile(string key);
    }
}