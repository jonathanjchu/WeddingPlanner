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

        public List<Wedding> GetWeddings(int uid)
        {
            var weddings = Weddings.Where(u => u.UserId == uid).OrderBy(u => u.WeddingDate);

            return weddings.ToList();
        }

        public bool InsertWedding(Wedding wedding, int uid)
        {
            var user = Users.FirstOrDefault(u => u.UserId == uid);

            if (user != null)
            {
                wedding.Planner = user;
                wedding.Vendors = new List<Vendor>();

                Add(wedding);
                SaveChanges();

                return true;
            }

            return false;
        }

        public void UpdateWedding(Wedding wedding)
        {
            Update(wedding);
            SaveChanges();
        }

        public Wedding GetWedding(int wid)
        {
            var weddings = Weddings.Include(wp => wp.WeddingParty)
                                    .Include(v => v.Vendors)
                                    .Include(u => u.Planner)
                                    .FirstOrDefault(w => w.WeddingId == wid);
            
            return weddings;
        }

        public void AddNewVendor(Vendor vendor, int wid)
        {
            var wedding = Weddings.FirstOrDefault(w => w.WeddingId == wid);

            if (wedding != null)
            {
                if (wedding.Vendors == null)
                {
                    wedding.Vendors = new List<Vendor>();
                    System.Console.WriteLine("initializing vendor list");
                }

                wedding.Vendors.Add(vendor);

                SaveChanges();
            }

        }

        public Vendor GetVendor(int wid, int vid)
        {
            var vendor = Vendors.FirstOrDefault(v => v.VendorId == vid);

            return vendor;
        }

    }
}