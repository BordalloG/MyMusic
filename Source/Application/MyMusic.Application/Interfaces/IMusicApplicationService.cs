using MyMusic.Application.InOut.Filter;
using MyMusic.Application.InOut.Music;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Application.Interfaces
{
    public interface IMusicApplicationService : IApplicationServiceBase<MusicRequest,MusicResponse>
    {
        Task<List<MusicResponse>> GetAllAsync(MusicFilterRequest filter);
        Task<string> GetTracksFromSpotify(string url);
        Task<List<MusicResponse>> InsertRangeAsync(List<MusicRequest> musicRequest);
    }
}
