using Microsoft.AspNetCore.Http;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using TASKMANAGER.INFRASTRUCTURE.Managers.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Managers.Concrete
{
    internal class _fileManager : IFileManager
    {
        private readonly IFileSystem fileSystem;
        private string filePath;
        private string fileName;
        public _fileManager(IFileSystem fileSystem)
        {
            fileSystem = fileSystem;
        }
        public void CreateFolderIfNotExist(long id)
        {
            if(!CheckFolderExists(id))
            {
                CreateDirectory(id);
            }
        }

        public void DeleteFile(string path)
        {
            if(path == null) return;
            var fullPath = $"{fileSystem.Directory.GetCurrentDirectory()}/{path}";
            fileSystem.File.Delete(fullPath);
        }

        public string GetFileNameWithExtension(IFormFile file, string fileName, long id)
        {
           var extension = fileSystem.Path.GetExtension(file.FileName);
            return $"{fileName}{extension}";
        }

        public string GetFilePath()
        {
            return filePath + fileName;
        }

        public async Task<string> UploadFile(IFormFile file, string fileName, long id)
        {
            CreateFolderIfNotExist(id);

            var uploadFolder = GetUploadDirectory(id);
            string filePath = fileSystem.Path.Combine(uploadFolder, fileName);
            fileName = fileName;
            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return filePath.Remove(0,4);
        }

        private bool CheckFolderExists(long id)
        {
            var directory = GetUploadDirectory(id);
            if (fileSystem.Directory.Exists(directory))
            {
                return true;
            }

            return false;
        }

        private string GetUploadDirectory(long id)
        {
            filePath = $"Files/{id}/";
            return $"{fileSystem.Directory.GetCurrentDirectory()}/{filePath}";
        }

        private void CreateDirectory(long id)
        {
            var directory = GetUploadDirectory(id);
            fileSystem.Directory.CreateDirectory(directory);
        }
    }
}
