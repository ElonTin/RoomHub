namespace RoomHub.Domain.Entities;

public class SearchHistory
{
    public long Id { get; set; }
    public string UserId { get; set; } = null!;
    public string? SearchQuery { get; set; } // JSON
    public int? ViewedRoomId { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    // Navigation
    public virtual ApplicationUser User { get; set; } = null!;
    public virtual Room? ViewedRoom { get; set; }
}
