using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace HangmanAPI.Models
{
    public enum Status
    {
        Ongoing = 0,
        Won = 1,
        Lost = 2
    }
    public class GameState
    {
        public string ID { get; set; }
        public int GuessesLeft { get; set; }
        public List<char> GuessedLetters { get; set; } = new List<char>();
        public Status Status { get; set; }
        public string GuessedWord { get; set; }
        // server-side only values
        public string Word;
        public char[] GuessedWordInternal;
        public DateTime GameStartTime;

        public GameState(string id, string wordToGuess, int guessesLeft)
        {
            ID = id;
            Word = wordToGuess;
            GuessesLeft = guessesLeft;
            GuessedWordInternal = wordToGuess.Select(c => '_').ToArray();
            GuessedWord = new string(GuessedWordInternal);
        }
    }
}
