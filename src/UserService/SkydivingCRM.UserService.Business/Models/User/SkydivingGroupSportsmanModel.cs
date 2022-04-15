using System;

namespace SkydivingCRM.UserService.Business.Models.User
{
    public class SkydivingGroupSportsmanModel
    {
        public Guid UserId { get; set; }

        public Guid GroupId { get; set; }

        public DateTimeOffset? FormationDate { get; set; }
    }
}