using DocVision.Core.Interfaces;
using DocVision.DataAccessLayer.Entities;
using DocVision.DataAccessLayer.Interfaces;

namespace DocVision.DataAccessLayer
{
    public class ApplicationUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public IRepositoryBase<MailEntity> MailRepository { get; set; }

        public ApplicationUnitOfWork(ApplicationDbContext context,
            IRepositoryBase<MailEntity> mailRepository)

        {
            _context = context;         
            MailRepository = mailRepository;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
