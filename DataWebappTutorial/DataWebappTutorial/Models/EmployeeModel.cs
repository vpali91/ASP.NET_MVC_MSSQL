using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataWebappTutorial.Models
{
    public class EmployeeModel
    {
        [Display (Name = "EmployeeId")]
        [Range(100000, 999999, ErrorMessage = "You need to enter a valid EmployeeId!")]
        public int EmployeeId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You have to write here something!")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You have to write here something!")]
        public string LastName { get; set; }

        //[DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "You have to write here something!")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage ="You must have a password!")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

    }
}