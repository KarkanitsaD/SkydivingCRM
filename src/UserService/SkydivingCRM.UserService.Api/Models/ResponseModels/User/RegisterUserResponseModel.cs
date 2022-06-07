using System;

namespace SkydivingCRM.UserService.Api.Models.ResponseModels.User
{
    public class RegisterUserResponseModel
    {
        public Guid Id { get; set; }

        public Guid SkydivingClubId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Phone { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DateOfRegistration { get; set; }
    }
}