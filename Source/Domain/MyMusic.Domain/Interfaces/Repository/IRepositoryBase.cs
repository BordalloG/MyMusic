using MyMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        
        Task DeleteAsync(TEntity entity);
       
        Task<TEntity> GetByIdAsync(int entityId);
       
        Task<List<TEntity>> GetAllAsync();
       
        Task InsertAsync(TEntity entity);
       
        Task UpdateAsync(TEntity entity, TEntity existent);
        
        Task SaveChangesAsync();
    }
}
