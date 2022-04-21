using System;

namespace SkydivingCRM.EmailService.Business.RabbitMq.Events.Receive
{
    public class SkydivingClubAdministratorCreatedEvent
    {
        public Guid Id { get; set; }

        public string EmailConfirmationCode { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}