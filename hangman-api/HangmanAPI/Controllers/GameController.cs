using HangmanAPI.Exceptions;
using HangmanAPI.Models;
using HangmanAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HangmanAPI.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private GameService _gameService;
        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        [Produces("application/json")]
        public ActionResult<GameState> StartGame()
        {
            return Ok(_gameService.StartGame());
        }

        [HttpPost("{id}")]
        [Produces("application/json")]
        public ActionResult<GameState> GuessLetter(string id, [FromQuery] string letter)
        {
            try
            {
                var result = _gameService.GuessLetter(id, letter[0]);
                return Ok(result);
            }
            catch(GameNotFoundException)
            {
                return BadRequest($"No game found with id {id}");
            }
            catch(LetterAlreadyGuessedException)
            {
                return BadRequest($"Letter {letter} has already been guessed, try another");
            }
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public ActionResult<GameState> GetState(string id)
        {
            try
            {
                return Ok(_gameService.GetState(id));
            }
            catch (GameNotFoundException)
            {
                return BadRequest($"No game found with id {id}");
            }
        }
    }
}
