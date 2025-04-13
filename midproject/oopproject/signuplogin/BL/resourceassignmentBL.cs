using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signuplogin.BL
{
    class resourceassignmentBL
    {
        public int AssignmentID;
        public int ResourceID;
        public int UserID;
        public int Quantity;
        public DateTime BorrowedAt;
        public DateTime DueDate;
        public DateTime ReturnDate;

        public resourceassignmentBL() { }

        public resourceassignmentBL(int assignmentID, int resourceID, int userID, int quantity, DateTime borrowedAt, DateTime dueDate, DateTime returnDate)
        {
            AssignmentID = assignmentID;
            ResourceID = resourceID;
            UserID = userID;
            Quantity = quantity;
            BorrowedAt = borrowedAt;
            DueDate = dueDate;
            ReturnDate = returnDate;
        }
    }

    }

