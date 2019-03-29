using MyMusic.Domain.Models;
using MyMusic.Domain.Models.Filter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Domain.Interfaces.Domain
{
    public interface IMusicDomainService : IDomainServiceBase<Music>
    {
        Task<List<Music>> GetAllAsync(MusicFilter filter);
        Task<List<Music>> InsertRangeAsync(List<Music> domainMusicList);
    }
}
