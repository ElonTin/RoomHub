namespace RoomHub.Domain.Entities;

public class InvoiceItem
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public string ItemType { get; set; } = null!; // Rent, Electricity, Water, Service, Penalty...
    public string? Description { get; set; }
    public decimal Amount { get; set; }

    // Navigation
    public virtual Invoice Invoice { get; set; } = null!;
}
