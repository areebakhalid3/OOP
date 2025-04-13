using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signuplogin.UI
{
    class userMenuUI
    {
        public static int UserMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("===========================================================");
            Console.WriteLine("==   U  S  E  R     M  E  N  U     O  P  T  I  O  N  S   ==");
            Console.WriteLine("===========================================================");

            Console.WriteLine("\nUser Menu:");
            Console.WriteLine("1. List of Resources.");
            Console.WriteLine("2. Search Resources.");
            Console.WriteLine("3. Borrow Resource.");
            Console.WriteLine("4. Return Resource.");
            Console.WriteLine("5. Go back to menu.");
            Console.WriteLine("6. Exit.");
     
            Console.Write("Enter your choice: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
