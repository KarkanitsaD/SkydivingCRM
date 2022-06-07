using System;

namespace SkydivingCRM.SkydivingClubService.Business.Models.SkydivingGroup
{
    public class SkydivingGroupModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime? FoundationDate { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public Guid SkydivingClubId { get; set; }
    }
}