namespace RoomHub.Domain.Entities;

public class TenantProfile
{
    public string UserId { get; set; } = null!;
    public string? CCCDNumber { get; set; }
    public string? PassportNumber { get; set; }
    public string? IdentityDocumentPath { get; set; }
    public string? SelfiePath { get; set; }
    public string? RentalHistory { get; set; } // JSON

    // Navigation
    public virtual ApplicationUser User { get; set; } = null!;
}
