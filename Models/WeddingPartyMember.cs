using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeddingPlanner.Enums;

namespace WeddingPlanner.Models
{
    public class WeddingPartyMember
    {
        public int WeddingPartyMemberId { get; set; }

        public string Name { get; set; }
        public WeddingPartyRoles Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int WeddingId { get; set; }

        public Wedding Wedding { get; set; }
    }
}