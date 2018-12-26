using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CRM.API.Data;
using CRM.API.Dtos;
using CRM.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILeadRepository _repo;

        public LeadsController(IMapper mapper, ILeadRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeads()
        {
            var leads = await _repo.GetLeads();

            var leadsToReturn = _mapper.Map<IEnumerable<LeadForListDto>>(leads);

            return Ok(leadsToReturn);
        }

        [HttpGet("{id}", Name = "GetLead")]
        public async Task<IActionResult> GetLead(int id)
        {
            var lead = await _repo.GetLead(id);

            var leadToReturn = _mapper.Map<LeadForListDto>(lead);

            return Ok(leadToReturn);
        }

        [HttpPost("new")]
        public async Task<IActionResult> NewLead(LeadToCreateDto leadToCreateDto)
        {
            var lead = _mapper.Map<Lead>(leadToCreateDto);

            _repo.Add(lead);

            var result = await _repo.SaveAll();

            if (result == true)
            {
                return CreatedAtRoute(routeName:"GetLead",
                    routeValues: new{ id = lead.Id }, value: lead);
            }

            return BadRequest("Couldn't create Lead");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditLead(int id, LeadToUpdateDto leadToUpdate)
        {
            var lead = await _repo.GetLead(id);

            if(lead == null)
            {
                return BadRequest("Couldn't find lead");
            }

            _repo.Update(lead);

            lead = _mapper.Map<Lead>(leadToUpdate);

            var result = await _repo.SaveAll();

            if(result == true)
            {
                return Ok(lead);
            }

            return BadRequest("Couldn't save changes");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var leadToDelete = await _repo.GetLead(id);

            _repo.Delete(leadToDelete);

            var result = await _repo.SaveAll();

            if(result == true)
            {
                return Ok("Deleted lead successfully");
            }

            return BadRequest("Failed to delete lead");

        }
    }
}