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
        public DbSet<TeacherCourse> TeachersCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // represent many-to-many relationship by mapping two separate one-to-many relationship
            modelBuilder.Entity<TeacherCourse>()
                .HasKey(tc => new { tc.TeacherID, tc.CourseID });

            modelBuilder.Entity<TeacherCourse>()
                .HasOne(tc => tc.Teacher)
                .WithMany(t => t.TeachersCourses)
                .HasForeignKey(tc => tc.CourseID);

            modelBuilder.Entity<TeacherCourse>()
                .HasOne(tc => tc.Course)
                .WithMany(c => c.TeachersCourses)
                .HasForeignKey(tc => tc.TeacherID);

            modelBuilder.Entity<Review>()
                .HasKey(r => new { r.TeacherID, r.PersonID });

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Reviews)
                .WithOne(r => r.Teacher)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .HasMany(p=> p.ReviewsSubmittedByUser)
                .WithOne(r => r.Person)
                .IsRequired();

            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<TeacherCourse>().ToTable("TeacherCourses");
        }
    }
}