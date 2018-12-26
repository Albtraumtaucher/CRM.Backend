using System;
using System.ComponentModel.DataAnnotations;
using CRM.API.Models;

namespace CRM.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Adress Adress { get; set; }
    }
}