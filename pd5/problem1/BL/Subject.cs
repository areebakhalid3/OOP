using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem1.BL
{
    internal class Subject
    {
        public static int Code;
        public int creditHours;
        public string subjectType;
        public int subjectFee;

        public Subject(int code, string subjectType, int creditHours, int subjectFee)
        {
            Code = code;
            this.subjectType = subjectType;
            this.creditHours = creditHours;
            this.subjectFee = subjectFee;
        }

    }
}
