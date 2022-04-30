using System;

namespace SkydivingCRM.SkydivingClubService.Api.Models.RequestModels.SkydivingClub
{
    public class UpdateSkydivingClubRequestModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public DateTimeOffset? FoundationDate { get; set; }
    }
}