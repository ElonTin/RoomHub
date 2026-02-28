namespace RoomHub.Domain.Entities;

public class Payment
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public string? PaymentMethod { get; set; } // QR, Momo, VNPay, BankTransfer...
    public string? TransactionId { get; set; }
    public string Status { get; set; } = null!;
    public string? ProofPath { get; set; }
    public DateTime? PaidAt { get; set; }

    // Navigation
    public virtual Invoice Invoice { get; set; } = null!;
}
