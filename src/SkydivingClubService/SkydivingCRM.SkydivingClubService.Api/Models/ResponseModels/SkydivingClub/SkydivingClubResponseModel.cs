using System;

namespace SkydivingCRM.SkydivingClubService.Api.Models.ResponseModels.SkydivingClub
{
    public class SkydivingClubResponseModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public DateTimeOffset? FoundationDate { get; set; }

        public DateTimeOffset? RegistrationDate { get; set; }

        public Guid CityId { get; set; }
    }
}