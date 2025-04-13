using signuplogin.BL;
using signuplogin.DL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace signuplogin.UI
{
    class resourcesUI
    {
        public static void AddResource()
        {
            Console.Write("Enter the name of the resource: ");
            string resourceName = Console.ReadLine();

            Console.Write("Enter the category of the resource (1 for Electronics,2 for Art Supplies,3 for Tools: ");
            int category = int.Parse(Console.ReadLine());
            
            Console.Write("Enter the total quantity: ");
            int totalQuantity = int.Parse(Console.ReadLine());

            Console.Write("Enter the available quantity: ");
            int availableQuantity = int.Parse(Console.ReadLine());
            
            Console.Write("Enter the borrowed quantity: ");
            int borrowedQuantity = int.Parse(Console.ReadLine());

            resourcesBL newResource = new resourcesBL(0,resourceName, category, totalQuantity, availableQuantity, borrowedQuantity);

            bool isAdded = resourcesDL.AddResource(newResource);

            if (isAdded)
            {
                Console.WriteLine("Resource added successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add resource.");
            }
        }

        public static void SearchResource()
        {
            Console.Write("Enter the name of the resource to search for: ");
            string resourceName = Console.ReadLine();

            resourcesBL resource = resourcesDL.SearchResource(resourceName);

            if (resource == null)
            {
                Console.WriteLine("Resource not found.");
            }
            else
            {
                Console.WriteLine("Resource found:");
                Console.WriteLine($"Name: {resource.rscName}");
                Console.WriteLine($"Category: {resource.rsccategory}");
                Console.WriteLine($"Total Quantity: {resource.totalqty}");
                Console.WriteLine($"Available: {resource.avqty}");
                Console.WriteLine($"Borrowed: {resource.borqty}");
            }
        }
        public static void UpdateResource()
        {
            Console.Write("Enter the name of the resource you want to update: ");
            string updatersc = Console.ReadLine();

            resourcesBL resource = resourcesDL.SearchResource(updatersc);
            if (resource == null)
            {
                Console.WriteLine("Resource not found. Update cancelled.");
                return;
            }

            Console.WriteLine("1. Update Name");
            Console.WriteLine("2. Update Category");
            Console.WriteLine("3. Update Total Quantity");
            Console.WriteLine("4. Update Available Quantity");
            Console.WriteLine("5. Update Borrowed Quantity");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            resourcesBL updatedResource = new resourcesBL();
            switch (choice)
            {
                case 1:
                    Console.Write("Enter new name: ");
                    updatedResource.rscName = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter new category [1-Electronics, 2-Art Supplies, 3-Tools]: ");
                    updatedResource.rsccategory = int.Parse(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("Enter new total quantity: ");
                    updatedResource.totalqty = int.Parse(Console.ReadLine());
                    break;
                case 4:
                    Console.Write("Enter new available quantity: ");
                    updatedResource.avqty = int.Parse(Console.ReadLine());
                    break;
                case 5:
                    Console.Write("Enter new borrowed quantity: ");
                    updatedResource.borqty = int.Parse(Console.ReadLine());
                    break;
            }

            bool isUpdated = resourcesDL.UpdateResource(updatersc, updatedResource);

            if (isUpdated)
            {
                Console.WriteLine("Resource updated successfully!");
            }
            else
            {
                Console.WriteLine("Failed to update resource.");
            }
        }

        public static void DeleteResource()
        {
            Console.Write("Enter the name of the resource to delete: ");
            string resourceName = Console.ReadLine();

            resourcesBL resourcetodel = new resourcesBL(0,resourceName, 0, 0, 0, 0);
            bool found = resourcesDL.DeleteResource(resourcetodel);

            if (!found)
            {
                Console.WriteLine("Resource not found.");
            }
            else
            {
                Console.WriteLine("Resource deleted!");
            }
        }

        public static void ListResources()
        {
            var resources = resourcesDL.GetAllResources();
            if (resources.Count == 0)
            {
                Console.WriteLine("No resources available.");
                return;
            }

            Console.WriteLine("Resource List:");
            Console.WriteLine("Resource Name".PadRight(20) + "Category".PadRight(12) + "Total Quantity".PadRight(15) + "Available".PadRight(12) + "Borrowed".PadRight(12));

            foreach (var resource in resources)
            {
                Console.WriteLine(resource.rscName.PadRight(20) +resource.rsccategory.ToString().PadRight(12) +resource.totalqty.ToString().PadRight(15) + resource.avqty.ToString().PadRight(12) + resource.borqty.ToString().PadRight(12));
            }
        }

        public static void ViewUsersForAdmin()
        {
            List<userBL> users = resourcesDL.GetUsersForAdmin();

            if (users.Count > 0)
            {
                Console.WriteLine("User List:");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Sr No".PadRight(5) + "Email".PadRight(30) + "Role");

                int srNo = 1;
                foreach (var user in users)
                {
                    Console.WriteLine($"{srNo.ToString().PadRight(5)}{user.email.PadRight(30)}{user.role.PadRight(10)}");
                    srNo++;
                }
                Console.WriteLine("-------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("No users registered.");
            }
        }
    }
}
