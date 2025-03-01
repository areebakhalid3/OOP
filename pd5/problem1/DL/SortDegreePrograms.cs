using problem1.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem1.DL
{
    internal class SortDegreePrograms
    {
        public static string path = "D:\\oop\\PD\\pd5\\problem1\\degreeinfo.txt";

        public static List<BL.DegreeProgram> degprog = new List<BL.DegreeProgram>();
        public static void AddDegree(BL.DegreeProgram deg)
        {
            degprog.Add(deg);
        }
        public static List<string> AvailableDegree(string path)
        {
            List<string> degrees = new List<string>();

            if (File.Exists(path))
            {
                using (StreamReader file = new StreamReader(path))
                {
                    string record;
                    while ((record = file.ReadLine()) != null)
                    {
                        string field = record.Split(',')[0];
                        if (!degrees.Contains(field))
                        {
                            degrees.Add(field);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesn't exist or is empty.");
            }

            Console.WriteLine("Available Degrees are:");
            foreach (var degree in degrees)
            {
                Console.WriteLine(degree);
            }

            return degrees;
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
        public static void ReadDataofDegree(string[] degree, int[] duration, int[] seats, string path, ref int x)
        {
            string record;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                while ((record = fileVariable.ReadLine()) != null)
                {
                    degree[x] = Getfield(record, 1);
                    duration[x] = int.Parse(Getfield(record, 2));
                    seats[x] = int.Parse(Getfield(record, 3));
                    x++;
                }
                fileVariable.Close();
            }
        }
        public static void AddDegreeInfo(string degree, int duration, int seats, string path)
        {

            if (File.Exists(path))
            {
                StreamWriter fileVariable = new StreamWriter(path, true);
                fileVariable.WriteLine(degree + "," + duration + "," + seats);
                fileVariable.Flush();
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Checking file at path: " + path);
                Console.WriteLine("File doesn't exist.");
            }
        }
    }
}
