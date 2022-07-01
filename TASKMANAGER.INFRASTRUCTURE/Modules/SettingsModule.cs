using Autofac;
using Microsoft.Extensions.Configuration;
using TASKMANAGER.INFRASTRUCTURE.Settings;

namespace TASKMANAGER.INFRASTRUCTURE.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var jwtSettings = _configuration.GetSection(typeof(JwtSettings).Name);
            builder.Register(p => jwtSettings).SingleInstance();

            base.Load(builder);
        }
    }
}
