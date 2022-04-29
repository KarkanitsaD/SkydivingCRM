using System;

namespace SkydivingCRM.SkydivingClubService.Api.Models.RequestModels.Stock
{
    public class UpdateStockRequestModel
    {
        public Guid SkydivingClubId { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }
    }
}