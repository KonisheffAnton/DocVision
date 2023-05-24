using DocVision.DataAccessLayer.Entities;
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
            var mails = new List<MailEntity>();

            if (!_context.Mails.Any())
            {
                for (int i = 1; i <= 9; i++)
                {
                    var mail = new MailEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = $"MailName {i}",
                        Sender = $"Sender {i}",
                        Addressee = $"Adressee {i}",
                        Data = DateTime.Now,
                        Content = $"Mail content {i}"
                    };

                    mails.Add(mail);
                    _context.Mails.Add(mail);
                    _context.SaveChanges();
                }
            }
        }

    }
}