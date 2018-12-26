using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace CRM.API.Models
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}