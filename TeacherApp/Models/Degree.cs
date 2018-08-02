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
        public List<Course> courses { get; set; }
        public Institution institution { get; set; }

        static int count = 0;
        public Degree()
        {
            count++;
            DegreeID = count;
            List<Course> courses = new List<Course>();
        }
        public Degree(int degreeid, string degreename, int durationinyears, List<Course> courses, Institution institution)
        {
            this.DegreeID = degreeid;
            this.DegreeName = degreename;
            this.DurationinYears = durationinyears;
            this.courses = courses;
            this.institution = institution;
        }
        public Degree(Degree degree)
        {
            this.DegreeID = degree.DegreeID;
            this.DegreeName = degree.DegreeName;
            this.DurationinYears = degree.DurationinYears;
            this.courses = degree.courses;
            this.institution = degree.institution;
        }


    }
}
