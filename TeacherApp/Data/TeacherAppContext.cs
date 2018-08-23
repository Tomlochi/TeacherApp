using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeacherApp.Models;

namespace TeacherApp.Models
{
    public class TeacherAppContext : DbContext
    {
        //    public TeacherAppContext (DbContextOptions<TeacherAppContext> options)
        //        : base(options)
        //    {
        //    }

        //    public DbSet<TeacherApp.Models.Person> Person { get; set; }

        //    public DbSet<TeacherApp.Models.Course> Course { get; set; }

        //    public DbSet<TeacherApp.Models.Degree> Degree { get; set; }

        //    public DbSet<TeacherApp.Models.Institution> Institution { get; set; }

        //    public DbSet<TeacherApp.Models.Review> Review { get; set; }

        //    public DbSet<TeacherApp.Models.Student> Student { get; set; }

        //    public DbSet<TeacherApp.Models.Teacher> Teacher { get; set; }
        //}


        public TeacherAppContext(DbContextOptions<TeacherAppContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<Degree>().ToTable("Degrees");
            modelBuilder.Entity<Institution>().ToTable("Institutions");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
        }
    }
}