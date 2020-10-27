using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public interface IStudentRepository
    {
        Student GetStudent(int id);
        IEnumerable<Student> GetAllStudents();
        Student AddStudent(Student student);
        Student UpdateStudent(Student student);
        Student DeleteStudent(int id);
    }
}
