using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class VendorNote
    {
        [Key]
        public int NoteId { get; set; }

        public string NoteText { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }


    }
}