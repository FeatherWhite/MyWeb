using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class MockStudentRepository:IStudentRepository
    {
        private List<Student> _studentList;
        public MockStudentRepository()
        {
            _studentList = new List<Student>()
            {
                new Student{Id = 1,Name="赵政委",ClassName=ClassNameEnum.FirstGrade,Email="123@email.com"},
                new Student{Id = 2,Name="钱掌柜",ClassName=ClassNameEnum.FirstGrade,Email="124@email.com"},
                new Student{Id = 3,Name="孙区长",ClassName=ClassNameEnum.SecondGrade,Email="125@email.com"},
                new Student{Id = 4,Name="李云龙",ClassName=ClassNameEnum.GradeThree,Email="126@email.com"},
            };
        }

        public Student AddStudent(Student student)
        {
            student.Id = _studentList.Max((s) => s.Id) + 1;
            _studentList.Add(student);
            return student;
        }

        public Student DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentList;
        }

        public Student GetStudent(int id)
        {
            return _studentList.Find((student) => student.Id == id);
        }

        public Student UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
