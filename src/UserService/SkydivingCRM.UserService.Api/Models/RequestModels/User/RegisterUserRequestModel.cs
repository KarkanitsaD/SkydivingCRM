using System;

namespace SkydivingCRM.UserService.Api.Models.RequestModels.User
{
    public class RegisterUserRequestModel
    {
        public Guid SkydivingClubId { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public DateTime? StartDate { get; set; }
    }
}