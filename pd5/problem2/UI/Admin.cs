using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2.UI
{
    internal class Admin
    {
        public static int AdminMenu()
        {

            Console.Clear();
            Console.WriteLine("===========================================================");
            Console.WriteLine("==   A D M I N      M  E  N  U     O  P  T  I  O  N  S   ==");
            Console.WriteLine("===========================================================");

            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. Add product.");
            Console.WriteLine("2. View All products.");
            Console.WriteLine("3. Find product with highest unit price.");
            Console.WriteLine("4. View sales tax of all products.");
            Console.WriteLine("5. Products to be ordered.");
            Console.WriteLine("6. View Profile (Username, Password)");
            Console.WriteLine("7. Exit.");
            Console.Write("Enter your choice: ");
            return int.Parse(Console.ReadLine());


        }
    }
}
