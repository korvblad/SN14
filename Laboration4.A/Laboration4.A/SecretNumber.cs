﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration4.A
{
   public class SecretNumber
    {

       
       private int _number = 0;
       private int _count = 0;
       public const int MaxNumberOfGuesses = 7;
       
       
        public void Initialize()
        {

            _count = 0;

            return;
              
        }

        public bool MakeGuess(int number)
        {
            throw new NotImplementedException();
            //for (int i = 0; i < 7; i++)
            //{
            //    Console.Write("Gissning {0} : ", i + 1);
            //    number = int.Parse(Console.ReadLine());
            //}

        }



        public SecretNumber()
        {
            
        }
        
    }
}
