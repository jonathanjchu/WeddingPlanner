using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class WeddingNote
    {
        [Key]
        public int NoteId { get; set; }

        public string NoteText { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int WeddingId { get; set; }
        public Wedding Wedding { get; set; }

        
    }
}