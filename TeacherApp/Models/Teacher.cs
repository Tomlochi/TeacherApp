using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherApp.Models
{
    public class Teacher : Person
    {
        private double _rating;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime Graduated { get; set; }

        [DisplayFormat(NullDisplayText = "No Rating Yet")]
        public double Rating { get; set; }
        //public double Rating { get => Reviews.Average(r=>r.Rating); set => _rating = value; }

        public string About { set; get; }

        public int LessonPrice { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<TeacherCourse> TeachersCourses { get; set; } = new List<TeacherCourse>();

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        public void UpdateRating()
        {
            try
            {
                Rating = Reviews.Average(r => r.Rating);
            } catch (Exception e)
            {
            }
            
        }
    }
}
