using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.API.Dtos;
using CRM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.API.Data
{
    public class LeadRepository : ILeadRepository
    {
        private readonly DataContext _context;

        public LeadRepository(DataContext context)
        {
            _context = context;
        }

        //Generic methods to get, edit, remove and save entities
        // @Deleted: Soft-delete
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void Update<T>(T entity) where T: class
        {
            _context.Update(entity);
        }
        
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        //Methods to get Leads
        public async Task<Lead> GetLead(int id)
        {
            var lead = await _context.Leads.FirstOrDefaultAsync(p => p.Id == id);

            return lead;
        }

        public async Task<IEnumerable<Lead>> GetLeads()
        {
            var leads = await _context.Leads.ToListAsync();

            return leads;
        }

        //Methods to get Status of Leads
        public async Task<IEnumerable<LeadStatus>> GetLeadStatuses()
        {
            var status = await _context.LeadStatus.ToListAsync();

            return status;
        }

        public async Task<LeadStatus> GetLeadStatus(int id)
        {
            var status = await _context.LeadStatus.FirstOrDefaultAsync(x => x.Id == id);

            return status;
        }
    }
}