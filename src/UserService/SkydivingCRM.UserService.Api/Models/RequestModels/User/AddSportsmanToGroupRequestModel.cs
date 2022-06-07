using System;

namespace SkydivingCRM.UserService.Api.Models.RequestModels.User
{
    public class AddSportsmanToGroupRequestModel
    {
        public Guid UserId { get; set; }

        public Guid GroupId { get; set; }

        public DateTime FormationDate { get; set; }
    }
}