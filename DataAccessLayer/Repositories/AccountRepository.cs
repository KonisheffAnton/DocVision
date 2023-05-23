using DocVision.DataAccessLayer.Entities;

namespace DocVision.DataAccessLayer.Repositories
{
    public class AccountRepository : RepositoryBase<AccountEntity>
    {
        public AccountRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
