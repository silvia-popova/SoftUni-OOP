using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Students
{
    public class Student
    {
        public string name;
        public static int count;

        public Student(string name)
        {
            this.name = name;
            count ++;
        }
    }

    public static class StudentGroup
    {
        public static HashSet<string> uniqueStudents = new HashSet<string>();
        public static int count;

        public static int Count
        {
            get { return uniqueStudents.Count; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            while (name != "End")
            {
                StudentGroup.uniqueStudents.Add(name);
                name = Console.ReadLine();
            }

            Console.WriteLine(StudentGroup.Count);
        }
    }
}
