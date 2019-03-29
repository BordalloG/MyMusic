using AutoMapper;
using MyMusic.Application.InOut.Filter;
using MyMusic.Application.InOut.Helper.Spotify;
using MyMusic.Application.InOut.Music;
using MyMusic.Application.Interfaces;
using MyMusic.Domain.Interfaces.Domain;
using MyMusic.Domain.Models;
using MyMusic.Domain.Models.Filter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Application.Implementation
{
    public class MusicApplicationService : ApplicationServiceBase<Music, MusicRequest, MusicResponse>, IMusicApplicationService
    {
        private readonly IMusicDomainService _musicServiceBase;
        private readonly IMapper _mapper;
        private readonly IHttpClientHelperDomainService _httpHelper;
        public MusicApplicationService(IMapper mapper, IMusicDomainService domainServiceBase, IHttpClientHelperDomainService httpHelper) : base(mapper, domainServiceBase)
        {
            _musicServiceBase = domainServiceBase;
            _mapper = mapper;
            _httpHelper = httpHelper;
        }

        public async Task<List<MusicResponse>> GetAllAsync(MusicFilterRequest filter)
        {
            var response = await _musicServiceBase.GetAllAsync(_mapper.Map<MusicFilter>(filter));
            return _mapper.Map<List<MusicResponse>>(response);
        }

        public async Task<string> GetTracksFromSpotify(string url)
        {
             return await _httpHelper.HttpGet(url);
        }

        public async Task<List<MusicResponse>> InsertRangeAsync(List<MusicRequest> musicRequest)
        {
            var domainMusicList = _mapper.Map<List<Music>>(musicRequest);
            var response = await _musicServiceBase.InsertRangeAsync(domainMusicList);
            return _mapper.Map<List<MusicResponse>>(response);
        }
    }
}
