using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb3
{
    class Program
    {
        static void Main(string[] args)
        {
            int antalLoner;

            antalLoner = ReadInt("Ange antal löner att mata in: ");


            if (antalLoner > 1)
            {
                Console.WriteLine("Antalet löner ni vill ha beräknade är {0}", antalLoner);

            }
            else
            {

                
            }



        }


        static void ProcessSalaries(int count)
        {
         
            
     
        }

        static int ReadInt(string prompt)
        {
            string angeAntalLoner;


            Console.Write(prompt);
            angeAntalLoner = Console.ReadLine();



            return int.Parse(angeAntalLoner);


        }
    }
}
