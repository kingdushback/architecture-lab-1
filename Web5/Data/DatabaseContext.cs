using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web5.Models;
using Microsoft.EntityFrameworkCore;

namespace Web5.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Human> Humans { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Transport> Transports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agency>().ToTable("Agency");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Human>().ToTable("Human");
            modelBuilder.Entity<Hotel>().ToTable("Hotel");
            modelBuilder.Entity<Transport>().ToTable("Transport");
        }
    }
}
