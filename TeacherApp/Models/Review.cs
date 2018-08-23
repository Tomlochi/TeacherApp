using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherApp.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public DateTime Published { get; set; }
        public int Rating { get; set; }
        public int StudentID { get; set; }
        public int TeacherID { get; set; }
        public string ReviewContent { get; set; }


        //static int count;
        //public Review()
        //{
        //    count++;
        //    ReviewID = count;
        //}
        //public Review(int reviewid, DateTime published, int rating, int studentid, int teacherid, string reviewContent)
        //{
        //    this.ReviewID = reviewid;
        //    this.Published = published;
        //    this.Rating = rating;
        //    this.StudentID = studentid;
        //    this.TeacherID = teacherid;
        //    this.ReviewContent = reviewContent;
        //}
        //public Review(Review review)
        //{
        //    this.ReviewID = review.ReviewID;
        //    this.Published = review.Published;
        //    this.Rating = review.Rating;
        //    this.StudentID = review.StudentID;
        //    this.TeacherID = review.TeacherID;
        //    this.ReviewContent = review.ReviewContent;
        //}




    }
}
