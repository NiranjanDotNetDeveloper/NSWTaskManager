using System;

namespace NSW.Core.DTOs
{
    public class LowStockAlertDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public DateTime TriggeredAt { get; set; }
        public bool IsResolved { get; set; }
    }

    public class CreateLowStockAlertDto
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
    }

    public class UpdateLowStockAlertDto : CreateLowStockAlertDto
    {
        public int Id { get; set; }
        public bool IsResolved { get; set; }
    }
}
