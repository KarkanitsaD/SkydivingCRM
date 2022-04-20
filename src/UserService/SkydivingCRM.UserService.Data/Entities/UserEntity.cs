using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SkydivingCRM.UserService.Data.Entities
{
    public class UserEntity : IdentityUser<Guid>
    {
        public Guid SkydivingClubId { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Phone { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? DateOfRegistration { get; set; }

        public List<SkydivingGroupSportsmanEntity> SkydivingGroupsAsSportsman { get; set; }

        public List<SkydivingGroupInstructorEntity> SkydivingGroupsAsInstructor { get; set; }
    }
}