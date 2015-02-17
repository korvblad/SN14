using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace labb7
{
    public class SecretNumber
    {

        public const int MaxNumberOfGuesses = 7;

        private int? _number;

        int? Number
        {
            get { return _number; }
            private set { _number = value; }
        }

        public Outcome MakeGuess(int guess)
        {
            throw new ApplicationException();
        }

        public readonly bool CanMakeGuess { get; }

        public readonly int Count { get; }

        private List<GuessedNumber> _guessedNumbers;
        public readonly IList<GuessedNumber> GuessedNumbers
        {
            get { return _guessedNumbers; }
        }

        private GuessedNumber _lastGuessedNumber;

        public readonly GuessedNumber LastGuessedNumber
        {
            get { return _lastGuessedNumber; }
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}