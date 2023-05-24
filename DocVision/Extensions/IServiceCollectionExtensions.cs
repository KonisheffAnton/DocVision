using Microsoft.OpenApi.Models;

namespace DocVision.WebApi.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DocVison",
                    Version = "v1",
                    Description = "An ASP.NET Core Web API for managing Deposits"
                });
            });
        }

    }
}
