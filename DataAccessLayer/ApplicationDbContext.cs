using DocVision.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocVision.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MailEntity> Mails { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

    }
}
