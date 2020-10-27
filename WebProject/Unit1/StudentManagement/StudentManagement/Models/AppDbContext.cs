using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Student> students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

            //获取当前系统中所有领域模型上的外键列表
            var foreignKeys = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());

            foreach (var foreignKey in foreignKeys)
            {
                //将它们的删除行为配置为Restrict，即无操作
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
