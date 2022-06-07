using System;
using System.Collections.Generic;

namespace SkydivingCRM.UserService.Business.Models.User
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public Guid SkydivingClubId { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DateOfRegistration { get; set; }

        public List<string> Roles { get; set; }
    }
}