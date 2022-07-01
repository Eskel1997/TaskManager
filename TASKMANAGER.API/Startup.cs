using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using TASKMANAGER.API.Extensions;
using TASKMANAGER.API.Middleware;
using TASKMANAGER.API.Validators.Auth;
using TASKMANAGER.DB.DAL;
using TASKMANAGER.INFRASTRUCTURE.Commands.Auth;
using TASKMANAGER.INFRASTRUCTURE.Modules;

namespace TASKMANAGER.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IWebHostEnvironment env)
        {
            // In ASP.NET Core 3.0 `env` will be an IWebHostEnvironment, not IHostingEnvironment.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            CurrentEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }
        private IWebHostEnvironment CurrentEnvironment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (CurrentEnvironment.IsDevelopment())
            {
                services.AddDbContext<TaskManagerContext>(options =>
                {
                    options.UseLazyLoadingProxies();
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
                });
            }
            else
            {
                var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
                services.AddDbContext<TaskManagerContext>(options =>
                    options.UseNpgsql(connectionString));
            }

            services.AddAutoMapper(typeof(LoginUserCommand), typeof(TASKMANAGER.API.ViewModels.Team.TeamAutoMapper));
            services.AddControllers();
            services.AddMediatR(typeof(LoginUserCommand));
            services.AddJwtAuthentication(Configuration);
            services.AddMvc().AddMvcOptions(fv => fv.EnableEndpointRouting = false)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginUserValidator>());
            services.AddSwagger();
            services.AddManagersModule();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServicesModule());
            builder.RegisterModule(new SettingsModule(Configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TaskManagerContext dataContext)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<GlobalExceptionMiddleware>();

            app.UseCorsPolicyExt();

            app.UseSwaggerExt();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(env.ContentRootPath, "Files")),
                RequestPath = "/files"
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            dataContext.Database.MigrateAsync();
        }
    }
}
