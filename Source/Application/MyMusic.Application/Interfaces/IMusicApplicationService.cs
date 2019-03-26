using MyMusic.Application.InOut.Music;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Application.Interfaces
{
    public interface IMusicApplicationService : IApplicationServiceBase<MusicRequest,MusicResponse>
    {
    }
}
