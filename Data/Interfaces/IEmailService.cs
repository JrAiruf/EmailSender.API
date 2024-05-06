using EmailSender.API.Domain.Entities;

namespace EmailSender.API.Data.Interfaces
{
    public interface IEmailService
    {
        public void SendEmail(EmailEntity email);
    }
}
