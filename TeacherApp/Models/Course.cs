using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherApp.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        public string CourseName { get; set; }

        [Range(0,7)]
        public int Credits { get; set; }

        public ICollection<TeacherCourse> TeachersCourses { get; set; }
    }
}
