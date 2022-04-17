using System.Threading.Tasks;
using SkydivingCRM.UserService.Data.Entities;

namespace SkydivingCRM.UserService.Data.Repositories.IRepositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> GetByLoginAsync(string login);
    }
}