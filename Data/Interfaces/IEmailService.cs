using EmailSender.API.Domain.Entities;
using SendGrid;

namespace EmailSender.API.Data.Interfaces
{
    public interface IEmailService
    {
        public Task<Response> SendEmail(EmailEntity email);
    }
}
