using System;

namespace NSW.Core.DTOs
{
    public class SalesIssueDto
    {
        public int Id { get; set; }
        public int? WareHouseId { get; set; }
        public string? IssuedToId { get; set; }
        public DateTime IssuedDate { get; set; }
        public string? Status { get; set; }
    }

    public class CreateSalesIssueDto
    {
        public int? WareHouseId { get; set; }
        public string? IssuedToId { get; set; }
        public string? Status { get; set; }
    }

    public class UpdateSalesIssueDto : CreateSalesIssueDto
    {
        public int Id { get; set; }
    }
}
