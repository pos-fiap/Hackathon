using Hackaton.Infra.Messaging.Interfaces;
using Hackaton.Infra.Messaging.Models;
using Microsoft.Extensions.Configuration;

namespace Hackaton.Infra.Messaging.Services
{
    public class MessagingService : IMessaging
    {
        private readonly IConfiguration _configuration;
        public MessagingService(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public async Task SendMail(EmailMessage email)
        {
            var emailService = new EmailService(_configuration);
            await emailService.SendEmail(email);
        }
    }
}
