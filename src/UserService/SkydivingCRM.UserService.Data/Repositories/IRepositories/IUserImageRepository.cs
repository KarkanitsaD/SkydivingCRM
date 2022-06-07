using System;
using System.Threading.Tasks;
using SkydivingCRM.UserService.Data.Entities;

namespace SkydivingCRM.UserService.Data.Repositories.IRepositories
{
    public interface IUserImageRepository : IRepository<UserImageEntity>
    {
        Task<Guid> GetIdByUserIdAsync(Guid userId);
    }
}