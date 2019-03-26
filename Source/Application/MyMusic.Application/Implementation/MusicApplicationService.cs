using AutoMapper;
using MyMusic.Application.InOut.Filter;
using MyMusic.Application.InOut.Music;
using MyMusic.Application.Interfaces;
using MyMusic.Domain.Interfaces.Domain;
using MyMusic.Domain.Models;
using MyMusic.Domain.Models.Filter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Application.Implementation
{
    public class MusicApplicationService : ApplicationServiceBase<Music, MusicRequest, MusicResponse>, IMusicApplicationService
    {
        private readonly IMusicDomainService _domainServiceBase;
        private readonly IMapper _mapper;
        public MusicApplicationService(IMapper mapper, IMusicDomainService domainServiceBase) : base(mapper, domainServiceBase)
        {
            _domainServiceBase = domainServiceBase;
            _mapper = mapper;
        }

        public async Task<List<MusicResponse>> GetAllAsync(MusicFilterRequest filter)
        {
            var response = await _domainServiceBase.GetAllAsync(_mapper.Map<MusicFilter>(filter));
            return _mapper.Map<List<MusicResponse>>(response);
        }
    }
}
