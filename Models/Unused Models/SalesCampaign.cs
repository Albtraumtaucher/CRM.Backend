using System;

namespace CRM.API.Models
{
    public class SalesCampaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}