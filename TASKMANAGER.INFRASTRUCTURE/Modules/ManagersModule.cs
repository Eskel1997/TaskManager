using Microsoft.Extensions.DependencyInjection;
using System.IO.Abstractions;
using TASKMANAGER.INFRASTRUCTURE.Managers.Abstract;
using TASKMANAGER.INFRASTRUCTURE.Managers.Concrete;

namespace TASKMANAGER.INFRASTRUCTURE.Modules
{
    public static class ManagersModule
    {
        public static void AddManagersModule(this IServiceCollection services)
        {
            services.AddScoped<IEncryptionManager, EncryptionManager>();
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<IFileSystem, FileSystem>();
            services.AddScoped<IFileManager, _fileManager>();
        }
    }
}
