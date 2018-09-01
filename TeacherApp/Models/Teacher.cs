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
        public double Rating { get; set; }

        public string About { set; get; }

        public int LessonPrice { get; set; }

        public string ImagePath { get; set; }

        public ICollection<TeacherCourse> TeachersCourses { get; set; } = new List<TeacherCourse>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
        public void AddReview(Review review)
        {
            Reviews.Add(review);
            Rating = Reviews.Average<Review>(r => r.Rating);
        }

    }
}
