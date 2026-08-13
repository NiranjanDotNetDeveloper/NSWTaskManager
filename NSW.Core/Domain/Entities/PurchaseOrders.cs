using System;
using System.Collections.Generic;
using System.Text;

namespace NSW.Core.Domain.Entities
{
    public class PurchaseOrders
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public Suppliers? Supplier { get; set; }
        public int WareHouseId { get; set; }
        public Warehouses? Warehouses { get; set; }
        public string? Status { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<PurchaseOrderItems>? PurchaseOrderItems { get; set; } = new List<PurchaseOrderItems>();
    }
}
