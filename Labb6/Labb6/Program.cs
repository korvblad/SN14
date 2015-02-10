using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔══════════════════════════════════════════════════════════════════╗ ");
            Console.WriteLine(" ║                                                                  ║ ");
            Console.WriteLine(" ║                         Solida Volymer                           ║ ");
            Console.WriteLine(" ║                                                                  ║ ");
            Console.WriteLine(" ╚══════════════════════════════════════════════════════════════════╝ ");
            Console.ResetColor();
            
        }

        static double ReadDoubleGreaterThanZero(string prompt)
        {
            throw new NotImplementedException();
        }

        //static solid CreateSolid(SolidType solidtype)
        //{
        //    throw new notimplementedexception();
        //}

        static void ViewMenu()
        {
        }

        static void ViewSolidDetail(Solid solid)
        {

        }
    }
}