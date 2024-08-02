using Hackathon.Infra.Messaging.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Hackathon.Infra.Messaging.Services
{
    public class EmailService(IConfiguration configuration)
    {
        public async Task SendEmail(EmailMessage email)
        {
            var mimeMessage = new MimeMessage();

            var emailHost = configuration.GetSection("EmailConfiguration:EmailHost").Value ?? throw new ArgumentNullException("EmailHost não configurado!");
            var emailHostPassword = configuration.GetSection("EmailConfiguration:EmailHostPassword").Value ?? throw new ArgumentNullException("EmailHostPassword não configurado!");


            mimeMessage.From.Add(MailboxAddress.Parse(email.From));
            mimeMessage.To.Add(MailboxAddress.Parse(email.To));
            mimeMessage.Subject = email.Subject;
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = email.Message };
            var smtp = new SmtpClient();

            await smtp.ConnectAsync("smtp-mail.outlook.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(emailHost, emailHostPassword);
            await smtp.SendAsync(mimeMessage);
            await smtp.DisconnectAsync(true);
            smtp.Dispose();
        }
    }
}