using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data.Models;

namespace TravelAgency.Data
{
    public class TravelAgencyDbContext : IdentityDbContext<User>
    {
        public TravelAgencyDbContext(DbContextOptions<TravelAgencyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasMany(c => c.Trips).WithOne(t => t.Destination).HasForeignKey(t => t.DestinationId);
            builder.Entity<UserTrip>().HasKey(ut => new { ut.UserId, ut.TripId });
            builder.Entity<User>().HasMany(u => u.SignedTrips).WithOne(ut => ut.User).HasForeignKey(ut => ut.UserId);
            builder.Entity<Trip>().HasMany(t => t.SignedUsers).WithOne(ut => ut.Trip).HasForeignKey(ut => ut.TripId);
            base.OnModelCreating(builder);
        }
    }
}
