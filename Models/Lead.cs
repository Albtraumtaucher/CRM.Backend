using System;
using System.Collections.Generic;

namespace CRM.API.Models
{
    public class Lead
    {
        private DateTime _createdOn;
        private int _createdBy;
        private DateTime _updatedOn;
        private int _updatedBy;
        private DateTime _deletedOn;
        private int _deletedBy;
        private bool _isDeleted;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public LeadStatus Status { get; set; }
        public string Company { get; set; }
        public ICollection<ContactPerson> ContactPersons { get; set; }
        public DateTime CashOn { get; set; }
        public float ClosingPropability { get; set; }
        public string Currency { get; set; }
        public int Volume { get; set; }
        public User ResponsibleUser { get; set; }
        public string SalesCampaign { get; set; }

        //making the private Fields accessible but readonly
        public DateTime CreatedOn => _createdOn;
        public int CreatedBy => _createdBy;
        public DateTime UpdatedOn => _updatedOn;
        public int UpdatedBy => _updatedBy;
        public DateTime DeletedOn => _deletedOn;
        public int DeletedBy => _deletedBy;
        public bool IsDeleted => _isDeleted;
    }
}