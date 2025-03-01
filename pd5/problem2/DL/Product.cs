using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace problem2.DL
{
    internal class Product
    {
        //Product List
        static List<string> pro1 = new List<string> { "laptop", "headphones", "microphone", "3D printer", "iron", "canon camera", "VR Headset", "webcam", "usb drive", "drone" };
        static List<float> price1 = new List<float> { 200000,5000,3000,10000,2000,10000,20000,15000,500,6000 };
        static List<int> qty1 = new List<int> { 1, 15, 20, 5, 50, 8, 7, 30, 100, 12 };

        static List<string> pro2 = new List<string>{ "Lipstick", "Foundation", "Eyeliner", "Mascara", "Blush", "Compact Powder", "Highlighter", "Makeup Brush", "Contour", "Concealer" };
        static List<float> price2 = new List<float>{ 1200, 2500, 800, 1500, 1000, 1800, 2200, 500, 2000, 1700 };
        static List<int> qty2 = new List<int>{ 30, 20, 50, 25, 40, 15, 10, 60, 18, 22 };

        static List<string> pro3 = new List<string>{ "Notebook", "Ball Pen", "Marker", "Stapler", "Highlighter", "Glue Stick", "Scissors", "Calculator", "Ruler", "Eraser" };
        static List<float> price3 = new List<float>{ 250, 50, 120, 300, 150, 100, 400, 1500, 80, 30 };
        static List<int> qty3 = new List<int>{ 100, 200, 75, 40, 90, 120, 35, 10, 80, 150 };

        static List<string> pro4 = new List<string>{ "Apple", "Banana", "Orange", "Mango", "Pineapple", "Grapes", "Watermelon", "Strawberry", "Peach", "Papaya" };
        static List<float> price4 = new List<float>{ 300, 150, 250, 400, 600, 350, 500, 800, 450, 550 };
        static List<int> qty4 = new List<int>{ 50, 100, 75, 40, 20, 60, 30, 15, 25, 18 };

        static List<string> pro5 = new List<string>{ "Rice", "Sugar", "Flour", "Cooking Oil", "Salt", "Tea", "Lentils", "Spices", "Milk", "Eggs" };
        static List<float> price5 = new List<float>{ 500, 150, 120, 900, 50, 800, 400, 250, 180, 250 };
        static List<int> qty5 = new List<int>{ 30, 50, 45, 20, 100, 25, 35, 40, 60, 90 };

        //availability
        static List<bool> isavailable1 = new List<bool> { true, true, true, true, true, true, true, true, true, true };      
        static List<bool> isavailable2 = new List<bool> { true, true, true, true, true, true, true, true, true, true };       
        static List<bool> isavailable3 = new List<bool> { true, true, true, true, true, true, true, true, true, true };        
        static List<bool> isavailable4 = new List<bool> { true, true, true, true, true, true, true, true, true, true };   
        static List<bool> isavailable5 = new List<bool> { true, true, true, true, true, true, true, true, true, true };

        //purchase list for invoice
        static List<string> purprod = new List<string>();
        static List<int> purqty = new List<int>();
        static List<float> purprice = new List<float>();
        public static void addproduct()
        {
            Console.Write("Enter category (1: Electronics, 2: Makeup, 3: Stationery, 4: Fruits, 5: Grocery): ");
            int cat = int.Parse(Console.ReadLine());

            Console.Write("Enter product name: ");
            string newName = Console.ReadLine();
            Console.Write("Enter price: ");
            float newPrice = float.Parse(Console.ReadLine());
            Console.Write("Enter quantity: ");
            int newQty = int.Parse(Console.ReadLine());

            List<string> products;
            List<float> prices;
            List<int> quantities;

            if (cat == 1) { products = pro1; prices = price1; quantities = qty1; }
            else if (cat == 2) { products = pro2; prices = price2; quantities = qty2; }
            else if (cat == 3) { products = pro3; prices = price3; quantities = qty3; }
            else if (cat == 4) { products = pro4; prices = price4; quantities = qty4; }
            else if (cat == 5) { products = pro5; prices = price5; quantities = qty5; }
            else
            {
                Console.WriteLine("Invalid category!");
                return;
            }

            if (products.Contains(newName))
            {
                Console.WriteLine("Product already exists.");
                return;
            }

            products.Add(newName);
            prices.Add(newPrice);
            quantities.Add(newQty);

            Console.WriteLine("Product added successfully!");
        }


        public static void viewproducts()
        {
            Console.Write("Enter category (1: Electronics, 2: Makeup, 3: Stationery, 4: Fruits, 5: Grocery): ");
            int cat = int.Parse(Console.ReadLine());

            List<string> products = null;
            List<float> prices = null;
            List<int> quantities = null;
            List<bool> availability = null;

            if (cat == 1) { products = pro1; prices = price1; quantities = qty1; availability = isavailable1; }
            else if (cat == 2) { products = pro2; prices = price2; quantities = qty2; availability = isavailable2; }
            else if (cat == 3) { products = pro3; prices = price3; quantities = qty3; availability = isavailable3; }
            else if (cat == 4) { products = pro4; prices = price4; quantities = qty4; availability = isavailable4; }
            else if (cat == 5) { products = pro5; prices = price5; quantities = qty5; availability = isavailable5; }
            else { 
                Console.WriteLine("Invalid category!"); 
                return;
            }

            if (products.Count == 0)
            {
                Console.WriteLine("No products available in this category.");
                return;
            }

            Console.WriteLine("\nList of Products:");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("No.  | Name             | Price   | Quantity  | Availability   ");
            Console.WriteLine("---------------------------------------------------------------");

            for (int i = 0; i < products.Count; i++)
            {
                string status;
                if (availability[i])
                {
                    status = "Available";
                }
                else
                {
                    status = "Not Available";
                }
               Console.WriteLine((i + 1) + " | " + products[i] + " | " + prices[i] + " | " + quantities[i] + " | " + status);
         }
        }

        public static void HighestPrice()
        {

            Console.WriteLine("Enter the number of category in which you want to find highest price(1: Electronics, 2: Makeup, 3: Stationery, 4: Fruits, 5: Grocery):");
            int choice = int.Parse(Console.ReadLine());

            List<float> selectedPrice = new List<float>();
            List<string> selectedPro = new List<string>();

            if (choice == 1) { selectedPrice = price1; selectedPro = pro1; }
            else if (choice == 2) { selectedPrice = price2; selectedPro = pro2; }
            else if (choice == 3) { selectedPrice = price3; selectedPro = pro3; }
            else if (choice == 4) { selectedPrice = price4; selectedPro = pro4; }
            else if (choice == 5) { selectedPrice = price5; selectedPro = pro5; }
            else
            {
                Console.WriteLine("Invalid category!");
                return;
            }
            if (selectedPrice.Count == 0)
            {
                Console.WriteLine("No products available in this category.");
                return;
            }

            float maxPrice = selectedPrice.Max();  
            int index = selectedPrice.IndexOf(maxPrice);  

            Console.WriteLine("The highest-priced product in this category is "+selectedPro[index]+" with a price of "+maxPrice);
        }

        public static void salestax()
        {
            Console.WriteLine("Enter the number of category in which you want to find sales tax(1: Electronics, 2: Makeup, 3: Stationery, 4: Fruits, 5: Grocery):");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("The sales tax on electronic gadgets is 15%");
            }
            else if (choice == 2)
            {
                Console.WriteLine("The sales tax on makeup is 15%");

            }
            else if (choice == 3)
            {
                Console.WriteLine("The sales tax on stationary items is 15%");
            }
            else if (choice == 4)
            {
                Console.WriteLine("The sales tax on fruits is 5%");

            }
            else if (choice == 5)
            {
                Console.WriteLine("The sales tax on grocery is 10%");

            }
        }
           public static void ProductsToOrder(int threshold)
        {
          
            Console.WriteLine("Products that need to be ordered (Stock below "+threshold+": ");

            for (int i = 0; i < pro1.Count; i++)
            {
                if (qty1[i] < threshold)
                    Console.WriteLine($"{pro1[i]} - Only {qty1[i]} left!");
            }

            for (int i = 0; i < pro2.Count; i++)
            {
                if (qty2[i] < threshold)
                    Console.WriteLine($"{pro2[i]} - Only {qty2[i]} left!");
            }

            for (int i = 0; i < pro3.Count; i++)
            {
                if (qty3[i] < threshold)
                    Console.WriteLine($"{pro3[i]} - Only {qty3[i]} left!");
            }

            for (int i = 0; i < pro4.Count; i++)
            {
                if (qty4[i] < threshold)
                    Console.WriteLine($"{pro4[i]} - Only {qty4[i]} left!");
            }

            for (int i = 0; i < pro5.Count; i++)
            {
                if (qty5[i] < threshold)
                    Console.WriteLine($"{pro5[i]} - Only {qty5[i]} left!");
            }
        }

        public static string buyproducts()
        {
            float price;

            Console.Write("Enter the category of the product (1: Electronics, 2: Makeup, 3: Stationery, 4: Fruits, 5: Grocery): ");
            int cat = int.Parse(Console.ReadLine());

            List<string> selectedPro;
            List<float> selectedPrice;
            List<int> selectedQty;

            if (cat == 1) { selectedPro = pro1; selectedPrice = price1; selectedQty = qty1; }
            else if (cat == 2) { selectedPro = pro2; selectedPrice = price2; selectedQty = qty2; }
            else if (cat == 3) { selectedPro = pro3; selectedPrice = price3; selectedQty = qty3; }
            else if (cat == 4) { selectedPro = pro4; selectedPrice = price4; selectedQty = qty4; }
            else if (cat == 5) { selectedPro = pro5; selectedPrice = price5; selectedQty = qty5; }
            else
            {
                
                return "invalid category";
            }

            Console.Write("Enter the product name you want to buy: ");
            string prodname = Console.ReadLine();
            int index = selectedPro.IndexOf(prodname);

            if (index == -1)
            {
            
                return "Product not found.";
            }
            else
            {
               price = selectedPrice[index];
                Console.WriteLine("Product found.");
                Console.WriteLine("Price is: "+price);
            }

            Console.Write("Enter quantity to buy: ");
            int qty = int.Parse(Console.ReadLine());

            if (qty > selectedQty[index])
            {
                return "Not enough stock available.";
            }

            selectedQty[index] -= qty;
            purprod.Add(prodname);
            purprice.Add(price);
            purqty.Add(qty);
            Console.WriteLine($"You bought {qty} {prodname}(s). Remaining stock: {selectedQty[index]}");

            return prodname;
        }

        public static void invoice(List<string> purprod, List<float> purprice, List<int> purqty)
        {
       
            float grand = 0.0f;
            float totaltax = 0.0f;

            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("                  Departmental Store Invoice   ");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("No.  | Name                | Quantity  | Price   | Subtotal   ");
            Console.WriteLine("---------------------------------------------------------------");

            for (int i = 0; i < purprod.Count; i++)
            {
                float subtotal = purqty[i] * purprice[i];
                int tax=gettax(purprod[i]);
                float taxam = (subtotal * tax) / 100;
                float totalwtax = subtotal + taxam;

                grand += totalwtax;
                 totaltax+= taxam;

            Console.WriteLine($"{i + 1}  |  {purprod[i]}  |  {purqty[i]}  |  {purprice[i]}  |  {subtotal}  |  {taxam}");
            }

            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"                          Sales Tax: {totaltax}");
            Console.WriteLine($"                          Total Price (incl. tax): {grand}");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("                      Thanks for Shopping!        ");
            Console.WriteLine("---------------------------------------------------------------");
        }

        public static int gettax(string prodname)
        {
            if (pro1.Contains(prodname)) return 15; //electronics
            if (pro2.Contains(prodname)) return 15; //makeup
            if (pro3.Contains(prodname)) return 15; //stationery
            if (pro4.Contains(prodname)) return 5; //fruits
            if (pro5.Contains(prodname)) return 10; //grocery
            return 0;
        }
    }
}
