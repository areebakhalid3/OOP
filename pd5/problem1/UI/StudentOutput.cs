using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using problem1.BL;
using problem1.DL;

namespace problem1.UI
{
    internal class StudentOutput
    {
        public static string[] title = new string[100];
        public static int x = 0;
        public static void AddStudent()
        {
            Console.WriteLine("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Student FSc Marks: ");
            int fscMarks = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Student ECAT Marks: ");
            int ecatMarks = int.Parse(Console.ReadLine());

            List<string> preferences = pref(); 

            List<string> availableDegrees = DL.SortDegreePrograms.AvailableDegree(DL.SortDegreePrograms.path);

            DL.SortStudents.AddStudentInfo(name, age, fscMarks, ecatMarks, preferences, availableDegrees, DL.SortStudents.path);
            BL.Student.Name = name;
        }
        public static List<String> pref()
        {
            List<String> temp = new List<String>();

            Console.WriteLine("Enter number of prefrences: ");

            int no = int.Parse(Console.ReadLine());

            for (int i = 0; i < no; i++)
            {
                Console.WriteLine("Preference no." + (i + 1) + " :");
                string preferences = Console.ReadLine();
                temp.Add(preferences);
            }
            return temp;
        }
    }
}