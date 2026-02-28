using RoomHub.Domain.Enums;

namespace RoomHub.Domain.Entities;

public class MaintenanceTicket
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string TenantId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Images { get; set; } // JSON
    public TicketStatus Status { get; set; }
    public Sentiment? Sentiment { get; set; } // AI FE-AI-05
    public string? AssignedTo { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public virtual Room Room { get; set; } = null!;
    public virtual ApplicationUser Tenant { get; set; } = null!;
    public virtual ApplicationUser? AssignedUser { get; set; }
}
