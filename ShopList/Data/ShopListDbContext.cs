using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopList.Models;

namespace ShopList.Data
{
    public class ShopListDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemStore> Stores { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ChecklistItem> ChecklistItems { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChecklistItem>()
                .HasKey(c => new { c.ItemID, c.ChecklistID });
        }

        public ShopListDbContext(DbContextOptions<ShopListDbContext> options)
            : base(options)
        { }
    }
}
