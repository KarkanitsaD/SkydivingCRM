using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkydivingCRM.UserService.Data.Repositories.IRepositories;

namespace SkydivingCRM.UserService.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private readonly UserServiceContext _context;

        private readonly DbSet<TEntity> _dbSet;

        public Repository(UserServiceContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var createdEntity = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updatedEntity = _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return updatedEntity.Entity;
        }

        public async Task<TEntity> RemoveAsync(TEntity entity)
        {
            var removedEntity = _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return removedEntity.Entity;
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}