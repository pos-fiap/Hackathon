using Hackathon.Infra.Messaging.Models;

namespace Hackathon.Infra.Messaging.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmail(EmailMessage email);
    }
}