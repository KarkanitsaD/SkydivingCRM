using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using SkydivingCRM.UserService.Business.Services.IServices;

namespace SkydivingCRM.UserService.Business.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("aakarkanica@gmail.com", "hotel.reservation.system.test2@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;

            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 465, true);
            await client.AuthenticateAsync("hotel.reservation.system.test2@gmail.com", "Testtest1");
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }
}