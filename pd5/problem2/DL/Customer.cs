using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2.DL
{
    internal class Customer
    {
        public static void RegisterUser(string name, string pass, string email, string address, string contact, string path)
        {
            using (StreamWriter file = new StreamWriter(path, true)) 
            {
                file.WriteLine(name + "," + pass + "," + email + "," + address + "," + contact);
            }
            Console.WriteLine("Registration Successful!");
        }
        public static void displayUsersForAdmin(string[] password, string[] names, string path1, ref int x)
        {
            string record;
            if (File.Exists(path1))
            {
                Console.WriteLine("Name \t\t\tPassword");
 
                StreamReader fileVariable = new StreamReader(path1);
                while ((record = fileVariable.ReadLine()) != null)
                {
                    names[x] = Getfield(record, 1);
                    password[x] = Getfield(record, 2);     
                    Console.WriteLine(names[x] + "\t\t\t" + password[x]);
                    x = x + 1;
                }
            }
            else
            {
                Console.WriteLine("File doesnt exist");
            }
        }
        public static void displayUsersForUser(string[] password, string[] names, string[] email, string[] address, string[] contact, string path1, ref int x)
        {
            string record;
            if (File.Exists(path1))
            {
                Console.WriteLine("Name \t Password \t Email \t Address \t Contact ");
                StreamReader fileVariable = new StreamReader(path1);
                while ((record = fileVariable.ReadLine()) != null)
                {
                    names[x] = Getfield(record, 1);
                    password[x] = Getfield(record, 2);       
                    email[x] = Getfield(record, 3);
                    address[x] = Getfield(record, 4);
                    contact[x] = Getfield(record, 5);
                    Console.WriteLine(names[x] + "\t" + password[x] + "\t" + email[x] + "\t" + address[x] + "\t" + contact[x]);
                    x = x + 1;
                }
            }
        }
      

        public static string Getfield(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma = comma + 1;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        public static int Userfind(string name, string pass, string[] password, string[] names, int idx)
        {
            int index = -1;
            for (int x = 0; x < idx; x++)
            {
                if (name == names[x] && pass == password[x])
                {
                    index = x; 
                    break;
                }
            }
            return index;
        }
     
        public static void Readuserdata(string[] password, string[] names, string path, ref int x)
        {
            string record;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                while ((record = fileVariable.ReadLine()) != null)
                {
                    names[x] = Getfield(record, 1);
                    password[x] = Getfield(record, 2);
                    x++;
                }
                fileVariable.Close();
            }
        }

    }
}
