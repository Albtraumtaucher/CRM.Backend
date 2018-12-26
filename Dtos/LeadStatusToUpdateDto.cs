using System;

namespace CRM.API.Dtos
{
    public class LeadStatusToUpdateDto
    {
        public string Name { get; set; }
        public Boolean IsClosed { get; set; }
    }
}