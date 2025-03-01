using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static problem2.UI.Product;

namespace problem2.UI
{
    internal class Customer
    {
        public static string Path;
        

        public Customer(string path)
        {
            Path = path;
        }
        public static int UserMenu()
        {
            Console.Clear();
            Console.WriteLine("===========================================================");
            Console.WriteLine("==   U  S  E  R     M  E  N  U     O  P  T  I  O  N  S   ==");
            Console.WriteLine("===========================================================");

            Console.WriteLine("\nUser Menu:");
            Console.WriteLine("1. View all products.");
            Console.WriteLine("2. Buy product.");
            Console.WriteLine("3. Generate Invoice.");
            Console.WriteLine("4. View Profile (Username, Password, Email, Address and Contact Number).");
            Console.WriteLine("5. Exit.");
            Console.Write("Enter your choice: ");
            return int.Parse(Console.ReadLine());

        }

        public static bool SignUp(string path)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(50, 3);
            Console.WriteLine("===== SIGN UP =====");

            string username, password, email, contactNo, address, role;

            do
            {
                Console.Write("Enter your username: ");
                username = Console.ReadLine();
            } while (!IsValidUsername(username));

            do
            {
                Console.Write("Enter a secure password: ");
                password = Console.ReadLine();
            } while (!IsValidPassword(password));

            do
            {
                Console.Write("Select role (admin/user): ");
                role = Console.ReadLine()?.Trim().ToLower();
            } while (string.IsNullOrEmpty(role) || (role != "admin" && role != "user"));

            if (role == "user")
            {
                Console.Write("Enter your email: ");
                email = Console.ReadLine();
                Console.Write("Enter your address: ");
                address = Console.ReadLine();
                Console.Write("Enter your contact number: ");
                contactNo = Console.ReadLine();

                BL.Customer newCustomer = new BL.Customer(username, password, email, address, contactNo);

                File.AppendAllText(Path, $"{username},{password},{email},{address},{contactNo}");
                DL.Customer.RegisterUser(username, password, email, address, contactNo,path);
            }

            return true;
        }

        public static string SignIn(string path)
        {
            Console.Clear();
            Console.WriteLine("===== SIGN IN =====");

            Console.Write("Enter your role (admin/user): ");
            string role = Console.ReadLine()?.ToLower();

            while (role != "admin" && role != "user")
            {
                Console.Write("Invalid role. Please enter 'admin' or 'user': ");
                role = Console.ReadLine()?.ToLower();
            }

            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string pass = Console.ReadLine();

            if (!File.Exists(path))
            {
                Console.WriteLine("User data file not found.");
                return null;
            }

            using (StreamReader fileVariable = new StreamReader(path))
            {
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string storedName = Getfield(record, 1);
                    string storedPassword = Getfield(record, 2);

                    if (username == storedName && pass == storedPassword)
                    {
                        Console.WriteLine("Credentials matched! Sign-in successful.");
                        return role;
                    }
                }
            }

            Console.WriteLine("Invalid credentials. Please try again.");
            return null;
        }


        public static bool IsValidUsername(string username)
        {
            return !string.IsNullOrWhiteSpace(username) && username.Length >= 3;
        }

      

        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                Console.WriteLine("Password must be at least 6 characters long.");
                return false;
            }

            bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                if (char.IsLower(c)) hasLower = true;
                if (char.IsDigit(c)) hasDigit = true;
                if ("!@#$%^&*()-_".Contains(c)) hasSpecial = true;
            }

            if (!hasUpper || !hasLower || !hasDigit || !hasSpecial)
            {
                Console.WriteLine("Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.");
                return false;
            }

            return true;
        }
        public static string Getfield(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma = comma + 1;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
    }

       
    }


