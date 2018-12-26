using System;

namespace CRM.API.Models
{
    public class ContactPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Salutation { get; set; }
        public Adress Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Company { get; set; }
        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}