using System;
using System.Threading.Tasks;
using SkydivingCRM.UserService.Data.Entities;

namespace SkydivingCRM.UserService.Data.Repositories.IRepositories
{
    public interface ISkydivingGroupSportsmanRepository : IRepository<SkydivingGroupSportsmanEntity>
    {
        Task<SkydivingGroupSportsmanEntity> GetAsync(Guid userId, Guid groupId);
    }
}