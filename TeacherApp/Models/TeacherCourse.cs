using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// entity class representing join table 
namespace TeacherApp.Models
{
    public class TeacherCourse
    {
        public int TeacherID { get; set; }
        public int CourseID { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
    }
}
