namespace Hackaton.Infra.Messaging.Models
{
    public class EmailMessage
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
