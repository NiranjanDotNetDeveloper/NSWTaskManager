using System;

namespace NSW.Core.DTOs
{
    public class WarehouseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? ManagerId { get; set; }
    }

    public class CreateWarehouseDto
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? ManagerId { get; set; }
    }

    public class UpdateWarehouseDto : CreateWarehouseDto
    {
        public int Id { get; set; }
    }
}
