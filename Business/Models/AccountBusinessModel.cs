using DocVision.Core.Interfaces;

namespace DocVision.Business.Models
{
    public class AccountBusinessModel : IEntityBase
    {
        public Guid? Id { get; set; }

        public string AccountNumber { get; set; }

        public Guid AgreementId { get; set; }

        public decimal CurrentBalance { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime CloseDate { get; set; }

    }
}
