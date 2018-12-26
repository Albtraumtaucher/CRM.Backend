using System;

namespace CRM.API.Models
{
    public class LeadStatus
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
        public Boolean IsClosed { get; set; }

        //Make private Fields
        public DateTime CreatedOn => _createdOn;
        public int CreatedBy => _createdBy;
        public DateTime UpdatedOn => _updatedOn;
        public int UpdatedBy => _updatedBy;
        public DateTime DeletedOn => _deletedOn;
        public int DeletedBy => _deletedBy;
        public bool IsDeleted => _isDeleted;
    }
}