using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeddingPlanner.Enums;

namespace WeddingPlanner.Models
{
    public class Wedder
    {
        public int WedderId { get; set; }

        [Required(ErrorMessage="Please enter a first name")]
        [MinLength(2, ErrorMessage="First Name must be at least 2 characters")]
        [Display(Name="First Name")]
        public string GivenName { get; set; }

        [Required(ErrorMessage="Please enter a surname")]
        [MinLength(2, ErrorMessage="Last Name must be at least 2 characters")]
        [Display(Name="Last Name")]
        public string Surname { get; set; }

        public WedderRoles WedderRole { get; set; }

        public int WeddingId { get; set; }

        public Wedding Wedding { get; set; }

    }
}