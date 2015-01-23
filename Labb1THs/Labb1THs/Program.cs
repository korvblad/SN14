using System;

namespace Laboration1TH
{
    class Program
    {
        private const int femhundra = 500;
        private const int etthundra = 100;
        private const int femtio = 50;
        private const int tjugo = 20;
        private const int tio = 10;
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
                        Console.WriteLine("Totalsumman är för liten. Köpet kunde inte genomföras!");
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
                return;
            }

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
            int femtiolapp = 0;
            int etthundralapp = 0;
            int tjugolapp = 0;
            int tiokrona = 0;
            int femkrona = 0;
            int enkrona = 0;

            vaxel = tillbaka;
            femhundralapp = vaxel / femhundra;
            vaxel = vaxel % femhundra;
            etthundralapp = vaxel / etthundra;
            vaxel = vaxel % etthundra;
            femtiolapp = vaxel / femtio;
            vaxel = vaxel % femtio;
            tjugolapp = vaxel / tjugo;
            vaxel = vaxel % tjugo;
            tiokrona = vaxel / tio;
            femkrona = vaxel / fem;
            vaxel = vaxel % fem;
            enkrona = vaxel / en;


            if (femhundralapp > 0)
            {
                Console.WriteLine(" 500-lappar: {0}", femhundralapp);
            }
            if (etthundralapp > 0)
            {
                Console.WriteLine(" 100-lappar: {0}", etthundralapp);
            }
            if (femtiolapp > 0)
            {
                Console.WriteLine(" 50-lappar: {0,3}", femtiolapp);
            }
            if (tjugolapp > 0)
            {
                Console.WriteLine(" 20-lappar: {0,2}", tjugolapp);
            }
            if (tiokrona > 0)
            {
                Console.WriteLine(" 10-kronor: {0,3}", tiokrona);
            }
            if (femkrona > 0)
            {
                Console.WriteLine(" 5-kronor: {0,3}", femkrona);
            }
            if (enkrona > 0)
            {
                Console.WriteLine(" 1-kronor: {0,3}", enkrona);
            }

        }
    }
}
