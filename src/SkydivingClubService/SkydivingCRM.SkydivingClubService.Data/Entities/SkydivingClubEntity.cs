using System;
using System.Collections.Generic;

namespace SkydivingCRM.SkydivingClubService.Data.Entities
{
    public class SkydivingClubEntity : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public DateTime? FoundationDate { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public List<SkydivingGroupEntity> SkydivingGroups { get; set; }

        public List<StockEntity> Stocks { get; set; }
    }
}