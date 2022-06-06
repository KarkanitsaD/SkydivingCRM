using System;

namespace SkydivingCRM.SkydivingClubService.Data.Entities
{
    public class SkydivingGroupEntity : Entity
    {
        public string Title { get; set; }

        public DateTime? FoundationDate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Guid SkydivingClubId { get; set; }

        public SkydivingClubEntity SkydivingClub { get; set; }
    }
}