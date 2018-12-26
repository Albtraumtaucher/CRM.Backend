using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.API.Dtos;
using CRM.API.Models;

namespace CRM.API.Data
{
    public interface ILeadRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        Task<bool> SaveAll();
        //All methods for Leads
        Task<IEnumerable<Lead>> GetLeads();
        Task<Lead> GetLead(int id);

        //All methods for leadStatus
        Task<IEnumerable<LeadStatus>> GetLeadStatuses();
        Task<LeadStatus> GetLeadStatus(int id);
        
    }
}