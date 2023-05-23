using DocVision.Core.Interfaces;

namespace DocVision.DataAccessLayer.Entities
{
    public class AccountEntity : IEntityBase
    {
        public Guid? Id { get; set; }

        public string AccountNumber { get; set; }

        public Guid AgreementId { get; set; }

        public decimal CurrentBalance { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime CloseDate { get; set; }

    }
}
