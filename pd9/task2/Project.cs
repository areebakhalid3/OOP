using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Project
    {
        private string projectName;
        private List<Course> courses;

        public Project(string name, List<Course> courses)
        {
            this.projectName = name;
            this.courses = courses;
        }

        public void Passed()
        {
            int passCount = 0;

            foreach (var course in courses)
            {
                string status;
                if (course.isPassed())
                {
                    status = "Passed";
                }
                else
                {
                    status = "Failed";
                }

                Console.WriteLine($"Course: {course.getCourseName()}, Grade: {course.GetGradeDisplay()}, Status: {status}");

                if (course.isPassed())
                    passCount++;
            }

            if (passCount >= 3)
            {
                Console.WriteLine($"You have passed the {projectName}.\n");
            }
            else
            {
                Console.WriteLine($"You have failed the {projectName}.\n");
            }
        }
    }

}
