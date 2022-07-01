using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TASKMANAGER.DB.Repositories.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Commands.File;
using TASKMANAGER.INFRASTRUCTURE.Managers.Abstract;

namespace TASKMANAGER.INFRASTRUCTURE.Handlers.File
{
    public class FileUploadHandler : IRequestHandler<FileUploadCommand, string>
    {
        private readonly IFileManager _fileManager;
        private ILogger<FileUploadHandler> Logger;
        public FileUploadHandler(IFileManager manager, ILogger<FileUploadHandler> logger)
        {
            _fileManager = manager;
            Logger = logger;
        }
        public async Task<string> Handle(FileUploadCommand request, CancellationToken cancellationToken)
        {
            var result = await _fileManager.UploadFile(request.File, request.File.FileName, request.UserId);

            return result;
        }
    }
}
