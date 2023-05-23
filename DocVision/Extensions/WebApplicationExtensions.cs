
using DocVision.DataAccessLayer.Helpers;

namespace DocVision.WebApi.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void InitializeDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var initializer = services.GetRequiredService<DbInitializer>();

            initializer.Run();
        }
    }
}
