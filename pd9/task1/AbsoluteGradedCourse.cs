using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class AbsoluteGradedCourse
    {
        protected string coursename;
        protected int marks;
        protected string grade;

        public AbsoluteGradedCourse(string coursename, int marks)
        {
            this.coursename = coursename;
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

        public void setGrade(string grade)
        {
            this.grade = grade;

        }
        public string isPassed()
        {
            getGrade();
            if (grade == "F")
            {
                return "Failed";
            }
            else
            {
                return "Passed";
            }
        }
        public string getcourseName()
        {
            return coursename;
        }
        public int getMarks()
        {
            return marks;
        }
        public void setcourseName(string coursename)
        {
            this.coursename =coursename;

        }
        public void setmarks(int marks)
        {
            this.marks = marks;

        }

    }
 }

