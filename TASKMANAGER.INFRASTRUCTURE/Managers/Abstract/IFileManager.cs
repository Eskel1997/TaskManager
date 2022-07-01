using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TASKMANAGER.INFRASTRUCTURE.Managers.Abstract
{
    public interface IFileManager
    {
        void CreateFolderIfNotExist(long id);
        Task<string> UploadFile(IFormFile file, string fileName, long id);
        string GetFileNameWithExtension(IFormFile file, string fileName, long id);
        string GetFilePath();
        void DeleteFile(string path);
    }
}
