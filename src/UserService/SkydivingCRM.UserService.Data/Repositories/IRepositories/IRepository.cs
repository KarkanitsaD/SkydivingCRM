using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkydivingCRM.UserService.Data.Repositories.IRepositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetAsync(Guid id);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> RemoveAsync(TEntity entity);

        Task<List<TEntity>> GetListAsync();
    }
}