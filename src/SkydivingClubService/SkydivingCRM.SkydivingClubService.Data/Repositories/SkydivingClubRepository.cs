using SkydivingCRM.SkydivingClubService.Data.Entities;
using SkydivingCRM.SkydivingClubService.Data.Repositories.IRepositories;

namespace SkydivingCRM.SkydivingClubService.Data.Repositories
{
    public class SkydivingClubRepository : Repository<SkydivingClubEntity>, ISkydivingClubRepository
    {
        public SkydivingClubRepository(SkydivingClubContext context) 
            : base(context)
        {
        }
    }
}