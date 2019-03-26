using AutoMapper;
using MyMusic.Application.InOut.Filter;
using MyMusic.Application.InOut.Music;
using MyMusic.Domain.Models;
using MyMusic.Domain.Models.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Application.Mapping
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<MusicRequest, Music>();
            CreateMap<MusicFilterRequest, MusicFilter>();
            CreateMap<FilterBaseRequest, FilterBase>();
        }
    }
}
