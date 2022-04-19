using System;

namespace SkydivingCRM.SkydivingClubService.Api.Models.RequestModels.SkydivingClub
{
    public class RegisterSkydivingClubRequestModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public DateTimeOffset FoundationDate { get; set; }

        public DateTimeOffset RegistrationDate { get; set; }

        public Guid CityId { get; set; }

        public string DirectorLogin { get; set; }

        public string DirectorName { get; set; }

        public string DirectorSurname { get; set; }

        public string DirectorPatronymic { get; set; }

        public string DirectorEmail { get; set; }

        public string DirectorPassword { get; set; }
    }
}