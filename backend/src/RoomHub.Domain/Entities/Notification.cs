namespace RoomHub.Domain.Entities;

public class Notification
{
    public long Id { get; set; }
    public string UserId { get; set; } = null!;
    public string? Type { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int? LinkedId { get; set; } // Polymorphic
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public virtual ApplicationUser User { get; set; } = null!;
}
