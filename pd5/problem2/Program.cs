using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using problem2.UI;

namespace problem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            List<string> purprod = new List<string>();
            List<int> purqty = new List<int>();
            List<float> purprice = new List<float>();

            string[] names = new string[100];
            string[] password = new string[100];
            string[] email = new string[100];
            string[] address = new string[100];
            string[] contact = new string[100];

            string path = "D:\\oop\\PD\\pd5\\problem2\\user.txt";

            int choice;
            Console.Clear();


            do
            {
                choice = Utility.DisplayMainMenu();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        if (UI.Customer.SignUp(path))
                            Console.WriteLine("Registration successful!");
                        else
                            Console.WriteLine("User already exists!");

                        Console.WriteLine("Press any key to return to the menu.");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        string role = Customer.SignIn(path);

                        if (role == "admin")
                        {
                            int adminop;
                            do
                            {
                                adminop = UI.Admin.AdminMenu();
                                switch (adminop)
                                {
                                    case 1: DL.Product.addproduct(); break;
                                    case 2: DL.Product.viewproducts(); break;
                                    case 3: DL.Product.HighestPrice(); break;
                                    case 4: DL.Product.salestax(); break;
                                    case 5:
                                        Console.Write("Enter the minimum stock threshold: ");
                                        if (int.TryParse(Console.ReadLine(), out int threshold))
                                            DL.Product.ProductsToOrder(threshold);
                                        else
                                            Console.WriteLine("Invalid input! Please enter a valid number.");
                                        break;
                                    case 6: DL.Customer.displayUsersForAdmin(password, names, path, ref x); break;
                                    case 7: Console.WriteLine("Exiting admin menu."); break;
                                    default: Console.WriteLine("Invalid choice! Please enter a number between 1 and 7."); break;
                                }

                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                            } while (adminop != 7);
                        }
                        else if (role == "user")
                        {
                            int userop;
                            do
                            {
                                userop = UI.Customer.UserMenu();
                                switch (userop)
                                {
                                    case 1: DL.Product.viewproducts(); break;
                                    case 2: DL.Product.buyproducts(); break;
                                    case 3: DL.Product.invoice(purprod, purprice, purqty); break;
                                    case 5: DL.Customer.displayUsersForUser(password, names, email, address, contact, path, ref x); break;
                                    case 6: Console.WriteLine("Exiting user menu."); break;
                                    default: Console.WriteLine("Invalid choice! Please enter a number between 1 and 6."); break;
                                }

                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                            } while (userop != 6);
                        }
                        else
                        {
                            Console.WriteLine("Invalid credentials. Returning to main menu.");
                            Console.ReadKey();
                        }
                        break;

                    case 3:
                        Console.WriteLine("Thank you for using our app. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please enter 1, 2, or 3.");
                        Console.ReadKey();
                        break;
                }

            } while (choice != 3);
        }
    }
}