using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherApp.Models
{

    public class Teacher : Person
    {
        public virtual ICollection<Course> Tutoring { get; } = new List<Course>();
        public virtual ICollection<Review> Reviews { get; } = new List<Review>();

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime Graduated { get; set; }

        public int Rating { set; get; }
        public string About { set; get; }
        public int LessonPrice { get; set; }
        public string ImagePath { get; set; }


        public Teacher()
        {
        }

        public Teacher(int id, string firstname, string lastname,string password, string phone, string gender, string email, string address, DateTime dateofbirth,string degree , string institution, List<Course> tutoring, DateTime graduated, List<Review> review, int rating, string about, int lessonPrice, string Imagepath)
             : base(id, firstname, lastname,password, phone, gender, email, address, dateofbirth, degree, institution)
        {
            this.Tutoring = tutoring;
            this.Reviews = review;
            this.Graduated = graduated;
            this.Rating = rating;
            this.About = about;
            this.LessonPrice = lessonPrice;
            this.ImagePath = Imagepath;
        }


        public Teacher(Teacher teacher)
            : base(teacher.ID, teacher.FirstName, teacher.LastName, teacher.Password ,teacher.Phone, teacher.Gender, teacher.Email, teacher.Address, teacher.DateOfBirth,teacher.Degree,teacher.Institution)
        {

            this.Tutoring = teacher.Tutoring;
            this.Reviews = teacher.Reviews;
            this.Graduated = teacher.Graduated;
            this.Rating = teacher.Rating;
            this.About = teacher.About;
            this.LessonPrice = teacher.LessonPrice;
            this.ImagePath = teacher.ImagePath;
        }



    }
}
