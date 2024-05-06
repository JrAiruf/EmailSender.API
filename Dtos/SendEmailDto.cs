namespace EmailSender.API.Dtos
{
    public record SendEmailDto
    {
        public string ReceiverEmailAddress { get; init; }
        public string EmailContent { get; init; }
    }
}
