using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSW.Core.Domain.Entities
{
    public class Roles:IdentityRole
    {
        public ICollection<Users> User { get; set; }=new List<Users>();
    }
}
