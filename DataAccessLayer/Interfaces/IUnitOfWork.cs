using DocVision.Core.Interfaces;
using DocVision.DataAccessLayer.Entities;

namespace DocVision.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<AccountEntity> AccountRepository { get; set; }

        IRepositoryBase<MailEntity> MailRepository { get; set; }


        Task SaveChangesAsync();
    }
}
