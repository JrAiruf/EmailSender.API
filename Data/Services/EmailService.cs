using EmailSender.API.Data.Interfaces;
using EmailSender.API.Domain.Entities;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EmailSender.API.Data.Services
{
    public class EmailService : IEmailService
    {
        private readonly string API_KEY = Environment.GetEnvironmentVariable("SEND_EMAIL_API_KEY");
        //private readonly string DOMAIN = Environment.GetEnvironmentVariable("DOMAIN");
        //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

        public async Task<Response> SendEmail(EmailEntity email)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress(email.SenderEmailAddress, email.SenderName);
            var subject = email.EmailSubject;
            var to = new EmailAddress(email.ReceiverEmailAddress, email.ReceiverName);
            var plainTextContent = email.EmailSubject;
            var htmlContent = email.EmailContent;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return response;
        }
    }
}


