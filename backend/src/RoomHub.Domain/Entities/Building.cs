namespace RoomHub.Domain.Entities;

public class Building
{
    public int Id { get; set; }
    public string OwnerId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Province { get; set; }
    public string City { get; set; } = null!;
    public string District { get; set; } = null!;
    public string Ward { get; set; } = null!;
    public string Address { get; set; } = null!;
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    // Navigation
    public virtual ApplicationUser Owner { get; set; } = null!;
    public virtual ICollection<Floor> Floors { get; set; } = new List<Floor>();
}
