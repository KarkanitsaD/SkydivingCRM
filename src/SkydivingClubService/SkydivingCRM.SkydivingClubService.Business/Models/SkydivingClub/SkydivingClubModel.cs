using System;
using System.Collections.Generic;
using SkydivingCRM.SkydivingClubService.Business.Models.SkydivingGroup;

namespace SkydivingCRM.SkydivingClubService.Business.Models.SkydivingClub
{
    public class SkydivingClubModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public DateTime? FoundationDate { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public List<SkydivingGroupModel> SkydivingGroups { get; set; }
    }
}