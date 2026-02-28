namespace RoomHub.Domain.Entities;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal BasePrice { get; set; }
    public decimal CommissionRate { get; set; } = 0.10m;

    // Navigation
    public virtual ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
