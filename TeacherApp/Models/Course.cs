using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherApp.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }

        static int count = 0;
        public Course()
        {
            count++;
            this.CourseID = count;
        }
        public Course(int courseid, string coursename, int credits)
        {
            this.CourseID = courseid;
            this.CourseName = coursename;
            this.Credits = credits;
        }
        public Course(Course course)
        {
            this.CourseID = course.CourseID;
            this.CourseName = course.CourseName;
            this.Credits = course.Credits;
        }




    }
}
