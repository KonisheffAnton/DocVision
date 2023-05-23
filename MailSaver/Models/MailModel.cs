using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSaver.Models
{
    internal class MailModel
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public DateTime? Data { get; set; }

        public string Addressee { get; set; }

        public string Sender { get; set; }

        public string Content { get; set; }
    }
}
