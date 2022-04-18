using System;
using System.Collections.Generic;

namespace SkydivingCRM.SkydivingClubService.Data.Entities
{
    public class CityEntity : Entity
    {
        public string Title { get; set; }

        public Guid CountryId { get; set; }

        public CountryEntity Country { get; set; }

        public List<SkydivingClubEntity> SkydivingClubs { get; set; }
    }
}