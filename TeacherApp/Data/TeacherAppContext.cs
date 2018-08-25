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
        public TeacherAppContext(DbContextOptions<TeacherAppContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
        }
    }
}