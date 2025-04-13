using MySql.Data.MySqlClient;
using signuplogin.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signuplogin.DL
{
    class resourcesDL
    {
            public static bool AddResource(resourcesBL resource)
            {
            string query = $"INSERT INTO Resources (ResourceName, ResourceCategory, TotalQuantity, AvailableQuantity, BorrowedQuantity) " +
                    $"VALUES ('{resource.rscName}', {resource.rsccategory}, {resource.totalqty}, {resource.avqty}, {resource.borqty})";
            int row=DatabaseHelper.Instance.Update(query);
            if (row > 0)
            {
                return true;
            }
            return false;  
            }

        public static resourcesBL SearchResource(string resourceName)
        {
            string query = $"SELECT ResourceID,ResourceName, ResourceCategory, TotalQuantity, AvailableQuantity, BorrowedQuantity " +
                           $"FROM Resources WHERE ResourceName = '{resourceName}'";

            var reader = DatabaseHelper.Instance.getData(query);
            resourcesBL foundResource = null;

            if (reader.Read())
            {
                foundResource = new resourcesBL(Convert.ToInt32(reader["ResourceID"]),
                    reader["ResourceName"].ToString(), Convert.ToInt32(reader["ResourceCategory"]), Convert.ToInt32(reader["TotalQuantity"]), Convert.ToInt32(reader["AvailableQuantity"]), Convert.ToInt32(reader["BorrowedQuantity"]));
            }
            reader.Close();
            return foundResource;
        }

        public static bool UpdateResource(string oldName, resourcesBL updatedResource)
        {
            string query = "";

            if (!string.IsNullOrEmpty(updatedResource.rscName) && updatedResource.rscName != oldName)
            {
                query = $"UPDATE Resources SET ResourceName = '{updatedResource.rscName}' WHERE ResourceName = '{oldName}'";
            }
            else if (updatedResource.rsccategory != 0)
            {
                query = $"UPDATE Resources SET ResourceCategory = {updatedResource.rsccategory} WHERE ResourceName = '{oldName}'";
            }
            else if (updatedResource.totalqty != 0)
            {
                query = $"UPDATE Resources SET TotalQuantity = {updatedResource.totalqty} WHERE ResourceName = '{oldName}'";
            }
            else if (updatedResource.avqty != 0)
            {
                query = $"UPDATE Resources SET AvailableQuantity = {updatedResource.avqty} WHERE ResourceName = '{oldName}'";
            }
            else if (updatedResource.borqty != 0)
            {
                query = $"UPDATE Resources SET BorrowedQuantity = {updatedResource.borqty} WHERE ResourceName = '{oldName}'";
            }

            if (string.IsNullOrEmpty(query))
            {
                return false;
            }

            int rowsAffected = DatabaseHelper.Instance.Update(query);
            return rowsAffected > 0;
        }

        public static bool DeleteResource(resourcesBL resource)
            {
                string query = $"DELETE FROM Resources WHERE ResourceName = '{resource.rscName}'";
                int rowsAffected = DatabaseHelper.Instance.Update(query);

                if (rowsAffected > 0)
                {
                return true;
                }
                else
                {
                return false;
                }
            }

        public static List<resourcesBL> GetAllResources()
        {
            List<resourcesBL> resources = new List<resourcesBL>();

            string query = "SELECT ResourceID,ResourceName, ResourceCategory, TotalQuantity, AvailableQuantity, BorrowedQuantity FROM Resources";
            var reader = DatabaseHelper.Instance.getData(query);

            while (reader.Read())
            {
                int rscid = Convert.ToInt32(reader["ResourceID"]);
                string resourceName = reader["ResourceName"].ToString();
                int category = Convert.ToInt32(reader["ResourceCategory"]);
                int totalQuantity = Convert.ToInt32(reader["TotalQuantity"]);
                int availableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                int borrowedQuantity = Convert.ToInt32(reader["BorrowedQuantity"]);

                resources.Add(new resourcesBL(rscid,resourceName, category, totalQuantity, availableQuantity, borrowedQuantity));
            }

            reader.Close();
            return resources;
        }

        public static List<userBL> GetUsersForAdmin()
        {
            List<userBL> users = new List<userBL>();
            string query = "SELECT u.Email, r.RoleName " +
                           "FROM Users u " +
                           "JOIN Roles r ON u.RoleID = r.RoleID " +
                           "WHERE r.RoleID = 2";  

            var reader = DatabaseHelper.Instance.getData(query);

            while (reader.Read())
            {
                string email = reader["Email"].ToString();
                string role = reader["RoleName"].ToString();
                userBL us = new userBL(0,email, "", role);
                users.Add(us);
            }

            reader.Close();
            return users;
        }
        public static bool DecreaseAvailableQuantity(int resourceID, int qty)
        {
            string query = $"UPDATE Resources SET AvailableQuantity = AvailableQuantity - {qty}, BorrowedQuantity = BorrowedQuantity + {qty} WHERE ResourceID = {resourceID}";
            return DatabaseHelper.Instance.Update(query) > 0;
        }

        public static bool IncreaseAvailableQuantity(int resourceID, int qty)
        {
            string query = $"UPDATE Resources SET AvailableQuantity = AvailableQuantity + {qty}, BorrowedQuantity = BorrowedQuantity - {qty} WHERE ResourceID = {resourceID}";
            return DatabaseHelper.Instance.Update(query) > 0;
        }


    }
}
