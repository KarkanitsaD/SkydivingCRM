using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkydivingCRM.UserService.Data.Entities;
using SkydivingCRM.UserService.Data.Repositories.IRepositories;

namespace SkydivingCRM.UserService.Data.Repositories
{
    public class SkydivingGroupSportsmanRepository : Repository<SkydivingGroupSportsmanEntity>, ISkydivingGroupSportsmanRepository
    {
        public SkydivingGroupSportsmanRepository(UserServiceContext context) 
            : base(context)
        {
        }

        public async Task<SkydivingGroupSportsmanEntity> GetAsync(Guid userId, Guid groupId)
        {
            return await DbSet.FirstOrDefaultAsync(gi => gi.UserId == userId && gi.GroupId == groupId);
        }
    }
}