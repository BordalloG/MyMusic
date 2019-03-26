using Microsoft.EntityFrameworkCore;
using MyMusic.Domain.Interfaces.Repository;
using MyMusic.Domain.Models;
using MyMusic.Infrastructure.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Infrastructure.Repository.Implementation
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        protected DbSet<TEntity> DbSet;
        protected MyMusicContext DbContext;

        public RepositoryBase(MyMusicContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }
        public virtual Task DeleteAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            var objList = await DbSet.ToListAsync();
            return objList;
        }

        public virtual async Task<TEntity> GetByIdAsync(int entityId)
        {
            return await DbSet.FindAsync(entityId).ConfigureAwait(false);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity).ConfigureAwait(false);
        }

        public virtual async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
