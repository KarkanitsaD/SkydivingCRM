using SkydivingCRM.EmailService.Business.Models;

namespace SkydivingCRM.EmailService.Business.Services.IServices
{
    public interface IEmailService
    {
        void Send(Message message);
    }
}