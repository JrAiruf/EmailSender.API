using EmailSender.API.Domain.Exceptions;

namespace EmailSender.API.Domain.Entities
{
    public class EmailEntity
    {
        public EmailEntity(string receiverEmailAddress,string emailContent)
        {
            ChangeReceiverEmailAddress(receiverEmailAddress);
            ChangeEmailContent(emailContent);
        }
        public string ReceiverEmailAddress { get; private set; }
        public string EmailContent { get; private set; }

        public void ChangeReceiverEmailAddress(string receiverEmailAddress)
        {
            if (string.IsNullOrEmpty(receiverEmailAddress))
            {
                throw new EmailFormatException("Receiver address is empty. Please, set a valid e-mail address.");
            }
            ReceiverEmailAddress = receiverEmailAddress;
        }

        public void ChangeEmailContent(string emailContent)
        {
            if (string.IsNullOrEmpty(emailContent))
            {
                throw new EmailFormatException("The current e-mail has no content.");
            }
            EmailContent = emailContent;
        }
    }
}
