using problem1.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem1.DL
{
        internal class SortSubjects
        {

        public static int x = 0;
        public static string path = "D:\\oop\\PD\\pd5\\problem1\\subjectinfo.txt";
       
       
        public static void addsubinfo(int code,string sub,int ch, float fee, string path1)
        {
            if (File.Exists(path1))
            {
                StreamWriter fileVariable = new StreamWriter(path1, true);
                fileVariable.WriteLine(code + "," + ch + "," + sub + "," + fee);
                fileVariable.Flush();
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File doesnt exist.");
            }
        }
        public static void regsub()
        {
            List<string> studentNames = DL.SortStudents.StudentName(DL.SortStudents.path);
            List<int> subjectCodes = SubjectCode(path);

            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();

            Console.Write("Enter Subject Code: ");
            int subjectCode=int.Parse(Console.ReadLine());
          

            if (studentNames.Contains(studentName) && subjectCodes.Contains(subjectCode))
            {
                Console.WriteLine("Subjects registered successfully.");
            }
            else
            {
                Console.WriteLine("Subjects could not be registered.");
            }
        }

        public static List<int> SubjectCode(string path)
        {
            List<int> temp = new List<int>();

            if (File.Exists(path))
            {
                using (StreamReader fileVariable = new StreamReader(path))
                {
                    string record;
                    while ((record = fileVariable.ReadLine()) != null)
                    {
                        int code = int.Parse(Getfield(record, 1));
                        temp.Add(code);
                    }
                }
            }
            return temp;
        }


        public static void fees(string path)
        {
            int totalFees = 0;

            if (File.Exists(path))
            {
                using (StreamReader fileVariable = new StreamReader(path))
                {
                    string record;

                    while ((record = fileVariable.ReadLine()) != null)
                    {
                        int creditHours = int.Parse(Getfield(record, 2));
                        int feePerCreditHour = int.Parse(Getfield(record, 4));

                        totalFees += creditHours * feePerCreditHour;
                    }
                }
            }
            Console.WriteLine("Total Fees for All Registered Students: " + totalFees);
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
    }

}

