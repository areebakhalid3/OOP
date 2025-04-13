using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signuplogin.BL
{
    class userBL
    {
        public int userID;
        public string email;
        public string password;
        public string role;

        public userBL() { }
        public userBL(int userID,string email, string password, string role)
        {
            this.userID = userID;
            this.email = email;
            this.password = password;
            this.role = role;
        }

        public static string GetEmailValidationError(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return "Email cannot be empty.";
            }

            int atCount = 0;
            int atIndex = -1;

            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                {
                    atCount++;
                    atIndex = i;
                }
            }

            if (atCount != 1 || atIndex == 0 || atIndex == email.Length - 1)
            {
                return "Invalid email format. Please include a valid '@' symbol.";
            }

            return "";
        }

        public static string GetPasswordValidationError(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return "Password cannot be empty.";
            }

            if (password.Length < 6)
            {
                return "Password must be at least 6 characters long.";
            }

            bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (!char.IsLetterOrDigit(c)) hasSpecial = true;
            }

            if (!hasUpper || !hasLower || !hasDigit || !hasSpecial)
            {
                return "Password must have uppercase, lowercase, number, and special character.";
            }

            return "";
        }
    }
}
