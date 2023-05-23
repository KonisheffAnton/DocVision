using DocVision.Core.Interfaces;
using DocVision.DataAccessLayer.Entities;
using DocVision.DataAccessLayer.Interfaces;

namespace DocVision.DataAccessLayer
{
    public class ApplicationUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public IRepositoryBase<AccountEntity> AccountRepository { get; set; }
        public IRepositoryBase<MailEntity> MailRepository { get; set; }

        public ApplicationUnitOfWork(ApplicationDbContext context,
            IRepositoryBase<AccountEntity> accountRepository,
            IRepositoryBase<MailEntity> mailRepository)

        {
            _context = context;         
            AccountRepository = accountRepository;
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
