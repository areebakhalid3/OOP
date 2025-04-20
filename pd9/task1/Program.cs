using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            AbsoluteGradedCourse a1 = new AbsoluteGradedCourse("Software Engineering", 85);
            AbsoluteGradedCourse a2 = new AbsoluteGradedCourse("Database Management", 75);
            GradedCourse g1 = new GradedCourse("Programming Fundamentals", 10,true);
            GradedCourse g2 = new GradedCourse("Algorithms and Data Structures", 7,true);

            Project project1 = new Project("Software Development Project", a1, a2, g1, g2);
            project1.Passed();

            AbsoluteGradedCourse a3 = new AbsoluteGradedCourse("Research Methods", 70);
            AbsoluteGradedCourse a4 = new AbsoluteGradedCourse("Literature Review", 80);
            GradedCourse g3 = new GradedCourse("Statistical Analysis", 12, true);
            GradedCourse g4 = new GradedCourse("Research Findings Presentation", 10, true);

            Project project2 = new Project("Research Project", a3, a4, g3, g4);
            project2.Passed();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
