using DocVision.DataAccessLayer.Entities;

namespace DocVision.DataAccessLayer.Repositories
{
    public class MailRepository : RepositoryBase<MailEntity>
    {
        public MailRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
