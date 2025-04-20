using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    abstract class Course
    {
        protected string courseName;

        public Course(string courseName)
        {
            this.courseName = courseName;
        }

        public string getCourseName()
        {
            return courseName;
        }

        public abstract bool isPassed();
        public abstract string GetGradeDisplay();
    }
}
