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
    }
}