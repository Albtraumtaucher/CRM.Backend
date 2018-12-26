using System;
using System.Collections.Generic;

namespace CRM.API.Dtos
{
    public class LeadToUpdateDto
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public int StatusId { get; set; }
        public int CompanyId { get; set; }
        public IEnumerable<int> ContactPersonsId { get; set; }
        public DateTime CashOn { get; set; }
        public float ClosingPropability { get; set; }
        public string Currency { get; set; }
        public int Volume { get; set; }
        public int ResponsibleUserId { get; set; }
        public int SalesCampaignId { get; set; }
    }
}