using System;
using System.Collections.Generic;
using System.Text;

namespace NSW.Core.Domain.Entities
{
    public class SalesIssueItems
    {
        public int Id { get; set; }
        public SalesIssues? SalesIssues { get; set; }
        public int? SalesIssueId { get; set; }
        public Products? Products { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
