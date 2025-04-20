using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            AbsoluteGradedCourse c1 = new AbsoluteGradedCourse("Software Engineering", 85);
            AbsoluteGradedCourse c2 = new AbsoluteGradedCourse("Database Management", 75);
            GradedCourse c3 = new GradedCourse("Programming Fundamentals", 10, true);
            GradedCourse c4 = new GradedCourse("Algorithms and Data Structures", 7, true);

            List<Course> softwarecourse = new List<Course>();
            softwarecourse.Add(c1);
            softwarecourse.Add(c2);
            softwarecourse.Add(c3);
            softwarecourse.Add(c4);

            Project project1 = new Project("Software Development Project", softwarecourse);
            project1.Passed();

            AbsoluteGradedCourse c5 = new AbsoluteGradedCourse("Research Methods", 70);
            AbsoluteGradedCourse c6 = new AbsoluteGradedCourse("Literature Review", 80);
            GradedCourse c7 = new GradedCourse("Statistical Analysis", 12, true);
            GradedCourse c8 = new GradedCourse("Research Findings Presentation", 10, true);

            List<Course> researchcourse = new List<Course>();
            researchcourse.Add(c5);
            researchcourse.Add(c6);
            researchcourse.Add(c7);
            researchcourse.Add(c8);

            Project project2 = new Project("Research Project", researchcourse);
            project2.Passed();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

    }
}
