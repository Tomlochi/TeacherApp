using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherApp.Models
{

    public class Student : Person
    {

       public virtual Degree Degree { get; set; }
       public virtual Institution Institution { get; set; }

        public Student() { }
        public Student(int id, string firstname, string lastname,string password, string phone, string gender, string email, string address, DateTime dateofbirth, DateTime activesince, Degree degree, Institution institution, bool isAdmin)
            : base(id, firstname, lastname, password, phone, gender, email, address, dateofbirth, isAdmin)
        {
            this.Degree = degree;
            this.Institution = institution;
        }
        public Student(Student student)
            : base(student.ID, student.FirstName, student.LastName,student.Password, student.Phone, student.Gender, student.Email, student.Address, student.DateOfBirth, student.isAdmin)
        {
            this.Degree = student.Degree;
            this.Institution = student.Institution;
        }

    }
}
