using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage="Please enter your login email address")]
        [Display(Name="Email")]
        public string LoginEmail { get; set; }

        [Required(ErrorMessage="Please enter your login password")]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }
    }
}