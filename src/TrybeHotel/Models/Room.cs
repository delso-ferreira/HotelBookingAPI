namespace TrybeHotel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Room
{
    public int RoomId { get; set; }

    public string? Name { get; set; }

    public int Capacity { get; set; }

    public string? Image { get; set; }

    public int HotelId { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual List<Booking>? Bookings { get; set; }
}