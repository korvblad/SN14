using System;

namespace Laboration1TH
{
    class Program
    {
            private const double femhundra = 500;
            private const double etthundra = 100;
            private const double tjugo = 20;
            private const double fem = 5;
            private const double en = 1;
            

            static void Main(string[] args)
            {

                double totalKostnad = 0;
                double erhalletBelopp = 0;
                double attBetala = 0;
                double oresavrundning = 0;
                double tillbaka = 0;
                string inmatatTal;

                // Ger felmeddelande ifall något annat än double skrivs in
                while (true)
                {
                    try
                    {
                        Console.Write("Ange summa att betala: ");
                        inmatatTal = Console.ReadLine();
                        totalKostnad = double.Parse(inmatatTal);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("FEL! Erhållet belopp felaktigt.");
                        Console.ResetColor();
                    }
                }

                //Ger felmeddelande ifall något annat än en int skrivs in
                while (true)
                {
                    try
                    {
                        Console.Write("Ange erhållet belopp: ");
                        inmatatTal = Console.ReadLine();
                        erhalletBelopp = int.Parse(inmatatTal);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("FEL! Erhållet belopp felaktigt.");
                        Console.ResetColor();
                    }
                }






                //Öresavrunding 
                attBetala = (uint)Math.Round(totalKostnad);
                oresavrundning = attBetala - totalKostnad;

                tillbaka = erhalletBelopp - attBetala;

                string totalt = "Totalt";
                string avrunding = "Öresavrundning";
                string betala = "Att betala";
                string erhallet = "Kontant";
                string retur = "Tillbaka";

                Console.WriteLine("\nKVITTO\n-----------------------------");

                Console.WriteLine("{0,-17}:{1,8:F2}\n{2,-17}:{3,8:c}\n{4,-17}:{5,8}\n{6,-17}:{7,8}\n{8,-17}:{9,8}",
                    totalt,
                    totalKostnad,
                    avrunding,
                    oresavrundning,
                    betala,
                    attBetala,
                    erhallet,
                    erhalletBelopp,
                    retur,
                    tillbaka);
                Console.WriteLine("-----------------------------");


                double  vaxel = 0;

                double femhundralapp = 0;
                double etthundralapp = 0;
                double tjugolapp = 0;
                double femkrona = 0;
                double enkrona = 0;

                string femhundravaxel = "500-lappar";
                string etthundravaxel = "100-lappar";
                string tjugovaxel = "20-lappar";
                string femkronavaxel = "5-kronor";
                string enkronavaxel = "1-kronor";

                vaxel = tillbaka;
                femhundralapp = vaxel / femhundra;
                vaxel = vaxel % femhundra;
                etthundralapp = vaxel / etthundra;
                vaxel = vaxel % etthundra;
                tjugolapp = vaxel / tjugo;
                vaxel = vaxel % tjugo;
                femkrona = vaxel / fem;
                vaxel = vaxel % fem;
                enkrona = vaxel / en;
                
                Console.WriteLine(" {0}:{1:f0}\n {2}:{3:f0}\n {4}:{5:f0}\n {6}:{7:f0}\n {8}:{9:f0}",
                    femhundravaxel, 
                    femhundralapp,
                    etthundravaxel,
                    etthundralapp,
                    tjugovaxel,
                    tjugolapp,
                    femkronavaxel,
                    femkrona,
                    enkronavaxel,
                    enkrona);
            }
    }
}
