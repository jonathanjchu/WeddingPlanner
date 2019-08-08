using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeddingPlanner.Enums;

namespace WeddingPlanner.Models
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }

        [Required(ErrorMessage="Please enter a vendor name")]
        [MinLength(2, ErrorMessage="Vendor name must be at least 2 characters")]
        [Display(Name="Vendor Name")]
        public string VendorName { get; set; }

        public VendorType VendorType { get; set; }

        [Display(Name="Phone Number")]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        [Display(Name="Point of Contact")]
        public string PointOfContact { get; set; }

        [Display(Name="Point of Contact, Phone Number")]
        public string POCPhoneNumber { get; set; }

        [Display(Name="Poin of Contact, Phone Number")]
        [EmailAddress]
        public string POCEmail { get; set; }

        public bool IsConfirmed { get; set; }

        [Display(Name="Deposit Fee")]
        public float DepositAmount { get; set; }

        [Display(Name="Deposit Due By")]
        public DateTime DepositDueDate { get; set; }
        
        [Display(Name="Has Deposit been Paid")]
        public bool IsDepositPaid { get; set; }

        [Display(Name="Total Cost")]
        public float TotalCost { get; set; }

        public bool IsCompletelyPaid { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int WeddingId { get; set; }

        public Wedding Wedding { get; set; }

    }
}