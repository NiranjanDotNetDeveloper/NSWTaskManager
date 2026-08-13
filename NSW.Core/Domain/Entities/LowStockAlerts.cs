using System;
using System.Collections.Generic;
using System.Text;

namespace NSW.Core.Domain.Entities
{
    public class LowStockAlerts
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Products? Product { get; set; }
        public int WarehouseId { get; set; }
        public Warehouses? Warehouses { get; set; }
        public DateTime TriggeredAt { get; set; }
        public bool IsResolved { get; set; }
    }
}
