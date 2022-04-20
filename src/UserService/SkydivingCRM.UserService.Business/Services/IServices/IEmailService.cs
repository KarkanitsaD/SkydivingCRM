using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace SkydivingCRM.UserService.Business.Services.IServices
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}