using System;
using System.Collections.Generic;

namespace SkydivingCRM.SkydivingClubService.Data.Entities
{
    public class CountryEntity : Entity
    {
        public Guid Title { get; set; }

        public List<CityEntity> Cities { get; set; }
    }
}