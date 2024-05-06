namespace EmailSender.API.Dtos
{
    public record SendEmailDto
    {
        public string SenderEmailAddress { get; init; }
        public string ReceiverEmailAddress { get; init; }
        public string SenderName { get; init; }
        public string ReceiverName { get; init; }
        public string EmailSubject { get; init; }
        public string EmailContent { get; init; }
    }
}
