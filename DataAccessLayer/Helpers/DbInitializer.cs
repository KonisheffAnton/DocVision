using Microsoft.EntityFrameworkCore;

namespace DocVision.DataAccessLayer.Helpers
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;

        public DbInitializer(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public void Run()
        {
          _context.Database.EnsureCreated();
        }

    }
}