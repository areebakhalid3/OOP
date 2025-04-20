using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class GradedCourse

    {
        protected string coursename;
        private int gradePoint;
        protected int marks;
        public GradedCourse(string courseName, int marks) //for marks
        {
            this.coursename = courseName;
            this.marks = marks;
            this.gradePoint = getGradePoint();
        }
        public GradedCourse(string courseName, int gradePoint, bool isGradePoint) //for gp
        {
            this.coursename = courseName;
            this.gradePoint = gradePoint;
        }
        public int getGradePoint()
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
        public void setGradePoint(int gradePoint)
        {
            this.gradePoint = gradePoint;

        }
        public int getGradePointValue()
        {
            return gradePoint;
        }
        public string isPassed()
        {
            if (gradePoint >= 2)
            {
                return "Passed";
            }
            else
            {
                return "Failed";
            }
        }
    }
}
