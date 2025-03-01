using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using problem1.BL;
using problem1.DL;

namespace problem1.UI
{
    internal class DegreeProgramOutput
    {
        public static void adddeg()
        {
            Console.Write("Enter Degree Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Degree Duration: ");
            int duration = int.Parse(Console.ReadLine());

            Console.Write("Enter Seats for Degree:  ");
            int seats = int.Parse(Console.ReadLine());

            DL.SortDegreePrograms.AddDegreeInfo(name, duration, seats, DL.SortDegreePrograms.path);
        }
        public static void addsub()
        {
            Console.Write("Enter How many Subjects to Enter: ");

            int no = int.Parse(Console.ReadLine());

            for (int i = 0; i < no; i++)
            {
                Console.Write("Enter Subject Code: ");
                int code = int.Parse(Console.ReadLine());

                Console.Write("Enter Subject Credit Hours: ");
                int ch = int.Parse(Console.ReadLine());

                Console.Write("Enter Subject Type: ");
                string type = Console.ReadLine();

                Console.Write("Enter Subject Fee: ");
                float fee= float.Parse(Console.ReadLine());

                DL.SortSubjects.addsubinfo(code,type,ch,fee, DL.SortSubjects.path);
                BL.Subject.Code = code;
            }
        }
    }
}
