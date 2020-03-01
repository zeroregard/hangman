using HangmanAPI.Configuration;
using HangmanAPI.Exceptions;
using HangmanAPI.Models;
using HangmanAPI.Services;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Linq;

namespace HangmanAPITests
{
    public class GameServiceTests
    {
        private GameService _gameService;
        private GameSettings _gameSettings;
        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var conf = builder.Build();
            _gameSettings = conf.GetSection("GameSettings").Get<GameSettings>();
            _gameService = new GameService(conf);
        }

        [Test]
        public void StartGame_NewGameStateSettingsAreCorrect()
        {
            var result = _gameService.StartGame();

            Assert.IsTrue(_gameSettings.GameWords.Contains(result.Word));
            Assert.AreEqual(result.Word.Length, result.GuessedWordInternal.Length);
            Assert.AreEqual(_gameSettings.LetterGuesses, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);
        }

        [Test]
        public void GuessLetter_PlayFlawlessly_WinWith5Guesses()
        {
            var result = _gameService.StartGame();

            result = _gameService.GuessLetter(result.ID, 't');
            Assert.AreEqual("t__t____", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            result = _gameService.GuessLetter(result.ID, 'e');
            Assert.AreEqual("te_t____", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            result = _gameService.GuessLetter(result.ID, 's');
            Assert.AreEqual("test____", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            result = _gameService.GuessLetter(result.ID, 'w');
            Assert.AreEqual("testw___", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            result = _gameService.GuessLetter(result.ID, 'o');
            Assert.AreEqual("testwo__", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            result = _gameService.GuessLetter(result.ID, 'r');
            Assert.AreEqual("testwor_", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            result = _gameService.GuessLetter(result.ID, 'd');
            Assert.AreEqual("testword", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses, result.GuessesLeft);
            Assert.AreEqual(Status.Won, result.Status);
        }

        [Test]
        public void GuessLetter_PlayFlawed_Lose()
        {
            var result = _gameService.StartGame();

            result = _gameService.GuessLetter(result.ID, 't');
            Assert.AreEqual("t__t____", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            result = _gameService.GuessLetter(result.ID, 'e');
            Assert.AreEqual("te_t____", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            result = _gameService.GuessLetter(result.ID, 's');
            Assert.AreEqual("test____", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            result = _gameService.GuessLetter(result.ID, 'w');
            Assert.AreEqual("testw___", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            result = _gameService.GuessLetter(result.ID, 'o');
            Assert.AreEqual("testwo__", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            result = _gameService.GuessLetter(result.ID, 'r');
            Assert.AreEqual("testwor_", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            result = _gameService.GuessLetter(result.ID, 'z');
            Assert.AreEqual("testwor_", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses - 1, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            result = _gameService.GuessLetter(result.ID, 'y');
            Assert.AreEqual("testwor_", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses - 2, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            result = _gameService.GuessLetter(result.ID, 'x');
            Assert.AreEqual("testwor_", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses - 3, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            result = _gameService.GuessLetter(result.ID, 'v');
            Assert.AreEqual("testwor_", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses - 4, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            result = _gameService.GuessLetter(result.ID, 'u');
            Assert.AreEqual("testwor_", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses - 5, result.GuessesLeft);
            Assert.AreEqual(Status.Lost, result.Status);
        }

        [Test]
        public void GuessLetter_PlaySameLetterTwice_ExceptionThrown()
        {
            var result = _gameService.StartGame();

            result = _gameService.GuessLetter(result.ID, 't');
            Assert.AreEqual("t__t____", result.GuessedWord);
            Assert.AreEqual(_gameSettings.LetterGuesses, result.GuessesLeft);
            Assert.AreEqual(Status.Ongoing, result.Status);

            Assert.Throws<LetterAlreadyGuessedException>(() => _gameService.GuessLetter(result.ID, 't'));
        }

        [Test]
        public void GuessLetter_GameDoesNotExist_ExceptionThrown()
        {
            var result = _gameService.StartGame();

            Assert.Throws<GameNotFoundException>(() => _gameService.GuessLetter(Guid.NewGuid().ToString(), 't'));
        }
    }
}