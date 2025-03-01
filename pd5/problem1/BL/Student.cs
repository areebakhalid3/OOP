using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using problem1.DL;

namespace problem1.BL
{
    internal class Student
    {
        public static string Name;
        public int Age;
        public float fscMarks;
        public float ecatMarks;
        public List<Subject> regsub;

        public Student(string name, int Age, float fscMarks, float ecatMarks,List<Subject> regsub)
        {
            Name = name;
            this.Age = Age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.regsub = regsub;
        }

        public Student() { }
    
    }
}
