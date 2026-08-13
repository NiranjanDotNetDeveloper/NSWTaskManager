using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NSW.Core.Domain.Entities
{
    public class Users:IdentityUser
    {
        public string? Name { get; set; }
        public string? RoleId { get; set; }
        public Roles? Role { get; set; }
        public ICollection<Warehouses> Warehouses { get; set; } = new List<Warehouses>();
    }
}
