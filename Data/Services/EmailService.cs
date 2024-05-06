using EmailSender.API.Data.Interfaces;
using EmailSender.API.Domain.Entities;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EmailSender.API.Data.Services
{
    public class EmailService : IEmailService
    {
        //private readonly string API_KEY = Environment.GetEnvironmentVariable("API_KEY");
        //private readonly string DOMAIN = Environment.GetEnvironmentVariable("DOMAIN");
        //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

        public async Task<Response> SendEmail(EmailEntity email)
        {

            var apiKey = "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";
            var client = new SendGridClient(apiKey);
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