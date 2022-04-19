using SkydivingCRM.UserService.Business.Models.User;

namespace SkydivingCRM.UserService.Business.RabbitMq.Events.Receive
{
    public class SkydivingClubCreatedEvent
    {
        public UserModel User { get; set; }

        public string Password { get; set; }
    }
}