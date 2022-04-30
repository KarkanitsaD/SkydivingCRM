using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkydivingCRM.SkydivingClubService.Data.Repositories.IRepositories;

namespace SkydivingCRM.SkydivingClubService.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SkydivingClubContext Context;

        protected readonly DbSet<TEntity> DbSet;

        public Repository(SkydivingClubContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var createdEntity = await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updatedEntity = DbSet.Update(entity);
            await Context.SaveChangesAsync();
            return updatedEntity.Entity;
        }

        public async Task<TEntity> RemoveAsync(TEntity entity)
        {
            var removedEntity = DbSet.Remove(entity);
            await Context.SaveChangesAsync();
            return removedEntity.Entity;
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            return await DbSet.ToListAsync();
        }
    }
}