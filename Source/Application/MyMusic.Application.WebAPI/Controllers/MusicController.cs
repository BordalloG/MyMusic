using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        /// Retrieves a List of Matchs
        /// </summary>
        /// <returns></returns>

        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var expenseTypeResponse = await _appService.GetAllAsync();
            if (!expenseTypeResponse.Any())
                return NoContent();

            return Ok(expenseTypeResponse);
        }

        /// <summary>
        /// Inserts a new Match
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
        /// Remove a Match
        /// </summary>
        /// <param name="musicId"></param>
        /// <returns></returns>
        [Route("{matchId}")]
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteMatchAsync([FromRoute] int musicId)
        {
            await _appService.DeleteAsync(musicId);
            return Ok();
        }

    }
}