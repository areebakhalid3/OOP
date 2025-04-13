using MySql.Data.MySqlClient;
using signuplogin.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signuplogin.DL
{
    class userDL
    {

        public static bool emailExists(string email)
        {
            string query = $"SELECT COUNT(*) FROM users WHERE email = '{email}'";
            var reader = DatabaseHelper.Instance.getData(query);

            bool exists = false;
            if (reader.Read())
            {
                exists = Convert.ToInt32(reader[0]) > 0;
            }
            reader.Close();
            return exists;
        }

        public static bool AddUser(userBL user)
        {
            string queryRole = $"SELECT RoleID FROM Roles WHERE RoleName = '{user.role}'";
            var roleReader = DatabaseHelper.Instance.getData(queryRole);
            int roleID = 0;
                while (roleReader.Read())
                {
                    roleID = Convert.ToInt32(roleReader["RoleID"]);
                }
            roleReader.Close();

            string query = $"INSERT INTO Users (Email, Password, RoleID) VALUES ('{user.email}', '{user.password}', {roleID})";
            int rows=DatabaseHelper.Instance.Update(query);
            return rows > 0;
        }

        public static void ViewUsers()
        {
            string query = "SELECT u.Email, r.RoleName FROM Users u JOIN Roles r ON u.RoleID = r.RoleID";
            var reader = DatabaseHelper.Instance.getData(query);

            if (reader.Read())
            {
                Console.WriteLine("User List:");
                while (reader.Read())
                {
                    Console.WriteLine($"Email: {reader["Email"]}, Role: {reader["RoleName"]}");
                }
            }
            else
            {
                Console.WriteLine("No users registered yet.");
            }
            reader.Close();
        }

        public static userBL AuthenticateUser(string email, string password, string role)
        {
            string query = $"SELECT u.UserID,u.Email, u.Password, r.RoleName " +
                           $"FROM users u " +
                           $"INNER JOIN Roles r ON u.RoleID = r.RoleID " +
                           $"WHERE u.Email = '{email}' AND u.Password = '{password}' AND r.RoleName = '{role}'";

            var reader = DatabaseHelper.Instance.getData(query);

            if (reader.Read())
            {
                return new userBL(Convert.ToInt32(reader["UserID"]),
                    reader["Email"].ToString(),
                    reader["Password"].ToString(),
                    reader["RoleName"].ToString()
                );
            }

            return null; 
        }

    }
}
