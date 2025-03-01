using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using problem1.DL;

namespace problem1.BL
{
    internal class DegreeProgram
    {
        public string title;
        public string duration;
        public int seats;
        public List<Subject> Subjects;

        public DegreeProgram()
        {

        }

        public DegreeProgram(string title, string duration, int seats)
        {
            this.title = title;
            this.duration = duration;
            this.seats = seats;
            Subjects = new List<Subject>();
        }

        
    }

}
