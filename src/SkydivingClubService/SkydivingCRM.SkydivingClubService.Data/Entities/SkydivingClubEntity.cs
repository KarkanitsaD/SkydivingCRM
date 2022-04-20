using System;
using System.Collections.Generic;

namespace SkydivingCRM.SkydivingClubService.Data.Entities
{
    public class SkydivingClubEntity : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public DateTimeOffset? FoundationDate { get; set; }

        public DateTimeOffset? RegistrationDate { get; set; }

        public Guid CityId { get; set; }

        public CityEntity City { get; set; }

        public List<SkydivingGroupEntity> SkydivingGroups { get; set; }
    }
}