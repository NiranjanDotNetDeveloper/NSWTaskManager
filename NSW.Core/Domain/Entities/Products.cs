using System;
using System.Collections.Generic;
using System.Text;

namespace NSW.Core.Domain.Entities
{
    public class Products
    {
        public int ProdId { get; set; }
        public string? Name { get; set; }
        public Guid? SKU { get; set; }
        public string? BarCode { get; set; }
        public int CategoryId { get; set; }
        public Categories? Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int ReorderLevel { get; set; }
        public ICollection<StockLevels> StockLevels { get; set; } = new List<StockLevels>();
        public ICollection<StockTransactions> StockTransactions { get; set; } = new List<StockTransactions>();
        public ICollection<StockTransfers> StockTransfers { get; set; } = new List<StockTransfers>();
        public ICollection<PurchaseOrderItems> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItems>();
        public ICollection<SalesIssueItems> SalesIssueItems { get; set; } = new List<SalesIssueItems>();
        public ICollection<LowStockAlerts> LowStockAlerts { get; set; } = new List<LowStockAlerts>();

    }
}
