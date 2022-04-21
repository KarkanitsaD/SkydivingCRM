using System;
using MailKit.Net.Smtp;
using MimeKit;
using SkydivingCRM.EmailService.Business.Models;
using SkydivingCRM.EmailService.Business.Options;
using SkydivingCRM.EmailService.Business.Services.IServices;

namespace SkydivingCRM.EmailService.Business.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailOptions _emailOptions;

        public EmailService(EmailOptions emailOptions)
        {
            _emailOptions = emailOptions;
        }

        public void Send(Message message)
        {
            var emailMessage = CreateMimeMessage(message);

            Send(emailMessage);
        }


        private MimeMessage CreateMimeMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailOptions.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };

            return emailMessage;
        }

        private void Send(MimeMessage message)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_emailOptions.SmtpServer, _emailOptions.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailOptions.UserName, _emailOptions.Password);

                client.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}