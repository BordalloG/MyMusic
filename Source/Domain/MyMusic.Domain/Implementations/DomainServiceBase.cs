using MyMusic.Domain.Exceptions;
using MyMusic.Domain.Interfaces.Domain;
using MyMusic.Domain.Interfaces.Repository;
using MyMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var response = await _entityRepository.GetAllAsync();
            if (!response.Any())
                throw new NoContentException("Nenhum valor encontrado");
            return response;

        }

        public virtual async Task<TEntity> GetByIdAsync(int entityId)
        {
            var response = await _entityRepository.GetByIdAsync(entityId);
            if (response == null)
                throw new NotFoundException("Nada foi encontrado para esse Id");
            return response;
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
            var dbEntity = await this.GetByIdAsync(entityId);
            

            await _entityRepository.UpdateAsync(entity,dbEntity);
            await _entityRepository.SaveChangesAsync();
            return entity;
        }
    }
}
