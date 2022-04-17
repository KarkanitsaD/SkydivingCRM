using System;
using System.Threading.Tasks;
using SkydivingCRM.UserService.Data.Entities;

namespace SkydivingCRM.UserService.Data.Repositories.IRepositories
{
    public interface ISkydivingGroupInstructorRepository : IRepository<SkydivingGroupInstructorEntity>
    {
        Task<SkydivingGroupInstructorEntity> GetAsync(Guid userId, Guid groupId);
    }
}