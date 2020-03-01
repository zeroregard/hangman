using HangmanAPI.Exceptions;
using HangmanAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanAPI.Controllers
{
    [Route("api/[controller]")]
    public class HighscoreController : Controller
    {
        private GameService _gameService;
        public HighscoreController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public ActionResult<int> Get(string id)
        {
            try
            {
                return Ok(_gameService.GetHighscore(id));
            }
            catch (HighscoreNotFoundException)
            {
                return BadRequest($"No highscore found for a game with id {id}");
            }
        }
    }
}
