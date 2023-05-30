
using DocVision.Business.Models;

namespace DocVision.Business.Interfaces
{
    public interface IMailService : IDisposable
    {
        public Task CreateMailAsync(MailBusinessModel mailBusinessModel);

        public Task DeleteMailAsync(MailBusinessModel mailBusinessModel);

        public Task<IEnumerable<MailBusinessModel>> GetAllMailsAsync();

        public Task UpdateMailAsync(MailBusinessModel mailBusinessModel);    
    }
}
