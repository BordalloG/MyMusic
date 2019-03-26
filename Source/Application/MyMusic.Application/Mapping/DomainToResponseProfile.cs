using AutoMapper;
using MyMusic.Application.InOut.Music;
using MyMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Application.Mapping
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Music,MusicResponse>();
        }
    }
}
