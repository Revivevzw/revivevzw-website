using Microsoft.Extensions.Configuration;
using Revivevzw.DataContracts;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Revivevzw.Business.Services
{
    public class MailService : IMailService
    {
        private readonly string emailFrom;
        private readonly string emailTo;
        private readonly string host;
        private readonly int port;
        private readonly string username;
        private readonly string password;

        public MailService(IConfiguration configuration)
        {
            var smtpSection = configuration.GetSection("smtp");
            this.emailFrom = smtpSection.GetValue<string>("emailFrom");
            this.emailTo = smtpSection.GetValue<string>("emailTo");
            this.host = smtpSection.GetValue<string>("host");
            this.username = smtpSection.GetValue<string>("username");
            this.password = smtpSection.GetValue<string>("password");
            this.port = smtpSection.GetValue<int>("port");
        }

        public async Task Send(Mail mail)
        {
            if (mail is null) throw new ArgumentNullException(nameof(mail));
            var message = CreateEmail(mail);
            await Send(message);
        }

        private MailMessage CreateEmail(Mail mail)
        {
            var message = new MailMessage()
            {
                Sender = new MailAddress(mail.EmailFrom),
                Subject = mail.Subject,
                Body = mail.Message
            };

            message.ReplyToList.Add(new MailAddress(mail.EmailFrom));

            return message;
        }

        private async Task Send(MailMessage message)
        {
            message.To.Add(this.emailTo);
            message.From = new MailAddress(this.emailFrom);

            using (var smtp = new SmtpClient())
            {
                smtp.Host = this.host;
                smtp.Port = this.port;
                smtp.Credentials = new NetworkCredential(this.username, this.password);
                await smtp.SendMailAsync(message);
            }
        }
    }
}
