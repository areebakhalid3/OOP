using signuplogin.BL;
using signuplogin.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signuplogin.UI
{
    class resourceassignmentUI
    {
        public static void BorrowResourceUI()
        {
            if (SessionManager.IsLoggedIn())
            {
                int userID = SessionManager.CurrentUser.userID;

                Console.Write("Enter resource name to borrow: ");
                string rscName = Console.ReadLine();

                var resource = resourcesDL.SearchResource(rscName);
                if (resource == null)
                {
                    Console.WriteLine("Resource not found.");
                    return;
                }

                Console.Write("Enter quantity to borrow: ");
                int qty = int.Parse(Console.ReadLine());

                if (resource.avqty < qty)
                {
                    Console.WriteLine("Not enough quantity available.");
                    return;
                }

                DateTime today = DateTime.Today;
                DateTime dueDate = today.AddDays(7);

                resourceassignmentBL newAssignment = new resourceassignmentBL(0, resource.rscID, userID, qty, today, dueDate, DateTime.MinValue);
                bool added = resourceassignmentDL.BorrowResource(newAssignment);

                if (added)
                {
                    resourcesDL.DecreaseAvailableQuantity(resource.rscID, qty);
                    Console.WriteLine("Borrowing successful!");
                }
                else
                {
                    Console.WriteLine("Failed to borrow resource.");
                }
            }
        }
        public static void ReturnResourceUI()
        {
            if (SessionManager.IsLoggedIn())
            {
                int userID = SessionManager.CurrentUser.userID;
                var borrowedList = resourceassignmentDL.GetBorrowedResourcesByUser(userID);
                if (borrowedList.Count == 0)
                {
                    Console.WriteLine("No borrowed resources to return.");
                    return;
                }

                Console.WriteLine("Your borrowed resources:");
                for (int i = 0; i < borrowedList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Resource ID: {borrowedList[i].ResourceID}, Qty: {borrowedList[i].Quantity}, Due: {borrowedList[i].DueDate.ToShortDateString()}");
                }

                Console.Write("Select the resource number to return: ");
                int choice = int.Parse(Console.ReadLine()) - 1;

                var selected = borrowedList[choice];
                DateTime returnDate = DateTime.Today;

                bool returned = resourceassignmentDL.ReturnResource(selected.AssignmentID, returnDate);

                if (returned)
                {
                    resourcesDL.IncreaseAvailableQuantity(selected.ResourceID, selected.Quantity);
                    Console.WriteLine("Resource returned successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to return resource.");
                }
            }
        }

    }
}
