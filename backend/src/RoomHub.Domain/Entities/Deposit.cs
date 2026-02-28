using RoomHub.Domain.Enums;

namespace RoomHub.Domain.Entities;

public class Deposit
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string TenantId { get; set; } = null!;
    public decimal Amount { get; set; }
    public int HoldDurationDays { get; set; }
    public DateTime PlacedAt { get; set; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; }
    public DepositStatus Status { get; set; }
    public decimal? RefundAmount { get; set; }

    // Navigation
    public virtual Room Room { get; set; } = null!;
    public virtual ApplicationUser Tenant { get; set; } = null!;
}
