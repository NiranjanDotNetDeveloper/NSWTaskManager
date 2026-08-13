using System;

namespace NSW.Core.DTOs
{
    public class StockTransactionDto
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? WareHouseId { get; set; }
        public Guid ReferenceId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Quantity { get; set; }
        public string? Type { get; set; }
    }

    public class CreateStockTransactionDto
    {
        public int? ProductId { get; set; }
        public int? WareHouseId { get; set; }
        public Guid ReferenceId { get; set; }
        public int Quantity { get; set; }
        public string? Type { get; set; }
    }

    public class UpdateStockTransactionDto : CreateStockTransactionDto
    {
        public int Id { get; set; }
    }
}
