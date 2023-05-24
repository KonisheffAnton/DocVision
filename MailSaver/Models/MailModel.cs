using System;
using System.ComponentModel;

namespace MailSaver.Models
{
    internal class MailModel:IDataErrorInfo
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public DateTime? Data { get; set; }

        public string Addressee { get; set; }

        public string Sender { get; set; }

        public string Content { get; set; }

        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch (columnName)
                {
                    case nameof(Name):
                        if (string.IsNullOrEmpty(Name))
                            error = "Name is required.";
                        break;
                    case nameof(Addressee):
                        if (string.IsNullOrEmpty(Addressee))
                            error = "Addressee is required.";
                        break;
                    case nameof(Sender):
                        if (string.IsNullOrEmpty(Sender))
                            error = "Sender is required.";
                        break;
                    default:
                        break;
                }
                return error;
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }

}
