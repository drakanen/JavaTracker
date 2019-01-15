using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JavaTracker.Core;

namespace JavaTracker.Persistance
{
    public class DevelopmentStudentService : IStudentService
    {
        List<Student> savedStudents = new List<Student>();
        List<Student> students = new List<Student>();

        public DevelopmentStudentService()
        {
            Student st = new Student("Mark", "Willow", 1234);
            Student st2 = new Student("Danny", "Max", 4321);
            Student st3 = new Student("Bob", "Parker", 9876);
            students.Add(st);
            students.Add(st2);
            students.Add(st3);
        }
        public List<Student> GetAllStudents()
        {
            return students;
        }

        public void AddStudent(Student st)
        {
            students.Add(st);
        }

        public void SaveChanges()
        {
            savedStudents = students;
        }

        public Student GetStudent(int id)
        {
            foreach (var student in students)
            {
                if (student.IDNumber == id)
                {
                    return student;
                }
            }
            Console.WriteLine("Student not found.");
            return null;
        }

        public void DeleteStudent(int id)
        {
            Student st = null;
            foreach (var student in students)
            {
                if (student.IDNumber == id)
                {
                    st = student;
                    break;
                }
            }
            students.Remove(st);
            SaveChanges();
        }
    }
}