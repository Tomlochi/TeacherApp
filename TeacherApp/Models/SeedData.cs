using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TeacherApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TeacherAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<TeacherAppContext>>()))
            {
                // Look for any data saved to the context
                if (context.Persons.Any() || context.Teachers.Any() || context.Courses.Any() )
                {
                    return; // DB has been seeded.
                }

                // create new entities
                Course linearAlgebra = new Course
                {
                    //CourseID = 1,
                    CourseName = "Linear Algebra",
                    Credits = 5
                };
                Course calculus = new Course
                {
                    //CourseID = 2,
                    CourseName = "Calculus",
                    Credits = 5
                };
                Teacher noa = new Teacher
                {
                    //ID = 3,
                    FirstName = "Noa",
                    LastName = "Cohen",
                    Phone = "0526666666",
                    Gender = "Female",
                    Email = "noacohen@gmail.com",
                    Address = "Tel Aviv",
                    DateOfBirth = new DateTime(1991, 03, 03),
                    IsAdmin = false,
                    Degree = "Computer Science",
                    Institution = "Collage of Managment",
                    Graduated = new DateTime(2018,08,01),
                    About = "Teaching math since 2016",
                    Rating = 5,
                    LessonPrice = 100,
                    ImagePath = "",
                    Password = "1234"
                };
                noa.AddCourse(calculus);
                Person tom = new Person
                {
                    //ID = 2,
                    FirstName = "Tom",
                    LastName = "Lochi",
                    Phone = "0523333333",
                    Gender = "Male",
                    Email = "tomlohchi@gmail.com",
                    Address = "Tel Aviv",
                    DateOfBirth = new DateTime(1991, 02, 02),
                    IsAdmin = true,
                    Degree = "Computer Science",
                    Institution = "Collage of Managment",
                    Password = "1234"
                };
                Person liran = new Person
                {
                    //ID = 1,
                    FirstName = "Liran",
                    LastName = "Ziv",
                    Phone = "0525555555",
                    Gender = "Male",
                    Email = "liranziv@gmail.com",
                    Address = "Ramat Gan",
                    DateOfBirth = new DateTime(1991, 01, 01),
                    IsAdmin = true,
                    Degree = "Computer Science",
                    Institution = "Collage of Managment",
                    Password = "1234"
                };

                // add entities to context
                context.Persons.AddRange(tom, liran);
                context.Courses.AddRange(calculus, linearAlgebra);
                context.Teachers.Add(noa);
                context.SaveChanges();
            }
        }
    }
}
