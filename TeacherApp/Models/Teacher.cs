using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherApp.Models
{

    public class Teacher : Person
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime Graduated { get; set; }

        [DisplayFormat(NullDisplayText = "No Rating Yet")]
        public int Rating { set; get; }

        public string About { set; get; }

        public int LessonPrice { get; set; }

        public string ImagePath { get; set; }

        public ICollection<TeacherCourse> TeachersCourses { get; set; }

        public ICollection<Review> Reviews { get; set; } 

        public void AddCourse(Course course)
        {
            TeacherCourse tc = new TeacherCourse
            {
                TeacherID = ID,
                CourseID = course.CourseID,
                Teacher = this,
                Course = course
            };
            TeachersCourses.Add(tc);
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
