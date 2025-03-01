using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using problem1.BL;

namespace problem1.DL
{
    internal class SortStudents
    {
        public static string[] degree = new string[100];
        public static string path = "D:\\oop\\PD\\pd5\\problem1\\studentinfo.txt";
        public static int x = 0;
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

        public static void AddStudentInfo(string name, int age, int fscMarks, int ecatMarks, List<string> preferences, List<string> availableDegrees, string path)
        {
            double merit = ((fscMarks / 1100.0) * 0.50 + (ecatMarks / 400.0) * 0.50) * 100;

            string assignedDegree = null;

            foreach (var degree in preferences)
            {
                if (availableDegrees.Contains(degree) && merit >= 80)
                {
                    assignedDegree = degree;
                    break;
                }
            }

            if (assignedDegree != null)
            {
                using (StreamWriter fileVariable = new StreamWriter(path, true))
                {
                    fileVariable.WriteLine(name + "," + age + "," + fscMarks + "," + ecatMarks + "," + assignedDegree);
                }
                Console.WriteLine($"{name} got admission in {assignedDegree}");
            }
            else
            {
                Console.WriteLine($"{name} did not get admission in any preferred program.");
            }
        }

        public static void merit(string path)
        {
            if (File.Exists(path))
            {
                string[] records = File.ReadAllLines(path);
                List<string> updatedRecords = new List<string>();

                foreach (string record in records)
                {
                    string[] fields = record.Split(',');
                    string studentName = fields[0];
                    int studentAge = int.Parse(fields[1]);
                    int studentFsc = int.Parse(fields[2]);
                    int studentEcat = int.Parse(fields[3]);

                    double merit = ((studentFsc / 1200.0) * 0.70) + ((studentEcat / 400.0) * 0.30);

                    List<string> preferences = UI.StudentOutput.pref();
                    List<string> availableDegrees = DL.SortDegreePrograms.AvailableDegree(DL.SortDegreePrograms.path);

                    bool admitted = false;
                    string admittedProgram = "None";

                    foreach (var preference in preferences)
                    {
                        if (merit > 80 && availableDegrees.Contains(preference))
                        {
                            admittedProgram = preference; 
                            Console.WriteLine(studentName + " got admission in " + admittedProgram);
                            admitted = true;
                            break; 
                        }
                    }

                    if (!admitted)
                    {
                        Console.WriteLine(studentName + " did not get admission in any preferred program.");
                    }

                    updatedRecords.Add(studentName + "," + studentAge + "," + studentFsc + "," + studentEcat + "," + admittedProgram);
                }

                File.WriteAllLines(path, updatedRecords); 
            }
        }



        public static void reg(string[] name, int[] age, int[] fscMarks, int[] ecatMarks, string path, ref int x)
        {
            string record;
            bool studentFound = false;

            Console.WriteLine("Name\tAge\tFsc Marks\tECAT Marks");

            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                while ((record = fileVariable.ReadLine()) != null && x < name.Length)
                {
                    name[x] = Getfield(record, 1);
                    age[x] = int.Parse(Getfield(record, 2));
                    fscMarks[x] = int.Parse(Getfield(record, 3));
                    ecatMarks[x] = int.Parse(Getfield(record, 4));

                    double merit = ((fscMarks[x] / 1200.0) * 0.70) + ((ecatMarks[x] / 400.0) * 0.30);

                    Console.WriteLine($"{name[x]}\t{age[x]}\t{fscMarks[x]}\t{ecatMarks[x]}");
                    studentFound = true;
                    x++;
                }
                fileVariable.Close();
            }

            if (!studentFound)
            {
                Console.WriteLine("No registered students found.");
            }
        }


        public static List<string> StudentName(string path)
        {
            List<string> temp = new List<string>();

            if (File.Exists(path))
            {
                using (StreamReader fileVariable = new StreamReader(path))
                {
                    string record;
                    while ((record = fileVariable.ReadLine()) != null)
                    {
                        string studentName = Getfield(record, 1);
                        temp.Add(studentName);
                    }
                }
            }
            return temp;
        }

        public static void viewStudent(string path)
        {
            Console.Write("Enter the Degree Program to search for: ");
            string search = Console.ReadLine().Trim();

            bool found = false;

            if (File.Exists(path))
            {
                using (StreamReader fileReader = new StreamReader(path))
                {
                    string record;
                    Console.WriteLine("\nStudents in the '" + search + "' Program:");
                    Console.WriteLine("-------------------------------------------------");

                    while ((record = fileReader.ReadLine()) != null)
                    {
                        string studentName = Getfield(record, 1);
                        string degprog = Getfield(record, 2);

                        if (degprog.Trim().ToLower() == search.ToLower())
                        {
                            Console.WriteLine("Student Name: " + studentName);
                            found = true;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Error: Student data file not found!");
                return;
            }

            if (!found)
            {
                Console.WriteLine("No students found in the '" + search + "' program.");
            }
        }


    }
}

