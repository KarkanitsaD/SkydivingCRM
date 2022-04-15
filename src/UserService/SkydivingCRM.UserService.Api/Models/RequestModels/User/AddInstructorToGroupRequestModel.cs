using System;

namespace SkydivingCRM.UserService.Api.Models.RequestModels.User
{
    public class AddInstructorToGroupRequestModel
    {
        public Guid UserId { get; set; }

        public Guid GroupId { get; set; }

        public DateTimeOffset FormationDate { get; set; }
    }
}