using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLoginDemo.Models
{
    public class AddEmployee
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Designation")]
        public string Designation { get; set; }
    }

    public class AddRemark
    {
        [Required]
        [Display(Name = "AddRemarks")]
        public string AddRemarks { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public string SelectedEmployee { get; set; }
    }
}