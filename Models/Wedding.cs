using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeddingPlanner.Validators;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }

        [Required(ErrorMessage="Please enter a wedding date")]
        [Display(Name="Wedding Date")]
        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime WeddingDate { get; set; }

        [Required]
        [Display(Name="Bride")]
        public string WedderName1 { get; set; }

        [Required]
        [Display(Name="Groom")]
        public string WedderName2 { get; set; }

        public float Budget { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public User Planner { get; set; }

        public List<Vendor> Vendors { get; set; }

        public List<WeddingPartyMember> WeddingParty { get; set; }
    }
}