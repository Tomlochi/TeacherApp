using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherApp.Models
{
    public class Degree
    {
        public int DegreeID { get; set; }
        public string DegreeName { get; set; }
        public int DurationinYears { get; set; }
        public virtual ICollection<Course> courses { get; } = new List<Course>();
        public virtual Institution institution { get; set; }


    }
}
