using System.Collections.Generic;
using System.Linq;
using MimeKit;

namespace SkydivingCRM.EmailService.Business.Models
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public Message(List<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(m => new MailboxAddress(m)));
            Subject = subject;
            Content = content;
        }
    }
}