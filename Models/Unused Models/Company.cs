using System;
using System.Collections;
using System.Collections.Generic;

namespace CRM.API.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public ICollection<CompanyType> CompanyTypes { get; set; }
        public ICollection<ContactPerson> ContactPersons { get; set; }
        public Adress DefaultAdress { get; set; }
        public ICollection<Adress> Adresses { get; set; }
        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}