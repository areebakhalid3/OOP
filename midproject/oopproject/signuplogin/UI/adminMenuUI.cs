using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signuplogin.UI
{
    class adminMenuUI
    {
        public static int AdminMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===========================================================");
            Console.WriteLine("==   A  D  M  I  N    M  E  N  U   O  P  T  I  O  N  S   ==");
            Console.WriteLine("===========================================================");

            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. Add Resource");
            Console.WriteLine("2. Search Resource");
            Console.WriteLine("3. Update Resource");
            Console.WriteLine("4. Delete Resource");
            Console.WriteLine("5. List Resources");
            Console.WriteLine("6. View Users");
            Console.WriteLine("7. Menu");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
