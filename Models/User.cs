using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace CRM.API.Models
{
    public class User : IdentityUser<int>
    {
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Adress Adress { get; set; }
        public DateTime LastActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public User CreatedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public User ChangedBy { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        
    }
}