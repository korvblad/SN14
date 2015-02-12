using System;


namespace labb2try2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int rad = 1; rad <= 26; rad++)
                
            {
     

                for (int kolumn = 1; kolumn < 40; kolumn++)
                {
                    Console.Write("* ");
                   
                    if (rad % 26 == 1)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write(" ");
                        
                    }
                }

          


            
           
                  
            }

       
        }
    }
}
