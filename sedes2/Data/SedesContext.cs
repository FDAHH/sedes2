using Microsoft.EntityFrameworkCore;
using sedes.Models;

namespace sedes.Data
{
    public class SedesContext : DbContext
    {
        public SedesContext(DbContextOptions<SedesContext> options)
            : base(options)
        {
        }
        public DbSet<Building> Building { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Reservation> Reservation { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<Building>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<Seat>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<Building>().HasMany(c => c.Rooms);
            modelBuilder.Entity<Room>().HasMany(c => c.Seats);
            modelBuilder.Entity<Reservation>().HasOne(c => c.Person);
            modelBuilder.Entity<Reservation>().HasOne(d => d.Seat);
            modelBuilder.Entity<Reservation>().HasOne(e => e.Building);
            modelBuilder.Entity<Building>();
            modelBuilder.Entity<Room>();
            modelBuilder.Entity<Seat>();
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<Reservation>();
        }
    }
}
