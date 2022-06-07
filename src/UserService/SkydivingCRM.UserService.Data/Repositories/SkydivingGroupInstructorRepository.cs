using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkydivingCRM.UserService.Data.Entities;
using SkydivingCRM.UserService.Data.Repositories.IRepositories;

namespace SkydivingCRM.UserService.Data.Repositories
{
    public class SkydivingGroupInstructorRepository : Repository<SkydivingGroupInstructorEntity>, ISkydivingGroupInstructorRepository
    {
        public SkydivingGroupInstructorRepository(UserServiceContext context)
            : base(context)
        {
        }

        public async Task<SkydivingGroupInstructorEntity> GetAsync(Guid userId, Guid groupId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(gi => gi.UserId == userId && gi.GroupId == groupId);
        }
    }
}