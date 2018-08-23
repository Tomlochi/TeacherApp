﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherApp.Models
{

    public class Student : Person
    {

        Degree Degree { get; set; }
        Institution Institution { get; set; }

        public Student() { }
        public Student(int id, string firstname, string lastname, string phone, string gender, string email, string address, DateTime dateofbirth, DateTime activesince, Degree degree, Institution institution)
            : base(id, firstname, lastname, phone, gender, email, address, dateofbirth, activesince)
        {
            this.Degree = degree;
            this.Institution = institution;
        }
        public Student(Student student)
            : base(student.ID, student.FirstName, student.LastName, student.Phone, student.Gender, student.Email, student.Address, student.DateOfBirth, student.ActiveSince)
        {
            this.Degree = student.Degree;
            this.Institution = student.Institution;
        }

    }
}
