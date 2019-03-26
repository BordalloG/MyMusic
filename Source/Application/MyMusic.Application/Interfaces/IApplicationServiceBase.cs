using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Application.Interfaces
{
    public interface IApplicationServiceBase<TEntityRequest, TEntityResponse>
        where TEntityRequest : class
        where TEntityResponse : class
    {
        Task<TEntityResponse> InsertAsync(TEntityRequest entity);
        Task<List<TEntityResponse>> GetAllAsync();
        Task<TEntityResponse> GetByIdAsync(int entityId);
        Task<TEntityResponse> UpdateAsync(int entityId, TEntityRequest entity);
        Task DeleteAsync(int entityId);
    }
}
