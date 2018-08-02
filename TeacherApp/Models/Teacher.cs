using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherApp.Models
{

    public class Teacher : Person
    {
        public List<Course> Tutoring { get; set; }
        public DateTime Enrolled { get; set; }
        public DateTime Graduated { get; set; }
        public List<Review> Reviews { get; set; }
        public Institution Institution { get; set; }
        public int Rating { set; get; }
        public string About { set; get; }
        public int LessonPrice { get; set; }
        public string ImagePath { get; set; }


        public Teacher()
        {
            List<Course> courses = new List<Course>();
            List<Review> reviews = new List<Review>();
        }

        public Teacher(int id, string firstname, string lastname, string phone, Gender gender, string email, string address, DateTime dateofbirth, DateTime activesince, List<Course> tutoring, DateTime enrolled, DateTime graduated, List<Review> review, int rating, string about, int lessonPrice, string Imagepath)
             : base(id, firstname, lastname, phone, gender, email, address, dateofbirth, activesince)
        {

            this.Tutoring = tutoring;
            this.Enrolled = enrolled;
            this.Graduated = graduated;
            this.ActiveSince = activesince;
            this.Reviews = review;
            this.Rating = rating;
            this.About = about;
            this.LessonPrice = lessonPrice;
            this.ImagePath = Imagepath;
        }
        public Teacher(Teacher teacher)
            : base(teacher.ID, teacher.FirstName, teacher.LastName, teacher.Phone, teacher.Gender, teacher.Email, teacher.Address, teacher.DateOfBirth, teacher.ActiveSince)
        {

            this.Tutoring = teacher.Tutoring;
            this.Enrolled = teacher.Enrolled;
            this.Graduated = teacher.Graduated;
            this.ActiveSince = teacher.ActiveSince;
            this.Reviews = teacher.Reviews;
            this.Institution = teacher.Institution;
            this.Rating = teacher.Rating;
            this.About = teacher.About;
            this.LessonPrice = teacher.LessonPrice;
            this.ImagePath = teacher.ImagePath;
        }



    }
}
