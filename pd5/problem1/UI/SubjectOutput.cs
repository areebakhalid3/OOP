using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using problem1.DL;
using problem1.BL;
using System.IO;
using System.Xml.Linq;
namespace problem1.UI
{
    internal class SubjectOutput
    {
        public static void AddSubject()
        {
            Console.Write("Enter Subject Code: ");
            int Code = int.Parse(Console.ReadLine());

            Console.Write("Enter Subject Type: ");
            string subjectType = Console.ReadLine();

            Console.Write("Enter Credit Hours: ");
            int creditHours = int.Parse(Console.ReadLine());

            Console.Write("Enter Subject Fee: ");
            float subjectFee = float.Parse(Console.ReadLine());

            DL.SortSubjects.addsubinfo(Code, subjectType, creditHours, subjectFee, DL.SortSubjects.path);
            Console.WriteLine("Subject added successfully.");
        }
    }
}
