using MyMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Domain.Interfaces.Domain
{
    public interface IDomainServiceBase<TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// Removes the entity from the database. 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);
        /// <summary>
        /// Retrieves the entity that owns the entityId from database.
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(int entityId);
        /// <summary>
        /// Retrieves a List of entities from database.
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAllAsync();
        /// <summary>
        /// Inserts the entity into the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> InsertAsync(TEntity entity);
        /// <summary>
        /// Updates the entity that owns the entityId into the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity entity, int entityId);
    }
}
