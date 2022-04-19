using System;
using System.Collections.Generic;
using SkydivingCRM.SkydivingClubService.Business.Models.City;
using SkydivingCRM.SkydivingClubService.Business.Models.SkydivingGroup;

namespace SkydivingCRM.SkydivingClubService.Business.Models.SkydivingClub
{
    public class SkydivingClubModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public DateTimeOffset FoundationDate { get; set; }

        public DateTimeOffset RegistrationDate { get; set; }

        public Guid CityId { get; set; }

        public CityModel City { get; set; }

        public List<SkydivingGroupModel> SkydivingGroups { get; set; }
    }
}