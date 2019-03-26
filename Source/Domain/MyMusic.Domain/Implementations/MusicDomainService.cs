using MyMusic.Domain.Interfaces.Domain;
using MyMusic.Domain.Interfaces.Repository;
using MyMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Domain.Implementations
{
    public class MusicDomainService : DomainServiceBase<Music>, IMusicDomainService
    {
        public MusicDomainService(IMusicRepository entityRepository) : base(entityRepository)
        {
        }
    }
}
