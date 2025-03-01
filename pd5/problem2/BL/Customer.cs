using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace problem2.BL
{
    internal class Customer
    {
        public string username;
        public string password;
        public string email;
        public string address;
        public string contactno;
   

        public Customer(string username, string password, string email, string address, string contactno)
        {

            this.username = username;
            this.password = password;
            this.email = email;
            this.address = address;
            this.contactno = contactno;
      
        }

    }
}

