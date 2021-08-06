using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataStore.EF
{
    public class BugsContext : DbContext
    {
        public BugsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tickets)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjektId);

            //data seeding
            modelBuilder.Entity<Project>().HasData(
                    new Project { ProjcetId = 1, Name = "Project 1" },
                    new Project { ProjcetId = 2, Name = "Project 2" }
                );

            modelBuilder.Entity<Ticket>().HasData(
                    new Ticket { TicketId = 1, Title = "Bug #1", ProjektId = 1 },
                    new Ticket { TicketId = 2, Title = "Bug #2", ProjektId = 1 },
                    new Ticket { TicketId = 3, Title = "Bug #3", ProjektId = 2 }
                );
        }
    }
}
