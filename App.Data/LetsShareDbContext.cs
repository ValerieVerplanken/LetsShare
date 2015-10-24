using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using App.Models;
using App.Models.Identity;

namespace App.Data
{
    public class LetsShareDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Guide> Guides { get; set; }
              
        public LetsShareDbContext() : base()
        {
          
        }   
            
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Groups>(l =>
            {
               l.ToTable("Groups");
               l.Key(m => m.Id); 
               l.Property(m => m.Id).ValueGeneratedOnAdd();
               l.Property(m => m.CreatedAt).Required().HasColumnType("datetime").ValueGeneratedOnAdd();
               l.Property(m => m.UpdatedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.DeletedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.GroupName).Required().HasColumnType("nvarchar(128)");
               l.Property(m => m.Offers).Required().HasColumnType("nvarchar(1024)");
               l.Property(m => m.Requests).Required().HasColumnType("nvarchar(1024)");

            });
            
            modelBuilder.Entity<Guide>(l =>
            {
               l.ToTable("Guides");
               l.Key(m => m.Id); 
               l.Property(m => m.Id).ValueGeneratedOnAdd();
               l.Property(m => m.CreatedAt).Required().HasColumnType("datetime").ValueGeneratedOnAdd();
               l.Property(m => m.UpdatedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.DeletedAt).Required(false).HasColumnType("datetime");
               l.Property(m => m.Offers).Required().HasColumnType("nvarchar(1024)");
               l.Property(m => m.Requests).Required().HasColumnType("nvarchar(1024)");

            });
            
        }
        public override int SaveChanges()
        {
            this.ChangeTracker.DetectChanges();

            var entries = this.ChangeTracker.Entries();

            // Add entry
            var entriesFiltered = entries.Where(e => e.State == EntityState.Added);
            foreach (var entry in entriesFiltered)
            {
                entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
            }

            // Update entry
            entriesFiltered = entries.Where(e => e.State == EntityState.Modified);
            foreach (var entry in entriesFiltered)
            {
                entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
    }
}
