using Microsoft.AspNetCore.Builder;

namespace TASKMANAGER.API.Extensions
{
    public static class CorsPolicyExtension
    {
        public static void UseCorsPolicyExt(this IApplicationBuilder app)
        {
            app.UseCors(opts =>
            {
                opts.AllowAnyOrigin();
                opts.AllowAnyMethod();
                opts.AllowAnyHeader();
            });
        }
    }
}
