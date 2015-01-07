using System;

namespace Laboration1TH
{
    class Program
    {
        private const int femhundra = 500;
        private const int etthundra = 100;
        private const int tjugo = 20;
        private const int fem = 5;
        private const int en = 1;


        static void Main(string[] args)
        {

            double oresavrundning = 0;
            double totalKostnad = 0;
            int erhalletBelopp = 0;
            int attBetala = 0;
            int tillbaka = 0;
            string inmatatTal;
            string angeTotalsumma = "Ange totalsumma";
            string angeErhalletBelopp = "Ange erhållet belopp";


            // Ger felmeddelande ifall något annat än double skrivs in
            while (true)
            {
                try
                {
                    Console.Write("{0,-20}: ", angeTotalsumma);
                    inmatatTal = Console.ReadLine();
                    totalKostnad = double.Parse(inmatatTal);
                    //Ger felmeddelande och avslutar programmet ifall totalsumman är < 0,50
                    if (totalKostnad <= 0.5)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Totalsumman är för liten. Köpet kunde itne genomföras!");
                        Console.ResetColor();

                        return;
                    }
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
                    Console.Write("{0}: ", angeErhalletBelopp);
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


            if (erhalletBelopp < totalKostnad)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("FEL! Erhållet belopp är för litet. Köpet kunde inte genomföras. ");
                Console.ResetColor();
            }
            else
            {
                //Öresavrunding 
                attBetala = (int)Math.Round(totalKostnad);
                oresavrundning = attBetala - totalKostnad;

                tillbaka = erhalletBelopp - attBetala;

                string totalt = "Totalt";
                string avrunding = "Öresavrundning";
                string betala = "Att betala";
                string erhallet = "Kontant";
                string retur = "Tillbaka";

                Console.WriteLine("\nKVITTO\n-------------------------------");

                Console.WriteLine("{0,-17}:{1,12:c}\n{2,-17}:{3,12:c}\n{4,-17}:{5,12:c}\n{6,-17}:{7,12:c}\n{8,-17}:{9,12:c}",
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
                Console.WriteLine("-------------------------------");



                int vaxel = 0;
                int femhundralapp = 0;
                int etthundralapp = 0;
                int tjugolapp = 0;
                int femkrona = 0;
                int enkrona = 0;

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

                //Skriver ut antalet sedlar/mynt som kund skall få tillbaka samt rundar ner.
                Console.WriteLine(" {0,-16}: {1}\n {2,-16}: {3}\n {4,-16}: {5}\n {6,-16}: {7}\n {8,-16}: {9}",
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
}
