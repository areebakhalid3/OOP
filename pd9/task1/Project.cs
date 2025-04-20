using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Project
    {
        private string projectName;
        private AbsoluteGradedCourse agc1;
        private AbsoluteGradedCourse agc2;
        private GradedCourse gc1;
        private GradedCourse gc2;

        public Project(string projectName, AbsoluteGradedCourse agc1, AbsoluteGradedCourse agc2, GradedCourse gc1, GradedCourse gc2)
        {
            this.projectName = projectName;
            this.agc1 = agc1;
            this.agc2 = agc2;
            this.gc1 = gc1;
            this.gc2 = gc2;

        }

        public string GetProjectName()
        {
            return projectName;
        }

        public void Passed()
        {
            int passCount = 0;

            Console.WriteLine("Your grade is: " + agc1.getGrade());
            if (agc1.isPassed() == "Passed")
            {
                passCount++; 
            }

            Console.WriteLine("Your grade is: " + agc2.getGrade());
            if (agc2.isPassed() == "Passed")
            {
                passCount++;
            }

            Console.WriteLine("Your grade is: " + gc1.getGradePointValue());
            if (gc1.isPassed() == "Passed")
            {
                passCount++;
            }

            Console.WriteLine("Your grade is: " + gc2.getGradePointValue());
            if (gc2.isPassed() == "Passed")
            {
                passCount++;
            }

            if (passCount >= 3)
            {
                Console.WriteLine("You have passed " + projectName);

            }
            else
            {
                Console.WriteLine("You have failed " + projectName);
            }

        }

    }
}
