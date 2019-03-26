using MyMusic.Domain.Interfaces.Domain;
using MyMusic.Domain.Interfaces.Repository;
using MyMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Domain.Implementations
{
    public class DomainServiceBase<TEntity> : IDomainServiceBase<TEntity> where TEntity : Entity
    {
        private readonly IRepositoryBase<TEntity> _entityRepository;
        public DomainServiceBase(IRepositoryBase<TEntity> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            await _entityRepository.DeleteAsync(entity);
            await _entityRepository.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _entityRepository.GetAllAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int entityId)
        {
            return await _entityRepository.GetByIdAsync(entityId);
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _entityRepository.InsertAsync(entity);
            await _entityRepository.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, int entityId)
        {
            entity.Id = entityId;
            await _entityRepository.UpdateAsync(entity);
            await _entityRepository.SaveChangesAsync();
            return entity;
        }
    }
}
