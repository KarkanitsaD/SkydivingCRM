using System;

namespace SkydivingCRM.SkydivingClubService.Business.Models.User
{
    public class UserModel
    {
        public Guid SkydivingClubId { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }
    }
}