using MyMusic.Domain.Interfaces.Repository;
using MyMusic.Domain.Models;
using MyMusic.Infrastructure.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Infrastructure.Repository.Implementation
{
    public class MusicRepository : RepositoryBase<Music>, IMusicRepository
    {
        public MusicRepository(MyMusicContext dbContext) : base(dbContext)
        {
        }
    }
}
