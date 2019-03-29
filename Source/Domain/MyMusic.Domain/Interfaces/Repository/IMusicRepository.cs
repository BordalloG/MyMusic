using MyMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Domain.Interfaces.Repository
{
    public interface IMusicRepository : IRepositoryBase<Music>
    {
        Task InsertRangeAsync(List<Music> validMusics);
    }
}
