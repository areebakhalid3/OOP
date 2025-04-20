using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class AbsoluteGradedCourse : Course
    {
        private int marks;
        private string grade;

        public AbsoluteGradedCourse(string courseName, int marks) : base(courseName)
        {
            this.marks = marks;
            this.grade = getGrade();
        }

        public string getGrade()
        {

            if (marks >= 90 && marks <= 100)
            {
                return grade = "A+";
            }
            else if (marks >= 80 && marks < 90)
            {

                return grade = "A";

            }
            else if (marks >= 70 && marks <= 80)
            {

                return grade = "B";

            }
            else if (marks >= 60 && marks < 70)
            {

                return grade = "C";

            }
            else if (marks >= 50 && marks <= 60)
            {

                return grade = "D";

            }
            else
            {

                return grade = "F";

            }

        }


        public override bool isPassed()
        {
            return grade != "F";
        }

        public override string GetGradeDisplay()
        {
            return $"{grade}";
        }
    }

}
