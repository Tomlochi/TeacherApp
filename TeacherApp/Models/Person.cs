using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeacherApp.Models
{

    public class Person
    {

        public int ID { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "First name cannot be longere than 20 chrechters.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "First name must contain letters only")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Last name cannot be longere than 20 chrechters.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Last name must contain letters only")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

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

        public bool IsAdmin { get; set; }
        public string Degree { get; set; }
        public string Institution { get; set; }

        public Person() {}

        public Person(int id, string firstname, string lastname, string password, string phone, string gender, string email, string address, DateTime dateofbirth, bool isAdmin, string degree, string institution)
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
            this.IsAdmin = isAdmin;
            this.Degree = degree;
            this.Institution = institution;
        }

        public Person(int id, string firstname, string lastname, string password, string phone, string gender, string email, string address, DateTime dateofbirth, string degree, string institution)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            Password = password;
            Phone = phone;
            Gender = gender;
            Email = email;
            Address = address;
            DateOfBirth = dateofbirth;
            Degree = degree;
            Institution = institution;
        }

        public Person(int iD, string firstName, string lastName, string password, string phone, string gender, string email, string address, DateTime dateOfBirth)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Phone = phone;
            Gender = gender;
            Email = email;
            Address = address;
            DateOfBirth = dateOfBirth;
        }
    }
}
