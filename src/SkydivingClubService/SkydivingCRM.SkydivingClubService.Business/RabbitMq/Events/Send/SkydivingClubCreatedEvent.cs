using SkydivingCRM.SkydivingClubService.Business.Models.User;

namespace SkydivingCRM.SkydivingClubService.Business.RabbitMq.Events.Send
{
    public class SkydivingClubCreatedEvent
    {
        public SkydivingClubCreatedEvent(UserModel user, string password)
        {
            User = user;
            Password = password;
        }

        public UserModel User { get; set; }

        public string Password { get; set; }
    }
}