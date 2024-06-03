using EmailSender.API.Data.Interfaces;
using EmailSender.API.Domain.Entities;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EmailSender.API.Data.Services
{
    public class EmailService : IEmailService
    {
        private readonly string API_KEY = Environment.GetEnvironmentVariable("API_KEY") ?? "";

        public async Task<Response> SendEmail(EmailEntity email)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress(email.SenderEmailAddress, email.SenderName);
            var subject = email.EmailSubject;
            var to = new EmailAddress(email.ReceiverEmailAddress, email.ReceiverName);
            var plainTextContent = email.EmailContent;
            var htmlContent = $"<strong>{email.EmailContent}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return response;
        }
    }
}