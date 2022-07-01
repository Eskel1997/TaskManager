using MediatR;
using Microsoft.AspNetCore.Http;

namespace TASKMANAGER.INFRASTRUCTURE.Commands.File
{
    public class FileUploadCommand : IRequest<string>, IAuth
    {
        public IFormFile File {get; set;}
        public long UserId {get; set;}
        public FileUploadCommand(IFormFile file)
        {
            File = file;
        }
    }
}
