using HangmanAPI.Configuration;
using HangmanAPI.Exceptions;
using HangmanAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanAPI.Services
{
    public class GameService
    {
        private Dictionary<string, GameState> _games = new Dictionary<string, GameState>();
        private Dictionary<string, int> _highscores = new Dictionary<string, int>();
        private readonly GameSettings _gameSettings;
        private Random _random = new Random();
        public GameService(IConfiguration configuration)
        {
            _gameSettings = configuration.GetSection("GameSettings").Get<GameSettings>();
        }

        public GameState StartGame()
        {
            var id = Guid.NewGuid().ToString();
            var word = _gameSettings.GameWords[_random.Next(_gameSettings.GameWords.Length)];
            var gameState = new GameState(id, word, _gameSettings.LetterGuesses);
            gameState.GameStartTime = DateTime.UtcNow;
            _games.Add(id, gameState);
            return gameState;
        }

        public GameState GetState(string id)
        {
            if (_games.TryGetValue(id, out GameState game))
            {
                return game;
            }
            throw new GameNotFoundException();
        }

        public GameState GuessLetter(string id, char letter)
        {
            if(_games.TryGetValue(id, out GameState game))
            {
                // check if game already done
                if(game.Status != Status.Ongoing)
                {
                    return game;
                }

                // handle guess
                if(game.GuessedLetters.Contains(letter))
                {
                    throw new LetterAlreadyGuessedException();
                }
                game.GuessedLetters.Add(letter);
                if(!game.Word.Contains(letter))
                {
                    game.GuessesLeft--;
                }
                
                // show potential discovered letters
                for (int i = 0; i < game.Word.Length; i++)
                {
                    if(game.Word[i] == letter)
                    {
                        game.GuessedWordInternal[i] = letter;
                    }
                }

                // check for win/lose scenarios
                game.GuessedWord = new string(game.GuessedWordInternal);
                if (game.GuessesLeft == 0)
                {
                    game.Status = game.GuessedWord == game.Word ? Status.Won : Status.Lost;
                }
                else if (game.GuessedWord == game.Word)
                {
                    var highscore = (int)Math.Round((DateTime.UtcNow - game.GameStartTime).TotalSeconds);
                    _highscores[game.ID] = highscore;
                    game.Status = Status.Won;
                }
                return game;
            }
            throw new GameNotFoundException();
        }

        public int GetHighscore(string id)
        {
            if (_highscores.TryGetValue(id, out int score))
            {
                return score;
            }
            throw new HighscoreNotFoundException();
        }
    }
}
