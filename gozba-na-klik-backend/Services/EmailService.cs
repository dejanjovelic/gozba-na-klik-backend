using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace gozba_na_klik_backend.Services
{
    public class EmailService : IEmailService
    {
        //Izvucena konfiguracija iz appsettings u EmailSettings
        //Lakse za implementaciju laznog mocka 
        //var options = Options.Create(new EmailSettings { From = "test@test.com" });

        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var smtp = new SmtpClient
            {
                Host = _emailSettings.SmtpHost,
                Port = _emailSettings.SmtpPort,
                EnableSsl = true,
                Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password)
            };

            var message = new MailMessage
            {
                From = new MailAddress(_emailSettings.From),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            message.To.Add(to);

            await smtp.SendMailAsync(message);
        }


    }
}
