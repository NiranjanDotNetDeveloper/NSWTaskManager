using System;

namespace NSW.Core.DTOs
{
    public class StockTransferDto
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? FromWareHouseId { get; set; }
        public int? ToWareHouseId { get; set; }
        public int Quantity { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateStockTransferDto
    {
        public int? ProductId { get; set; }
        public int? FromWareHouseId { get; set; }
        public int? ToWareHouseId { get; set; }
        public int Quantity { get; set; }
        public string? Status { get; set; }
    }

    public class UpdateStockTransferDto : CreateStockTransferDto
    {
        public int Id { get; set; }
    }
}
