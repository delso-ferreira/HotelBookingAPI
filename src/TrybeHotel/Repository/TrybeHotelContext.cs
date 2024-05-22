using Microsoft.EntityFrameworkCore;
using TrybeHotel.Models;

namespace TrybeHotel.Repository;
public class TrybeHotelContext : DbContext, ITrybeHotelContext
{
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Hotel> Hotels { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Booking> Bookings { get; set; } = null!;
    public TrybeHotelContext(DbContextOptions<TrybeHotelContext> options) : base(options) {
    }
    public TrybeHotelContext() { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); 

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>()
            .HasMany(city => city.Hotels)
            .WithOne(hotel => hotel.City)
            .HasForeignKey(hotel => hotel.CityId);

        modelBuilder.Entity<Hotel>()
            .HasMany(hotel => hotel.Rooms)
            .WithOne(room => room.Hotel)
            .HasForeignKey(room => room.HotelId);

        modelBuilder.Entity<User>()
            .HasMany(user => user.Bookings)
            .WithOne(booking => booking.User)
            .HasForeignKey(booking => booking.UserId);

        modelBuilder.Entity<Room>()
            .HasMany(room => room.Bookings)
            .WithOne(booking => booking.Room)
            .HasForeignKey(booking => booking.RoomId);
    }


}