using AutoMapper;
using MyMusic.Application.InOut.Music;
using MyMusic.Domain.Models;
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
        }
    }
}
