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
        public TeacherAppContext (DbContextOptions<TeacherAppContext> options)
            : base(options)
        {
        }

        public DbSet<TeacherApp.Models.Person> Person { get; set; }

        public DbSet<TeacherApp.Models.Course> Course { get; set; }

        public DbSet<TeacherApp.Models.Degree> Degree { get; set; }

        public DbSet<TeacherApp.Models.Institution> Institution { get; set; }

        public DbSet<TeacherApp.Models.Review> Review { get; set; }

        public DbSet<TeacherApp.Models.Student> Student { get; set; }

        public DbSet<TeacherApp.Models.Teacher> Teacher { get; set; }
    }
}
