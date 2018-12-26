using System;
using System.Collections.Generic;
using CRM.API.Models;

namespace CRM.API.Dtos
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public Adress Adress { get; set; }
        public DateTime LastActive { get; set; }
        public IEnumerable<UserRoleToReturn> UserRoles { get; set; }
    }
}