using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<SQLStudentRepository> logger;

        public SQLStudentRepository(AppDbContext context,ILogger<SQLStudentRepository> logger)
        {
            _context = context;
            this.logger = logger;
        }
        public Student AddStudent(Student student)
        {
            _context.students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student DeleteStudent(int id)
        {
            Student student = _context.students.FirstOrDefault((s) => s.Id == id);
            _context.Remove(student);
            _context.SaveChanges();
            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            logger.LogTrace("学生信息Trace(跟踪)Log");
            logger.LogDebug("学生信息Debug(调试)Log");
            logger.LogInformation("学生信息 信息(Information)Log");
            logger.LogWarning("学生信息 警告(Warning)Log");
            logger.LogError("学生信息 错误(Error)Log");
            logger.LogCritical("学生信息 严重(Critical)Log");
            return _context.students;
        }

        public Student GetStudent(int id)
        {
            Student student = _context.students.FirstOrDefault((s) => s.Id == id);
            return student;
        }

        public Student UpdateStudent(Student updateStudent)
        {
            var student = _context.Attach(updateStudent);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updateStudent;
        }
    }
}
