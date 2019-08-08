using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage="First Name is required")]
        [MinLength(2, ErrorMessage="First Name must be at least 2 characters")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Last Name is required")]
        [MinLength(2, ErrorMessage="Last Name must be at least 2 characters")]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Email Address is required")]
        [EmailAddress(ErrorMessage="Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage="Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters long")]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password",ErrorMessage="Passwords don't match")]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        public string Confirm { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}