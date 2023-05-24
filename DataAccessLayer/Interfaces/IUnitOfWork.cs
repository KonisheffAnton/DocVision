using DocVision.Core.Interfaces;
using DocVision.DataAccessLayer.Entities;

namespace DocVision.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<MailEntity> MailRepository { get; set; }


        Task SaveChangesAsync();
    }
}
