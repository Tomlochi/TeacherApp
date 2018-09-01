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
        public int Rating { get; set; };
        public virtual int TeacherID { get; set; }
        public string ReviewContent { get; set; }


    }
}
