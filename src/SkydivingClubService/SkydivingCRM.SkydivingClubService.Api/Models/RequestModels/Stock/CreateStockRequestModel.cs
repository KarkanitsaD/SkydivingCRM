using System;

namespace SkydivingCRM.SkydivingClubService.Api.Models.RequestModels.Stock
{
    public class CreateStockRequestModel
    {
        public Guid SkydivingClubId { get; set; }

        public string Title { get; set; }
    }
}