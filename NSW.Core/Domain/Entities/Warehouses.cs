using System;
using System.Collections.Generic;
using System.Text;

namespace NSW.Core.Domain.Entities
{
    public class Warehouses
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public Users? User { get; set; }
        public string? ManagerId { get; set; }
        public ICollection<PurchaseOrders>? PurchaseOrders { get; set; } = new List<PurchaseOrders>();
        public ICollection<LowStockAlerts> LowStockAlerts { get; set; } = new List<LowStockAlerts>();
        public ICollection<StockLevels> StockLevels { get; set; } = new List<StockLevels>();
        public ICollection<StockTransactions> StockTransactions { get; set; } = new List<StockTransactions>();
        public ICollection<SalesIssues> SalesIssues { get; set; } = new List<SalesIssues>();

        public ICollection<StockTransfers> TransfersFrom { get; set; } = new List<StockTransfers>();
        public ICollection<StockTransfers> TransfersTo { get; set; } = new List<StockTransfers>();

    }
}