using System;
using System.Collections.Generic;
using System.Text;

namespace NSW.Core.Domain.Entities
{
    public class SalesIssues
    {
        public int Id { get; set; }

        public int? WareHouseId { get; set; }
        public Warehouses? Warehouses { get; set; }

        public string? IssuedToId { get; set; } 
        public DateTime IssuedDate { get; set; }
        public string? Status { get; set; }
        public ICollection<SalesIssueItems> SalesIssueItems { get; set; } = new List<SalesIssueItems>();
    }
}
