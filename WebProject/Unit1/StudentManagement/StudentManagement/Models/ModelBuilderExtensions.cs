using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "李云龙",
                    ClassName = ClassNameEnum.FirstGrade,
                    Email = "lyl@email.com"
                },
                new Student
                {
                    Id = 2,
                    Name = "李逍遥",
                    ClassName = ClassNameEnum.SecondGrade,
                    Email = "lxy@email.com"
                },
                new Student
                {
                    Id = 3,
                    Name = "龙阳",
                    ClassName = ClassNameEnum.GradeThree,
                    Email = "ly@email.com"
                }
            );
        }
    }
}
