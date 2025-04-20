using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter the Project Name:");
                string projectName = Console.ReadLine();

                List<Course> courseList = new List<Course>();

                for (int i = 1; i <= 4; i++)
                {
                    Console.WriteLine($"Enter details for Course {i}:");

                    Console.Write("Course Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter '1' to input Marks or '2' to input Grade Point: ");
                    string inp = Console.ReadLine();

                    if (inp == "1")
                    {
                        Console.Write("Enter Marks (0-100): ");
                        int marks = int.Parse(Console.ReadLine());
                        courseList.Add(new AbsoluteGradedCourse(name, marks));
                    }
                    else if (inp == "2")
                    {
                        Console.Write("Enter Grade Point (0-12): ");
                        int gp = int.Parse(Console.ReadLine());
                        courseList.Add(new GradedCourse(name, gp, true));
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, skipping this course.");
                    }
                }

                Project project = new Project(projectName, courseList);
                project.Passed();

                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }


        }
    }
