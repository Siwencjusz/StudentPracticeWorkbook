using System.Net.Mail;

namespace LaboratoryHandbook.Services
{
    public interface IMailService
    {
        void setContent(EmailContent EmailContent);

        bool Send(string to);

        void Attach(Attachment item);
    }
}