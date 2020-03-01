using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanAPI.Configuration
{
    public class GameSettings
    {
        public string[] GameWords { get; set; }
        public int LetterGuesses { get; set; }
    }
}
