using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace problem2.BL
{
    internal class Product
    {
        public string name;
        public string category;
        public double price;
        public int threshold;
        
            public Product(string name,string category,double price,int threshold)
        {
            this.name = name;
            this.category = category;
            this.price = price;
            this.threshold = threshold;
        }

        public double calctax()
        {
            if (category.ToLower() == "grocery")
            {
                return price * 0.10;
            }
            else if (category.ToLower() == "fruits")
            {
                return price * 0.05;
            }
            else
            {
                return price * 0.15;
            }
        }

    }
}
