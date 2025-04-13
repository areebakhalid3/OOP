using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Person
    {
        protected string name;
        protected string address;

    public Person(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }
        public void setAddress(string address)
        {
            this.address = address;
        }

        public string getAddress()
        {
            return address;
        }
        public string To_String()
        {
            return $"Person[Name: {name}, Address: {address}]";
        }



    }
}
