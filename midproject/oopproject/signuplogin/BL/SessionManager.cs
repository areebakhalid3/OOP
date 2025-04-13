using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signuplogin.BL
{
    class SessionManager
    {
            public static userBL CurrentUser;
            
            public static void SetCurrentUser(userBL user)
            {
                CurrentUser = user;
            }

            public static void ClearCurrentUser()
            {
                CurrentUser = null;  
            }

            public static bool IsLoggedIn()
            {
                if(CurrentUser != null)
            {
                return true;
            }
            return false;
            }
        }

    }

