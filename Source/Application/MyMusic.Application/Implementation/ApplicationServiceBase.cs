using AutoMapper;
using MyMusic.Application.Interfaces;
using MyMusic.Domain.Interfaces.Domain;
using MyMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Application.Implementation
{
    public class ApplicationServiceBase<TEntity, TEntityRequest, TEntityResponse> : IApplicationServiceBase<TEntityRequest, TEntityResponse>
       where TEntity : Entity
        where TEntityRequest : class
        where TEntityResponse : class
    {
        private readonly IMapper _mapper;
        private readonly IDomainServiceBase<TEntity> _domainServiceBase;

        public ApplicationServiceBase(IMapper mapper, IDomainServiceBase<TEntity> domainServiceBase)
        {
            _mapper = mapper;
            _domainServiceBase = domainServiceBase;
        }

        public async Task DeleteAsync(int entityId)
        {
            var entity = await _domainServiceBase.GetByIdAsync(entityId);
            await _domainServiceBase.DeleteAsync(entity);
        }

        public async Task<List<TEntityResponse>> GetAllAsync()
        {
            return _mapper.Map<List<TEntityResponse>>(await _domainServiceBase.GetAllAsync());
        }

        public async Task<TEntityResponse> GetByIdAsync(int entityId)
        {
            return _mapper.Map<TEntityResponse>(await _domainServiceBase.GetByIdAsync(entityId));
        }

        public async Task<TEntityResponse> InsertAsync(TEntityRequest entityRequest)
        {

            var entity = _mapper.Map<TEntity>(entityRequest);
            var entityInserted = await _domainServiceBase.InsertAsync(entity);
            var entityResponse = _mapper.Map<TEntityResponse>(entityInserted);

            return entityResponse;
        }

        public async Task<TEntityResponse> UpdateAsync(int entityId, TEntityRequest entityRequest)
        {
            var newEntity = _mapper.Map<TEntity>(entityRequest);
            return _mapper.Map<TEntityResponse>(await _domainServiceBase.UpdateAsync(newEntity, entityId));
        }
    }
}
