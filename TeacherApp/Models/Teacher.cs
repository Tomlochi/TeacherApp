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
                Rating = Reviews.Average(r => (double)r.Rating);
            } catch (Exception e){}
        }

        public int RatingCount(int rating)
        {
            try
            {
                int count = Reviews.Where(r => r.Rating == rating).ToList().Count;
                return count;
            }
            catch(Exception e) { }
            return 0;
        }
        public int RatingPrecentage(int rating)
        {
            if (Reviews.Count == 0) {return 0;}
            try
            {
                int count = Reviews.Where(r => r.Rating == rating).ToList().Count;
                return count*100/Reviews.Count;
            }
            catch (Exception e) { }
            return 0;
        }
    }
}
