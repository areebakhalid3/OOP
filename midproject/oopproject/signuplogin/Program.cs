using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using signuplogin.BL;
using signuplogin.UI;

namespace signuplogin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            string role = "";
             variable:
          
            do
            {
                Console.Clear();
                UI.headerUI.PrintHeader();
                Console.ReadKey();
                Console.Clear();
                choice = UI.headerUI.Menu();

                if (choice == 1)
                {
                    Console.Clear();
                    UI.userUI.SignUp();
                    Console.WriteLine("Press any key to return to the menu.");
                    Console.ReadKey();

                }
                else if (choice == 2)
                {
                    Console.Clear();
                    role = UI.userUI.SignIn();


                    if (!string.IsNullOrEmpty(role))
                    {
                        if (role == "Admin")
                        {
                            int adminop;
                            do
                            {
                                adminop = UI.adminMenuUI.AdminMenu();
                                switch (adminop)
                                {
                                    case 1:
                                        UI.resourcesUI.AddResource();
                                        break;
                                    case 2:
                                        UI.resourcesUI.SearchResource();
                                        break;
                                    case 3:
                                        UI.resourcesUI.UpdateResource();
                                        break;
                                    case 4:
                                        UI.resourcesUI.DeleteResource();
                                        break;
                                    case 5:
                                        UI.resourcesUI.ListResources();
                                        break;
                                    case 6:
                                        UI.resourcesUI.ViewUsersForAdmin();
                                        break;
                                    case 7:
                                        goto variable;
                                    case 8:
                                        Console.WriteLine("Exiting the program.");
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice! Please enter a number between 1 and 8.");
                                        break;
                                }
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                            } while (adminop != 8);
                        }
                        else if (role == "User")
                        {
                            int userop;
                            do
                            {
                                userop = UI.userMenuUI.UserMenu();
                                switch (userop)
                                {
                                    case 1:
                                        UI.resourcesUI.ListResources();
                                        break;
                                    case 2:
                                        UI.resourcesUI.SearchResource();
                                        break;
                                    case 3:
                                        UI.resourceassignmentUI.BorrowResourceUI();
                                        break;
                                    case 4:
                                        UI.resourceassignmentUI.ReturnResourceUI();
                                        break;
                                    case 5:
                                        goto variable;
                                    case 6:
                                        SessionManager.ClearCurrentUser();
                                        Console.WriteLine("Logged out successfully.");
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice! Please enter a number between 1 and 6.");
                                        break;
                                }
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                            } while (userop != 6);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Login failed. Please try again.");
                    }
                }
            } while (choice != 3);

            Console.WriteLine("Thank you for using our app. Goodbye!");
        }
    }
}