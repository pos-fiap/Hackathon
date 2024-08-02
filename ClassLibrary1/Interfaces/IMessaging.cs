using Hackaton.Infra.Messaging.Models;

namespace Hackaton.Infra.Messaging.Interfaces
{
    public interface IMessaging
    {
        public Task SendMail(EmailMessage email);
    }
}