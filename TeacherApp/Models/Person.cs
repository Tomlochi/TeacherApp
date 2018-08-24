using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeacherApp.Models
{

    public class Person
    {
    public Person() { }


        public Person(int id, string firstname, string lastname,string password, string phone, string gender, string email, string address, DateTime dateofbirth,string degree,string institution)
        {
            this.ID = id;
            this.FirstName = firstname;
            this.Password = password;
            this.LastName = lastname;
            this.Phone = phone;
            this.Gender = Gender;
            this.Email = email;
            this.Address = address;
            this.DateOfBirth = dateofbirth;
            this.Degree = degree;
            this.Institution = institution;
        }


        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Address { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        public string Degree { get; set; }
        public string Institution { get; set; }
      
        public bool IsAdmin { get; set; }
    }
}
