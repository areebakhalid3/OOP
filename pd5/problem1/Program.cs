using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using problem1.UI;

namespace problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            int x = 0;
            List<string> list = new List<string>();

            string path = "D:\\oop\\PD\\pd5\\problem1\\degreeinfo.txt";

            string[] degree = new string[100];
            string[] name = new string[100];
            int[] age = new int[100];
            int[] fscMarks = new int[100];
            int[] ecatMarks = new int[100];
            int[] code = new int[100];
            int[] ch = new int[100];
            string[] type = new string[100];
            int[]fee = new int[100];


            while (true)
            {
                UI.Mainmenu.printHeader();
                int option = UI.Mainmenu.Menu();

                if (option == 1)
                {
                    UI.StudentOutput.AddStudent();
                    list = DL.SortDegreePrograms.AvailableDegree(path);
                    for (int i = 0; i < list.Count(); i++)
                    {
                        Console.WriteLine(list[i]);
                    }
                

                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (option == 2)
                {
                    UI.DegreeProgramOutput.adddeg();
                    UI.DegreeProgramOutput.addsub();

                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (option == 3)
                {
                    DL.SortStudents.merit(DL.SortStudents.path);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (option == 4)
                {
                     DL.SortStudents.reg(name, age, fscMarks, ecatMarks, DL.SortStudents.path, ref x);
                  
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (option == 5)
                {
                    DL.SortStudents.viewStudent(path);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (option == 6)
                {
                    DL.SortSubjects.regsub();

                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (option == 7)
                {
                    DL.SortSubjects.fees(DL.SortSubjects.path);
                    
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (option == 8)
                {
                    Environment.Exit(0);
                }
            }
        }

    }
}