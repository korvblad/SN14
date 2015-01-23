using System;
using System.Linq;
using System.Collections;

namespace labb3
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int antalLoner = 0;
                while (true)
                {
                    antalLoner = ReadInt("Ange antal löner att mata in:");

                    if (antalLoner >= 2)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du måste mata in minst två löner för att kunna göra en beräkning! ");
                        Console.ResetColor();
                    }
                }

                // nu vet du att det är minst 2 löner
                ProcessSalaries(antalLoner);

                // avsluta eller inte?
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Tryck valfri tangent för en ny beräkning - ESC avslutar.");
                Console.ResetColor();

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            Console.Clear();
        }
        static void ProcessSalaries(int count)
        {
            int loneberakning = 0;
            int[] lonerad = new int[count];

            for (int i = 0; i < lonerad.Length; i++)
            {
                Console.Write("Ange lön nummer {0}: ", i + 1);
                string loner = Console.ReadLine();
                loneberakning = int.Parse(loner);
                lonerad[i] = loneberakning;
            }
            double average = lonerad.Average();
            int min = lonerad.Min();
            int max = lonerad.Max();
            int lonespridning = max - min;

            int[] osorteradLonerad = new int[count];
            Array.Copy(lonerad, osorteradLonerad, count);
            Array.Sort(lonerad);

            Console.WriteLine();
            Console.WriteLine("----------------------");

            if (count % 2 == 0)
            {
                int medianNr1 = lonerad.Length / 2 - 1;
                int medianNr2 = lonerad.Length / 2;

                double median = (lonerad[medianNr1] + lonerad[medianNr2]) / 2.0d;
                Console.WriteLine("Medianlön : {0,7:c0}", median);
            }
            else
            {
                int median = lonerad.Length / 2;
                Console.WriteLine("Medianlön: {0,12:c0}", lonerad[median]);
            }

            Console.WriteLine("Medellön : {0,12:c0}", average);
            Console.WriteLine("Lönespridning : {0,7:c0}", lonespridning);
            Console.WriteLine("----------------------");

            int rakna = 0;

            foreach (int skrivLoner in osorteradLonerad)
            {
                if (rakna % 3 == 0)
                {
                    Console.Write("\n{0,6}", skrivLoner);
                    rakna++;
                }
                else
                {
                    Console.Write("{0,6}", skrivLoner);
                    rakna++;
                }
            }
            Console.WriteLine();
        }

        static int ReadInt(string prompt)
        {
            string angeAntalLoner;

            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    angeAntalLoner = Console.ReadLine();
                    Console.WriteLine();
                    return int.Parse(angeAntalLoner);
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Antal löner måste vara ett heltal!");
                    Console.ResetColor();
                }
            }
        }
    }
}

