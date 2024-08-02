using Hackaton.Infra.Messaging.Models;

namespace Hackaton.Infra.Messaging.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmail(EmailMessage email);
    }
}