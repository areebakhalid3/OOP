using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using problem1.BL;

namespace problem1.UI
{
    internal class Mainmenu
    {

        public static void printHeader()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("██╗   ██╗ █████╗ ███╗   ███╗███████╗");
            Console.WriteLine("██║   ██║██╔══██╗████╗ ████║██╔════╝");
            Console.WriteLine("██║   ██║███████║██╔████╔██║███████╗");
            Console.WriteLine("██║   ██║██╔══██║██║╚██╔╝██║╚════██║");
            Console.WriteLine("╚██████╔╝██║  ██║██║ ╚═╝ ██║███████║");
            Console.WriteLine(" ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝");
        }
        public static int Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to University Management System!");
            Console.WriteLine();
            Console.WriteLine("1.Add Student ");
            Console.WriteLine("2.Add Degree Program");
            Console.WriteLine("3.Generate Merit ");
            Console.WriteLine("4.View Registered Students");
            Console.WriteLine("5.View Students of a Specific Program ");
            Console.WriteLine("6.Register Subjects for a Specific Students ");
            Console.WriteLine("7.Calculate Fees for all Registered Students ");
            Console.WriteLine("8.Exit. ");
            Console.WriteLine(" ");
            Console.Write("Enter option: ");
            int option = int.Parse(Console.ReadLine());
            return option;
        }

    }
}
