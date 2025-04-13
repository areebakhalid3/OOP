using signuplogin.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signuplogin.DL
{
    class resourceassignmentDL
    {
        public static bool BorrowResource(resourceassignmentBL assignment)
        {
            string query = $"INSERT INTO ResourceAssignments (ResourceID, UserID, Quantity, BorrowedAt, DueDate, ReturnDate) " +
                           $"VALUES ({assignment.ResourceID}, {assignment.UserID}, {assignment.Quantity}, '{assignment.BorrowedAt:yyyy-MM-dd}', '{assignment.DueDate:yyyy-MM-dd}', NULL)";

            int rows = DatabaseHelper.Instance.Update(query);
            return rows > 0;
        }
        public static bool ReturnResource(int assignmentID, DateTime returnDate)
        {
            string query = $"UPDATE ResourceAssignments SET ReturnDate = '{returnDate:yyyy-MM-dd}' WHERE AssignmentID = {assignmentID}";

            int rows = DatabaseHelper.Instance.Update(query);
            return rows > 0;
        }
        public static List<resourceassignmentBL> GetBorrowedResourcesByUser(int userId)
        {
            List<resourceassignmentBL> borrowedList = new List<resourceassignmentBL>();

            string query = $"SELECT * FROM ResourceAssignments WHERE UserID = {userId} AND ReturnDate IS NULL";
            var reader = DatabaseHelper.Instance.getData(query);

            while (reader.Read())
            {
                int assignmentId = Convert.ToInt32(reader["AssignmentID"]);
                int resourceId = Convert.ToInt32(reader["ResourceID"]);
                int quantity = Convert.ToInt32(reader["Quantity"]);
                DateTime borrowedAt = Convert.ToDateTime(reader["BorrowedAt"]);
                DateTime dueDate = Convert.ToDateTime(reader["DueDate"]);

                resourceassignmentBL item = new resourceassignmentBL(assignmentId, resourceId, userId, quantity, borrowedAt, dueDate, DateTime.MinValue);
                borrowedList.Add(item);
            }

            reader.Close();
            return borrowedList;
        }

    }
}
