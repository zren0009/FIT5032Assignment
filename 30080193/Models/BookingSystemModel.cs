namespace _30080193.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookingSystemModel : DbContext
    {
        public BookingSystemModel()
            : base("name=BookingSystemModel")
        {
        }

        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<ratings> ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookings>()
                .HasMany(e => e.ratings)
                .WithRequired(e => e.Bookings)
                .HasForeignKey(e => e.BookingId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Locations>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Locations>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Locations>()
                .Property(e => e.Latitude)
                .HasPrecision(10, 8);

            modelBuilder.Entity<Locations>()
                .Property(e => e.Longitude)
                .HasPrecision(11, 8);

            modelBuilder.Entity<Locations>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Locations)
                .HasForeignKey(e => e.LocationId)
                .WillCascadeOnDelete(false);
        }
    }
}
