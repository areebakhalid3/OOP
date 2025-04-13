using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {

            Person person = new Person("Areeba Khalid", "123 street");
            Student student = new Student("Nashra", "234 ST", "Computer Science", 2, 15000);
            Staff staff = new Staff("Hajra", "789 St", "UET", 50000);

            Console.WriteLine(person.To_String());
            Console.WriteLine(student.ToString());
            Console.WriteLine(staff.ToString());


        }
    }
}
