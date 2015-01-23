using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration4.A
{
    public class SecretNumber
    {
        private int _number;
        private int _count;

        public const int MaxNumberOfGuesses = 7;

        public void Initialize()
        {
            Random random = new Random();
            _number = random.Next(1, 100);
            _count = 0;
            return;
        }

        public bool MakeGuess(int number)
        {
            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (_count == MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }
            if (number < _number)
            {
                Console.WriteLine("{0} är för lågt, du har {1} gissningar kvar", number, MaxNumberOfGuesses - (_count + 1));
                _count++;

                if (_count == MaxNumberOfGuesses)
                {
                    Console.WriteLine("Det hemliga talet var: {0}", _number);
                }
                return false;
            }

            if (number > _number)
            {
                Console.WriteLine("{0} är för högt, du har {1} gissningar kvar", number, MaxNumberOfGuesses - (_count + 1));
                _count++;

                if (_count == MaxNumberOfGuesses)
                {
                    Console.WriteLine("Det hemliga talet var: {0}", _number);
                }
                return false;
            }

            if (number == _number)
            {
                Console.WriteLine("Du gissade rätt på {0} Försök!  Det hemliga talet var {1}", _count + 1, _number);
            }
            return true;
        }
        public SecretNumber()
        {
            Initialize();
        }

    }
}
