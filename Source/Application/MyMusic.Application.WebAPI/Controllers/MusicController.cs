using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            if (!expenseTypeResponse.Any())
                return NoContent();

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
        public async Task<IActionResult> GetById([FromRouteAttribute] int entityId)
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

    }
}