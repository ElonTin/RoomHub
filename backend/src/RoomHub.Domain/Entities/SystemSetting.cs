namespace RoomHub.Domain.Entities;

public class SystemSetting
{
    public int Id { get; set; }
    public int DefaultHoldDurationDays { get; set; } = 3;
    public decimal DefaultDepositPercent { get; set; } = 50.00m;
    public decimal PlatformCommissionRate { get; set; } = 10.00m;
    public int MaxRoomsPerBuilding { get; set; } = 500;
    public DateTime? UpdatedAt { get; set; }
}
