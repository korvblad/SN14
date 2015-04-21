using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace labb7
{
    public class SecretNumber
    {
        //Fields
        public const int MaxNumberOfGuesses = 7;

        private int? _number;

        private List<GuessedNumber> _guessedNumbers;

        private GuessedNumber _lastGuessedNumber;

        ////Properties
        //public bool CanMakeGuess
        //{
        //    get
        //    {
        //        return Count == MaxNumberOfGuesses ? false : true;
        //    }
        //}

        //public int Count { get; }

        public IList<GuessedNumber> GuessedNumbers
        {
            get { return _guessedNumbers.AsReadOnly(); }
        }
        //readonly
        public GuessedNumber LastGuessedNumber
        {
            get { return _lastGuessedNumber; }
        }

        //int? Number
        //{
        //    get { return _number; }
        //    private set { _number = value; }
        //}

        
        //// Methods

        //public void Initialize()
        //{
        //    Random random = new Random();
        //    Number = random.Next(1, 100);

        //}

        //public Outcome MakeGuess(int guess)
        //{
        //    if (guess >= 101 || guess <= 0)
        //    {
        //        throw new ArgumentOutOfRangeException();
        //    }
        //    return null;
        //}

        //public SecretNumber()
        //{

        //    _guessedNumbers = new List<GuessedNumber>();
        //    Initialize();
        //}
    }
}