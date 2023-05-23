
using DocVision.Business.Models;

namespace DocVision.Business.Interfaces
{
    public interface IMailService : IDisposable
    {
        public Task CreateMailAsync(MailBusinessModel mailBusinessModel);

        public Task DeleteMailAsync(MailBusinessModel mailBusinessModel);

        public Task<IEnumerable<MailBusinessModel>> GetAllMailsAsync();

        public Task UpdateMailAsync(MailBusinessModel mailBusinessModel);

        //public Task<OpenApplicationBusinessModel> GetOpenApplicationByDepositProductNameAndClientIdAsync(Guid clientId, string depositProductName);

        //public Task UpdateOpenApplicationAsync(OpenApplicationBusinessModel openApplication);

        //public Task<OpenApplicationCodeResult> TurnApplicationIsActiveFieldToFalseAsync(Guid clientId, string depositProductName);

        //public Task<OpenApplicationCodeResult> SendOpenApplicationsAsync(Guid clientId, OpenApplicationBusinessModel depositApplication);



        //public Task<bool> GetCheckDepositApplicationAsync(Guid clientId, string name);        
    }
}
