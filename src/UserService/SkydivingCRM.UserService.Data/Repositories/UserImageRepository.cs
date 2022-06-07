using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkydivingCRM.UserService.Data.Entities;
using SkydivingCRM.UserService.Data.Repositories.IRepositories;

namespace SkydivingCRM.UserService.Data.Repositories
{
    public class UserImageRepository : Repository<UserImageEntity>, IUserImageRepository
    {
        public UserImageRepository(UserServiceContext context) : base(context)
        {
        }

        public async Task<Guid> GetIdByUserIdAsync(Guid userId)
        {
            return await DbSet.Where(i => i.UserId == userId).Select(i => i.Id).SingleOrDefaultAsync();
        }
    }
}