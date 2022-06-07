using System;

namespace SkydivingCRM.SkydivingClubService.Api.Models.RequestModels.SkydivingClub
{
    public class RegisterSkydivingClubRequestModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public DateTime? FoundationDate { get; set; }

        public string ClubAdministratorLogin { get; set; }

        public string ClubAdministratorName { get; set; }

        public string ClubAdministratorSurname { get; set; }

        public string ClubAdministratorPatronymic { get; set; }

        public string ClubAdministratorEmail { get; set; }

        public string ClubAdministratorPassword { get; set; }
    }
}