using System;
using System.Collections.Generic;
using System.Text;

namespace NSW.Core.Domain.Entities
{
    public class StockTransfers
    {
        public int Id { get; set; }
        public Products? Products { get; set; }
        public int? ProductId { get; set; }
        public int? FromWareHouseId { get; set; }
        public Warehouses? FromWarehouses { get; set; }

        public int? ToWareHouseId { get; set; }
        public Warehouses? ToWarehouses { get; set; }
        public int Quantity { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
