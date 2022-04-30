using SkydivingCRM.SkydivingClubService.Data.Entities;
using SkydivingCRM.SkydivingClubService.Data.Repositories.IRepositories;

namespace SkydivingCRM.SkydivingClubService.Data.Repositories
{
    public class StockRepository : Repository<StockEntity>, IStockRepository
    {
        public StockRepository(SkydivingClubContext context)
            : base(context)
        {
        }
    }
}