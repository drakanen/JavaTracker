using JavaTracker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaTracker.Persistance
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        void SaveChanges();
        void AddStudent(Student st);
        Student GetStudent(int id);
        void DeleteStudent(int id);
    }
}