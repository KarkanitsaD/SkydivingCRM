﻿using System;

namespace SkydivingCRM.SkydivingClubService.Business.Models.City
{
    public class CityModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Guid CountryId { get; set; }
    }
}