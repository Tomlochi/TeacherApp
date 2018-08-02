using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeacherApp.Models
{
    public enum Gender
    {
        [Display(Name = "Female")]
        Female,
        [Display(Name = "Male")]
        Male
    }

    public class Person
    {
    public Person() { }

        public Person(int id)
        {
            this.ID = id;
        }
        public Person(int id, string firstname, string lastname, string phone, Gender gender, string email, string address, DateTime dateofbirth, DateTime activesince)
        {
            this.ID = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Phone = phone;
            this.Gender = Gender;
            this.Email = email;
            this.Address = address;
            this.DateOfBirth = dateofbirth;
            this.ActiveSince = activesince;
        }
        public Person(Person person)
        {
            this.ID = person.ID;
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.Phone = person.Phone;
            this.Gender = person.Gender;
            this.Email = person.Email;
            this.Address = person.Address;
            this.DateOfBirth = person.DateOfBirth;
            this.ActiveSince = person.ActiveSince;
        }

        [Required]
        [StringLength(9)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "ID must contain numbers only")]
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
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActiveSince { get; set; }
    }
}
