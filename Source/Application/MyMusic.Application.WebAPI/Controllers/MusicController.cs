using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Application.InOut;
using MyMusic.Application.InOut.Filter;
using MyMusic.Application.InOut.Music;
using MyMusic.Application.Interfaces;

namespace MyMusic.Application.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicApplicationService _appService;
        public MusicController(IMusicApplicationService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// Retrieves a List of Music
        /// </summary>
        /// <returns></returns>

        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [Route("GetAll")]
        [HttpPost]
        public async Task<IActionResult> GetAll(MusicFilterRequest filter)
        {
            var expenseTypeResponse = await _appService.GetAllAsync(filter);
           
            return Ok(expenseTypeResponse);
        }

        /// <summary>
        /// Retrieves a Music by Id
        /// </summary>
        /// <returns></returns>

        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [Route("{entityId}")]
        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] int entityId)
        {
            var music = await _appService.GetByIdAsync(entityId);
            return Ok(music);
        }

        /// <summary>
        /// Inserts a new Music
        /// </summary>
        /// <param name="musicRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> InsertMusicAsync([FromBody]MusicRequest musicRequest)
        {
            var musicResponse = await _appService.InsertAsync(musicRequest);
            return Created("", musicResponse );
            
        }

        /// <summary>
        /// Inserts a  Ranger of new Music
        /// </summary>
        /// <param name="musicRequest"></param>
        /// <returns></returns>
        [Route("PostRange")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> InsertRangeMusicAsync([FromBody]List<MusicRequest> musicRequest)
        {
            var musicResponse = await _appService.InsertRangeAsync(musicRequest);
            return Created("", musicResponse);

        }

        /// <summary>
        /// Remove a Music
        /// </summary>
        /// <param name="musicId"></param>
        /// <returns></returns>
        [Route("{musicId}")]
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteMusicAsync([FromRoute] int musicId)
        {
            await _appService.DeleteAsync(musicId);
            return Ok();
        }
        /// <summary>
        /// Update a Music 
        /// </summary>
        /// <param name="musicId"></param>
        /// <param name="music"></param>
        /// <returns></returns>
        [Route("{musicId}")]
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateMusicAsync([FromRoute] int musicId, [FromBody] MusicRequest music)
        {
            var resopnse = await _appService.UpdateAsync(musicId,music);
            return Ok(resopnse);
        }

        /// <summary>
        /// Retrive a JSON from Spotify with playlist information
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [Route("GetTracksFromSpotify")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetTracksFromSpotify([FromBody] StringIn url)
        {
            var resopnse = await _appService.GetTracksFromSpotify(url.Data);
            return Ok(resopnse);
        }



    }
}