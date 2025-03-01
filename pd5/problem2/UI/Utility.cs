using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2.UI
{
    internal class Utility
    {
        public static int DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("===========================================================");
            Console.WriteLine("==                       WELCOME !                       ==");
            Console.WriteLine("===========================================================");
            Console.WriteLine("\n     Welcome to Departmental Store Management System ");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Sign In");
            Console.WriteLine("3. Exit");
            Console.WriteLine("-----------------------------------------------------------");

            Console.WriteLine("Enter choice: ");
            int choice=int.Parse(Console.ReadLine());
            return choice;
        }

     
        public static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;

        }
    }
}

  
       
