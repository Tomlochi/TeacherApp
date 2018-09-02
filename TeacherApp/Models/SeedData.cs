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
                if (context.Persons.Any() || context.Teachers.Any() || context.Courses.Any())
                {
                    return; // DB has been seeded.
                }

                // create new entities
                Course linearAlgebra = new Course
                {
                    CourseName = "Linear Algebra",
                    Credits = 5
                };
                Course linearAlgebra2 = new Course
                {
                    CourseName = "Linear Algebra 2",
                    Credits = 3
                };
                Course calculus = new Course
                {
                    CourseName = "Calculus",
                    Credits = 5
                };
                Course computerStructure = new Course
                {
                    CourseName = "Computer Structure",
                    Credits = 4
                };
                Course algorithms = new Course
                {
                    CourseName = "Algorithms",
                    Credits = 4
                };
                Course  webApps= new Course
                {
                    CourseName = "Web Applications",
                    Credits = 6
                };
                Course  introToCompSci= new Course
                {
                    CourseName = "Intro to Computer Science",
                    Credits = 4
                };
                Teacher noa = new Teacher
                {
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
                Teacher roy = new Teacher
                {
                    FirstName = "Roy",
                    LastName = "Schwartz",
                    Phone = "0526624334",
                    Gender = "Male",
                    Email = "Roy@gmail.com",
                    Address = "Tel Aviv",
                    DateOfBirth = new DateTime(1990, 06, 26),
                    IsAdmin = false,
                    Degree = "Computer Science",
                    Institution = "Collage of Managment",
                    Graduated = new DateTime(2018,08,01),
                    About = "Loves sports and the nature, very skilled with numbers!",
                    Rating = 0,
                    LessonPrice = 140,
                    ImagePath = "",
                    Password = "1234"
                };
                TeacherCourse noaCalculus = new TeacherCourse
                {
                    Teacher = noa,
                    Course = calculus
                };
                TeacherCourse noaLinearAlgebra = new TeacherCourse
                {
                    Teacher = noa,
                    Course = linearAlgebra
                };
                TeacherCourse royLinearAlgebra = new TeacherCourse
                {
                    Teacher = roy,
                    Course = linearAlgebra
                };
                TeacherCourse royAlgo = new TeacherCourse
                {
                    Teacher = roy,
                    Course = algorithms
                };
                TeacherCourse royWebApps = new TeacherCourse
                {
                    Teacher = roy,
                    Course = webApps
                };
                Person tom = new Person
                {
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
                Review review = new Review
                {
                    Teacher = noa,
                    Rating = 5,
                    ReviewContent = "Great Teacher!",
                    Person = liran,
                    Published = DateTime.Now
                };
                noa.Reviews.Add(review);
                liran.ReviewsSubmittedByUser.Add(review);
                // add entities to context
                context.Persons.AddRange(tom, liran);
                context.TeachersCourses.AddRange(noaLinearAlgebra, noaCalculus, royAlgo, royLinearAlgebra, royWebApps);
                context.Teachers.Add(noa);
                context.Teachers.Add(roy);
                context.SaveChanges();
            }
        }
    }
}
