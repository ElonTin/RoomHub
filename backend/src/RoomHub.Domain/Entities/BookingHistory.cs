namespace RoomHub.Domain.Entities;

public class BookingHistory
{
    public long Id { get; set; }
    public int RoomId { get; set; }
    public DateTime BookedAt { get; set; }
    public decimal? PriceAtBooking { get; set; }
    public int? DurationDays { get; set; }

    // Navigation
    public virtual Room Room { get; set; } = null!;
}
