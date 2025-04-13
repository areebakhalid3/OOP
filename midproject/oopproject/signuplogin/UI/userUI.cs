using signuplogin.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using signuplogin.DL;

namespace signuplogin.UI
{
    class userUI
    {
        public static void SignUp()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(50, 3);
            Console.WriteLine("===== SIGN UP =====");

            string email, password, role;

            while (true)
            {
                Console.SetCursorPosition(30, 6);
                Console.Write("Enter your email (must contain @): ");
                email = Console.ReadLine();

                string error = userBL.GetEmailValidationError(email);
                if (error == "")
                {
                    if (userDL.emailExists(email))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Email already exists. Try another one.");
                        Console.SetCursorPosition(30, 6);
                        Console.WriteLine("                                                                                                           ");
                        continue;
                    }
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.WriteLine("                                                                                                      ");
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            while (true)
            {
                Console.SetCursorPosition(30, 10);
                Console.WriteLine("Create a secure password:");
                Console.SetCursorPosition(30, 11);
                Console.Write("(min 6 chars, 1 uppercase, 1 number, 1 special char): ");
                password = Console.ReadLine();

                string error = userBL.GetPasswordValidationError(password);
                if (error == "") 
                {
                    break; 
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
               
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            do
            {
                Console.SetCursorPosition(30, 16);
                Console.Write("Select role (admin/user): ");
                role = Console.ReadLine().ToLower();
            }
            while (role != "admin" && role != "user");

            userBL newUser = new userBL(0,email, password, role);
            if (userDL.AddUser(newUser))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("User registered successfully!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: User registration failed.");
            }
        }

        public static string SignIn()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(50, 3);
            Console.WriteLine("===== SIGN IN =====");

            string role = "";

            do
            {
                Console.SetCursorPosition(50, 5);
                Console.Write("Enter your role (admin/user): ");
                role = Console.ReadLine().ToLower();
            }
            while (role != "admin" && role != "user");

            string email, password;
            userBL user = null;

            do
            {
                Console.SetCursorPosition(50, 7);
                Console.Write("Enter your email: ");
                email = Console.ReadLine();

                Console.SetCursorPosition(50, 9);
                Console.Write("Enter your password: ");
                password = Console.ReadLine();

                user = userDL.AuthenticateUser(email, password, role);

                if (user != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nLogin successful! Welcome, {user.email}.");
                    Console.ReadKey();
                    SessionManager.SetCurrentUser(user);
                    return user.role;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid credentials. Please try again.");
                    Console.ReadKey();
                }

            } while (user == null);

            return role;
        }

    }
}

