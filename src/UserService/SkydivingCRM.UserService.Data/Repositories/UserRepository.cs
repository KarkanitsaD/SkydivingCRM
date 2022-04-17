using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkydivingCRM.UserService.Data.Entities;
using SkydivingCRM.UserService.Data.Repositories.IRepositories;

namespace SkydivingCRM.UserService.Data.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(UserServiceContext context) 
            : base(context)
        {
        }

        public async Task<UserEntity> GetByLoginAsync(string login)
        {
            return await DbSet.FirstOrDefaultAsync(u => u.Login == login);
        }
    }
}