﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration4.A
{
    public class SecretNumber
    {
        public const int MaxNumberOfGuesses = 7;

        private int _count;
        private int _number;

        public void Initialize()
        {
            Random random = new Random();
            _number = random.Next(1, 100);
            _count = 0;
        }

        public bool MakeGuess(int number)
        {

            if (_count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }

            if (number >= 101 || number <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _count++;
            int guessesLeft = MaxNumberOfGuesses - _count;

            if (number < _number)
            {
                Console.WriteLine("{0} är för lågt! Du har {1} gissningar kvar!", number, guessesLeft);

                if (_count == MaxNumberOfGuesses)
                {
                    Console.WriteLine("Det hemliga talet är {0}.", _number);
                }
                return false;
            }

            if (number > _number)
            {
                Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar.", number, guessesLeft);
                
                if (_count == MaxNumberOfGuesses)
                {
                    Console.WriteLine("Det hemliga talet är {0}.", _number);           
                }
                return false;
            }
              
            Console.WriteLine("Bra Jobbat! Du klarade det på {0} försök.", _count);
            Console.WriteLine("Det hemliga talet var {0}.", _number);
            return true;
        }

        public SecretNumber()
        {
            Initialize();
        }
    }
}