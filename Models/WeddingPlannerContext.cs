using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Enums;

namespace WeddingPlanner.Models
{
    public class WeddingPlannerContext : DbContext
    {
        public WeddingPlannerContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Wedder> Wedders { get; set; }
        public DbSet<WeddingPartyMember> WeddingPartyMembers { get; set; }
        public DbSet<WeddingNote> WeddingNotes { get; set; }
        public DbSet<VendorNote> VendorNotes { get; set; }

        public bool InsertWedding(Wedding wedding, int uid)
        {
            var user = Users.FirstOrDefault(u => u.UserId == uid);

            if (user != null)
            {
                wedding.Planner = user;
                wedding.Vendors = new List<Vendor>();

                Weddings.Add(wedding);
                SaveChanges();

                return true;
            }

            return false;
        }

        public Wedding GetWedding(int wid)
        {
            var weddings = Weddings.Include(wp => wp.WeddingParty)
                                    .Include(v => v.Vendors)
                                    .Include(u => u.Planner)
                                    .FirstOrDefault();
            
            return weddings;
        }

    }
}