using System;

namespace CRM.API.Dtos
{
    public class LeadStatusToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Boolean IsClosed { get; set; }

    }
}