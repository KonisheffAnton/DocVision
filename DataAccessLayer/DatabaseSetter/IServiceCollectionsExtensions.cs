using DocVision.Core.Interfaces;
using DocVision.DataAccessLayer.Entities;
using DocVision.DataAccessLayer.Helpers;
using DocVision.DataAccessLayer.Interfaces;
using DocVision.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocVision.DataAccessLayer.DatabaseSetter
{
    public static class IServiceCollectionsExtensions
    {
        public static void RegisterDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            var appDbConnectionString = configuration.GetConnectionString("SQLExpressSQLAuth");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(appDbConnectionString));
            services.AddScoped<IRepositoryBase<MailEntity>, MailRepository>();
            services.AddScoped<IUnitOfWork, ApplicationUnitOfWork>();
            services.AddTransient<DbInitializer>();
        }
    }
}
