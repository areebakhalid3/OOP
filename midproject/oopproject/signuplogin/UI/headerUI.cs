using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signuplogin.UI
{
    class headerUI
    {
        public static void PrintHeader()
        {
            SetColor(ConsoleColor.DarkGray);
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("         ======================================================================================");

            SetColor(ConsoleColor.White);
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("         ");
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("                         #######   ##      ##   #######   ########   ########                ");
            Console.SetCursorPosition(2, 6);
            Console.WriteLine("                        ##     ##  ##      ##  ##     ##  ##     ##  ##                      ");
            Console.SetCursorPosition(2, 7);
            Console.WriteLine("                        ##         ##      ##  ##     ##  ##     ##  ##                      ");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("                        #########  ##########  #########  ########   ########                ");
            SetColor(ConsoleColor.Blue);
            Console.SetCursorPosition(2, 9);
            Console.WriteLine("                               ##  ##      ##  ##     ##  ##     ##  ##                      ");
            Console.SetCursorPosition(2, 10);
            Console.WriteLine("                        ##     ##  ##      ##  ##     ##  ##     ##  ##                      ");
            Console.SetCursorPosition(2, 11);
            Console.WriteLine("                         #######   ##      ##  ##     ##  ##     ##  ########                ");
            Console.SetCursorPosition(2, 12);
            Console.WriteLine("    ");
            Console.SetCursorPosition(2, 13);
            Console.WriteLine("                   #######    ########   ##      ##  ########  ########   ########           ");
            Console.SetCursorPosition(2, 14);
            Console.WriteLine("                  ##     ##   ##     ##  ##      ##  ##        ##     ##  ##                 ");
            Console.SetCursorPosition(2, 15);
            Console.WriteLine("                  ##          ##     ##  ##      ##  ##        ##     ##  ##                 ");
            Console.SetCursorPosition(2, 16);
            Console.WriteLine("                  #########   ########   ##########  ########  ########   ########           ");

            SetColor(ConsoleColor.White);
            Console.SetCursorPosition(2, 17);
            Console.WriteLine("                         ##   ##         ##      ##  ##        ##     ##  ##                 ");
            Console.SetCursorPosition(2, 18);
            Console.WriteLine("                  ##     ##   ##         ##      ##  ##        ##     ##  ##                 ");
            Console.SetCursorPosition(2, 19);
            Console.WriteLine("                   #######    ##         ##      ##  ########  ##     ##  ########           ");
            Console.SetCursorPosition(2, 20);
            Console.WriteLine("                                                                                                                                    ");

            SetColor(ConsoleColor.DarkGray);
            Console.SetCursorPosition(2, 21);
            Console.WriteLine("         ======================================================================================");

            SetColor(ConsoleColor.White);
            Console.SetCursorPosition(2, 23);
            Console.WriteLine("                                                WELCOME!                                    ");

            SetColor(ConsoleColor.Blue);
            Console.SetCursorPosition(2, 25);
            Console.WriteLine("                               Your Trusted Business Application for Sharing                 ");
            Console.SetCursorPosition(2, 26);
            Console.WriteLine("                                           Resources Seamlessly.                              ");

            SetColor(ConsoleColor.DarkGray);
            Console.SetCursorPosition(2, 28);
            Console.WriteLine("         ======================================================================================");

            SetColor(ConsoleColor.White);
            Console.SetCursorPosition(2, 30);
            Console.WriteLine("                                        Press Enter to Continue. ");

            Console.ResetColor();
        }

        public static int Menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.SetCursorPosition(40, 5);
            Console.WriteLine("================ Credentials ================");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(40, 7);
            Console.WriteLine("1. Sign Up");
            Console.SetCursorPosition(40, 8);
            Console.WriteLine("2. Sign In");
            Console.SetCursorPosition(40, 9);
            Console.WriteLine("3. Exit");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(40, 11);
            Console.WriteLine("Enter your choice: ");
            Console.SetCursorPosition(40, 12);
            Console.ResetColor();
            int choice = int.Parse(Console.ReadLine());

            while (choice < 1 || choice > 3)
            {
                Console.SetCursorPosition(40, 14);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid choice, please enter 1-3: ");
                Console.SetCursorPosition(40, 12);
                Console.Write("                                                   ");
                Console.ResetColor();
                Console.SetCursorPosition(40, 12);
                choice = int.Parse(Console.ReadLine());
            }

            return choice;
        }


        static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;

        }
    }
}
