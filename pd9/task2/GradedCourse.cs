using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class GradedCourse : Course
    {
        private int gradePoint;
        private int marks;
        private bool isUsingGP;

        public GradedCourse(string courseName, int marks) : base(courseName) //for marks
        {
            this.marks = marks;
            this.gradePoint = calculateGP(marks);
            isUsingGP = false;
        }

        public GradedCourse(string courseName, int gradePoint, bool isGradePoint) : base(courseName) //for gp
        {
            this.gradePoint = gradePoint;
            isUsingGP = true;
        }

        public int calculateGP(int marks)
        {

            if (marks >= 90 && marks <= 100)
            {
                return gradePoint = 12;

            }
            if (marks >= 80 && marks < 90)
            {
                return gradePoint = 10;

            }
            if (marks >= 70 && marks <= 80)
            {
                return gradePoint = 7;

            }
            if (marks >= 60 && marks < 70)
            {
                return gradePoint = 4;

            }
            if (marks >= 50 && marks <= 60)
            {
                return gradePoint = 02;

            }
            if (marks >= 40 && marks < 50)
            {
                return gradePoint = 0;

            }
            else
            {
                return gradePoint = -3;

            }

        }
        public override bool isPassed()
        {
            return gradePoint >= 2;
        }

        public override string GetGradeDisplay()
        {
            return $"{gradePoint}";
        }
    }

}
