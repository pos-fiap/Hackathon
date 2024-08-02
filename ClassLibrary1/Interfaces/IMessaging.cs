using Hackathon.Infra.Messaging.Models;

namespace Hackathon.Infra.Messaging.Interfaces
{
    public interface IMessaging
    {
        public Task SendMail(EmailMessage email);
    }
}