using System;
using System.Collections.Generic;
using CRM.API.Models;

namespace CRM.API.Dtos
{
    public class LeadForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string Company { get; set; }
        public IEnumerable<ContactPersonForListDto> ContactPersons { get; set; }
        public DateTime CashOn { get; set; }
        public float ClosingPropability { get; set; }
        public string Currency { get; set; }
        public int Volume { get; set; }
        public UserForListDto ResponsibleUser { get; set; }
        public string SalesCampaign { get; set; }
    }
}