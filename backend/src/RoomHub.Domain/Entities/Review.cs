namespace RoomHub.Domain.Entities;

public class Review
{
    public int Id { get; set; }
    public string TenantId { get; set; } = null!;
    public int? RoomId { get; set; }
    public string? OwnerId { get; set; }
    public int? ServiceId { get; set; }
    public byte? Rating { get; set; }
    public string? Comment { get; set; }
    public bool IsModerated { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public virtual ApplicationUser Tenant { get; set; } = null!;
    public virtual Room? Room { get; set; }
    public virtual ApplicationUser? Owner { get; set; }
    public virtual Service? Service { get; set; }
}
