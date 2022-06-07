using System;

namespace SkydivingCRM.UserService.Api.Models.RequestModels.User
{
    public class SetUserImageRequestModel
    {
        public Guid UserId { get; set; }

        public string Base64 { get; set; }
    }
}