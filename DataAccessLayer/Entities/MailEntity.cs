using DocVision.Core.Interfaces;

namespace DocVision.DataAccessLayer.Entities
{
    public class MailEntity : IEntityBase
    {
        public Guid? Id { get; set; }

        public string Name { get; set;}

        public DateTime Data { get; set; }

        public string Addressee { get; set; }

        public string Sender {get ; set; }

        public string Content { get; set; }

    }
}
